using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity.Owin;
using Trirand.Web.Mvc;
using WEB_BASE.Models;
using WEB_BASE.Repository;


namespace WEB_BASE.Controllers
{
    [Authorize]
    public class ModuleController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly Util _util = new Util();
        private ApplicationUserManager _userManager;
        List<JQTreeNode> _checkedNodes = new List<JQTreeNode>();


        public ModuleController()
        {
        }

        public ModuleController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

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
            var listMod = new List<Module> {new Module {ParentModuleId = null, ModuleName = ""}};
            listMod.AddRange(_unitOfWork.ModulesRepository.DbSet.Where(m => m.ParentModuleId == null));
            ViewBag.ParentModuleId =
                new SelectList(
                    listMod,
                    "ParentModuleId", "ModuleName", "");
            return View();
        }

        // POST: Module/Create
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

            ViewBag.Icon = new SelectList(_util.GetAllIcons().OrderBy(i => i.Icon), "Icon", "Icon");
            var listMod = new List<Module> { new Module { ParentModuleId = null, ModuleName = "" } };
            listMod.AddRange(_unitOfWork.ModulesRepository.DbSet.Where(m => m.ParentModuleId == null));
            ViewBag.ParentModuleId =
                new SelectList(
                    listMod,
                    "ParentModuleId", "ModuleName", "");

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

        // GET: Module/ManageAccess
        public ActionResult ManageAccess()
        {
            ViewBag.UserId = new SelectList(UserManager.Users.ToList(), "Id", "Name");
            return View();
        }

        // POST: Module/ManageAccess
        [HttpPost]
        public ActionResult ManageAccess(ManageAccessViewModels model)
        {
            ViewBag.UserId = new SelectList(UserManager.Users.ToList(), "Id", "Name");

            if (!String.IsNullOrEmpty(model.UserId))
            {
                if (model.CheckBoxesTreeView_checkedState != "[]")
                {
                    try
                    {
                        //pegar acessos selecionados
                        var deserialize = new JavaScriptSerializer();
                        _checkedNodes = deserialize.Deserialize<List<JQTreeNode>>(model.CheckBoxesTreeView_checkedState);

                        //Deletar todos os acessos do usuários
                        _unitOfWork.ModuleUserAccessRepository.DbSet.RemoveRange(
                            _unitOfWork.ModuleUserAccessRepository.DbSet.Where(a => a.UserId == model.UserId));

                        //Inserindo os novos acessos
                        foreach (var access in _checkedNodes.Select(chk => new ModuleUserAccess { ModuleId = int.Parse(chk.Value), UserId = model.UserId }))
                        {
                            _unitOfWork.ModuleUserAccessRepository.Insert(access);
                        }

                        //Salvar alterações
                        _unitOfWork.ModuleUserAccessRepository.Context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        TempData["error"] = "Erro ao efetuar a liberação dos módulos.";
                        return View();
                    }
                }
                else
                {
                    TempData["error"] = "Favor selecionar os módulos a serem liberados.";
                    return View(model);
                }
            }
            else
            {
                TempData["error"] = "Favor selecionar o usuário.";
                return View(model);
            }
            TempData["success"] = "Liberação efetuada com sucesso.";
            return View();
        }

        public JsonResult TreeView_CheckBoxes_DataRequested()
        {
            var tree = new JQTreeView();

            //var userId = User.Identity.GetUserId();
            var module = _unitOfWork.ModulesRepository.DbSet.Where(m => m.ParentModuleId == null).ToList();
            //from mod in _unitOfWork.ModulesRepository.DbSet
            //join modAccess in _unitOfWork.ModuleUserAccessRepository.DbSet on mod.ModuleId equals modAccess.ModuleId
            //where modAccess.UserId == userId
            //select mod;
            //var module = mod.ToList();
            var nodes = new List<JQTreeNode>();
            foreach (var mod in module)
            {
                nodes.Add(new JQTreeNode
                {
                    Text = mod.ModuleName,
                    Value = mod.ModuleId.ToString(CultureInfo.InvariantCulture),
                    Expanded = true
                });

                foreach (var subMod in mod.SubModules)
                {
                    var secondNode = nodes.Find(n => n.Text == mod.ModuleName);
                    secondNode.Nodes.Add(new JQTreeNode { Text = subMod.ModuleName, Value = subMod.ModuleId.ToString(CultureInfo.InvariantCulture) });
                }
            }

            SetCheckedNodes(nodes);

            return tree.DataBind(nodes);
        }

        public void SetCheckedNodes(List<JQTreeNode> allNodes)
        {
            var checkedNodes = Session["checkedNodes"] as List<JQTreeNode>;
            if (checkedNodes != null)
            {
                var tree = new JQTreeView();
                var allNodesFlat = tree.GetAllNodesFlat(allNodes);

                foreach (JQTreeNode node in allNodesFlat)
                {
                    var matchedCheckedNode =
                        checkedNodes.Find(checkedNode => checkedNode.Value == node.Value);
                    if (matchedCheckedNode != null)
                        node.Checked = true;
                }
            }
        }
    }
}
