using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB_BASE.Models;
using WEB_BASE.Repository;

namespace WEB_BASE.Controllers
{
    public class ProductsCategoryController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: ProductsCategory
        public ActionResult Index()
        {
            return View(_unitOfWork.ProductsCategoryRepository.DbSet.ToList());
        }

        // GET: ProductsCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productsCategoryModels = _unitOfWork.ProductsCategoryRepository.GetById(id);
            if (productsCategoryModels == null)
            {
                return HttpNotFound();
            }
            return View(productsCategoryModels);
        }

        // GET: ProductsCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CreatedBy,CreationDate,UpdatedBy,UpdatedDate")] ProductCategory productsCategoryModels)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductsCategoryRepository.Insert(productsCategoryModels);
                _unitOfWork.ProductsCategoryRepository.Commit();
            
                return RedirectToAction("Index");
            }

            return View(productsCategoryModels);
        }

        // GET: ProductsCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productsCategoryModels = _unitOfWork.ProductsCategoryRepository.GetById(id);
            if (productsCategoryModels == null)
            {
                return HttpNotFound();
            }
            return View(productsCategoryModels);
        }

        // POST: ProductsCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,CreatedBy,CreationDate,UpdatedBy,UpdatedDate")] ProductCategory productsCategoryModels)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductsCategoryRepository.Update(productsCategoryModels);
                _unitOfWork.ProductsCategoryRepository.Commit();
                
                return RedirectToAction("Index");
            }
            return View(productsCategoryModels);
        }

        // GET: ProductsCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productsCategoryModels = _unitOfWork.ProductsCategoryRepository.GetById(id);
            if (productsCategoryModels == null)
            {
                return HttpNotFound();
            }
            return View(productsCategoryModels);
        }

        // POST: ProductsCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productsCategoryModels = _unitOfWork.ProductsCategoryRepository.GetById(id);
            _unitOfWork.ProductsCategoryRepository.Delete(productsCategoryModels);
            _unitOfWork.ProductsCategoryRepository.Commit();
            
            return RedirectToAction("Index");
        }
    }
}
