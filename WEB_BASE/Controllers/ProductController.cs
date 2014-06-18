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
    public class ProductController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: Products
        public ActionResult Index([Bind(Include = "SearchString, SortOrder, CurrentFilter, Page")] string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameParam = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.DateParam = sortOrder == "Date" ? "Date_Desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;

            var products = _unitOfWork.ProductsRepository.DbSet
                .OrderByDescending(p => p.ProductName)
                .Include(p => p.Category)
                .Select(p => new ProductViewModels
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    CreatedBy = p.CreatedBy,
                    CreationDate = p.CreationDate,
                    CategoryName = p.Category.CategoryName,
                }
                );

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name_Desc" :
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                case "Date" :
                    products = products.OrderBy(p => p.CreationDate);
                    break;
                case "Date_Desc" : 
                    products = products.OrderByDescending(p => p.CreationDate);
                    break;
                default :
                    products = products.OrderBy(p => p.ProductName);
                    break;
            }

            const int pageSize = 5;
            var pageNumber = page ?? 1;

            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(500);
                return PartialView("_ListProducts", products.ToPagedList(pageNumber, pageSize));
            }

            return View(products.ToPagedList(pageNumber, pageSize));
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
            Product productsModels = _unitOfWork.ProductsRepository.GetById(id);
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
        public ActionResult Create([Bind(Include = "ProductId,ProductCode,ProductName,UnitPrice,CategoryId")] Product productsModels)
        {
            if (ModelState.IsValid)
            {
                productsModels.CreationDate = DateTime.Now;
                productsModels.CreatedBy = User.Identity.GetUserId();

                _unitOfWork.ProductsRepository.Insert(productsModels);
                _unitOfWork.ProductsRepository.Commit();

                TempData["success"] = "Cadastro efetuado com sucesso.";

                return RedirectToAction("Create");
            }

            TempData["error"] = "Erro ao efetuar cadastro.";

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
            Product productsModels = _unitOfWork.ProductsRepository.GetById(id);
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
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,ProductName,UnitPrice,CategoryId,CreatedBy,CreationDate")] Product productsModels)
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
            Product productsModels = _unitOfWork.ProductsRepository.GetById(id);
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
            Product productsModels = _unitOfWork.ProductsRepository.GetById(id);

            _unitOfWork.ProductsRepository.Delete(productsModels);
            _unitOfWork.ProductsRepository.Commit();

            return RedirectToAction("Index");
        }
    }
}
