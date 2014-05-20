using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WEB_BASE.Models;
using WEB_BASE.Repository;

namespace WEB_BASE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationFullContext _db = new ApplicationFullContext();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: Products
        public ActionResult Index()
        {
            var products = _unitOfWork.ProductsRepository.DbSet.Include(p => p.Category);   
            return View(products.ToList());
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
            ViewBag.CategoryId = new SelectList(_unitOfWork.ProductsCategoryRepository.DbSet, "CategoryId", "CategoryName");//new SelectList(_db.Categorys, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction("Index");
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
            ViewBag.CategoryId = new SelectList(_unitOfWork.ProductsCategoryRepository.DbSet, "CategoryId", "CategoryName");//new SelectList(_db.Categorys, "CategoryId", "CategoryName");
            return View(productsModels);
        }

        // POST: Products/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,ProductName,UnitPrice,CategoryId,CreatedBy,CreationDate")] ProductsModels productsModels)
        {
            if (ModelState.IsValid)
            {
                productsModels.UpdatedDate = DateTime.Now;
                productsModels.UpdatedBy = User.Identity.GetUserId();
                _unitOfWork.ProductsRepository.Context.Entry(productsModels).State = EntityState.Modified;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
