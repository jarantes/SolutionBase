using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WEB_BASE.Models;
using WEB_BASE.Repository;
using PagedList;

namespace WEB_BASE.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: Products
        public ActionResult Index([Bind(Include = "ProductName, Page")] string productName, int page = 1)
        {
            var products = _unitOfWork.ProductsRepository.DbSet
                .OrderByDescending(p => p.ProductName)
                .Where(p => productName == null || p.ProductName.StartsWith(productName))
                .Include(p => p.Category)
                .Select(p => new ProductsViewModels
                            {
                                ProductId = p.ProductId,
                                ProductCode = p.ProductCode,
                                ProductName = p.ProductName,
                                UnitPrice = p.UnitPrice,
                                CreatedBy = p.CreatedBy,
                                CreationDate = p.CreationDate,
                                CategoryName = p.Category.CategoryName,
                            }
                        ).ToPagedList(page, 5);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListProducts", products);
            }
            return View(products);
        }

        public ActionResult AutoComplete(string term)
        {
            var produtcsName = _unitOfWork.ProductsRepository.DbSet
                .Where(a => a.ProductName.StartsWith(term))
                .Take(10)
                .Select(a => new
                {
                    label = a.ProductName
                });

            return Json(produtcsName, JsonRequestBehavior.AllowGet);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsModels productsModels = _unitOfWork.ProductsRepository.GetById(id);
            if (productsModels == null)
            {
                return HttpNotFound();
            }
            return View(productsModels);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_unitOfWork.ProductsCategoryRepository.DbSet, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCode,ProductName,UnitPrice,CategoryId")] ProductsModels productsModels)
        {
            if (ModelState.IsValid)
            {
                productsModels.CreationDate = DateTime.Now;
                productsModels.CreatedBy = User.Identity.GetUserId();

                _unitOfWork.ProductsRepository.Insert(productsModels);
                _unitOfWork.ProductsRepository.Commit();

                return RedirectToAction("Create");
            }

            ViewBag.CategoryId = new SelectList(_unitOfWork.ProductsCategoryRepository.DbSet, "CategoryId", "CategoryName");
            return View(productsModels);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsModels productsModels = _unitOfWork.ProductsRepository.GetById(id);
            if (productsModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_unitOfWork.ProductsCategoryRepository.DbSet, "CategoryId", "CategoryName");
            return View(productsModels);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,ProductName,UnitPrice,CategoryId,CreatedBy,CreationDate")] ProductsModels productsModels)
        {
            if (ModelState.IsValid)
            {
                productsModels.UpdatedDate = DateTime.Now;
                productsModels.UpdatedBy = User.Identity.GetUserId();

                //_unitOfWork.ProductsRepository.Context.Entry(productsModels).State = EntityState.Modified;
                _unitOfWork.ProductsRepository.Update(productsModels);
                _unitOfWork.ProductsRepository.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_unitOfWork.ProductsCategoryRepository.DbSet, "CategoryId", "CategoryName");
            return View(productsModels);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsModels productsModels = _unitOfWork.ProductsRepository.GetById(id);
            if (productsModels == null)
            {
                return HttpNotFound();
            }
            return View(productsModels);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsModels productsModels = _unitOfWork.ProductsRepository.GetById(id);

            _unitOfWork.ProductsRepository.Delete(productsModels);
            _unitOfWork.ProductsRepository.Commit();

            return RedirectToAction("Index");
        }
    }
}
