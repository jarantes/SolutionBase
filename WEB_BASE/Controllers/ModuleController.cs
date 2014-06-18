using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WEB_BASE.Models;
using WEB_BASE.Repository;

namespace WEB_BASE.Controllers
{
    public class ModuleController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly Util _util = new Util();

        // GET: Module
        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWork.ModulesRepository.DbSet.ToListAsync());
        }

        // GET: Module/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var module = await _unitOfWork.ModulesRepository.DbSet.FindAsync(id);//db.Modules.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Module/Create
        public ActionResult Create()
        {
            ViewBag.Icon = new SelectList(_util.GetAllIcons().OrderBy(i => i.Icon), "Icon", "Icon");
            return View();
        }

        // POST: Module/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ModuleId,ModuleName,Controller,Action,Icon,ParentModuleId")] Module module)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ModulesRepository.Insert(module);
                await _unitOfWork.ModulesRepository.Context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }

            return View(module);
        }

        // GET: Module/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await _unitOfWork.ModulesRepository.DbSet.FindAsync(id);
            ViewBag.Icon = new SelectList(_util.GetAllIcons().OrderBy(i => i.Icon), "Icon", "Icon");
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Module/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ModuleId,ModuleName,Controller,Action,Icon,ParentModuleId")] Module module)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ModulesRepository.Context.Entry(module).State = EntityState.Modified;
                await _unitOfWork.ModulesRepository.Context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: Module/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await _unitOfWork.ModulesRepository.DbSet.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Module module = await _unitOfWork.ModulesRepository.DbSet.FindAsync(id);
            _unitOfWork.ModulesRepository.Delete(module);
            await _unitOfWork.ModulesRepository.Context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
