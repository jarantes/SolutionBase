using System.Collections.Generic;
using System.Linq;
using WEB_BASE.DataContexts;
using WEB_BASE.Models;

namespace WEB_BASE.Repository
{
    public class UnitOfWork
    {
        //Instanciando o Contexto da Aplicação
        private readonly ApplicationDb _ctx = new ApplicationDb();

        //Declarando as Entidades com Propriedades
        private GenericRepository<Product> _productsRepository;
        private GenericRepository<ProductCategory> _productsCategoryRepository;
        private GenericRepository<Module> _modulesRepository;
        private GenericRepository<ModuleUserAccess> _modulesUserAccessRepository; 

        public GenericRepository<Product> ProductsRepository
        {
            get { return _productsRepository ?? 
                        (_productsRepository = new GenericRepository<Product>(_ctx)); }
        }

        public GenericRepository<ProductCategory> ProductsCategoryRepository
        {
            get
            {
                return _productsCategoryRepository ??
                       (_productsCategoryRepository = new GenericRepository<ProductCategory>(_ctx));
            }
        }

        public GenericRepository<Module> ModulesRepository
        {
            get
            {
                return _modulesRepository ??
                       (_modulesRepository = new GenericRepository<Module>(_ctx));
            }
        }

        public GenericRepository<ModuleUserAccess> ModuleUserAccessRepository
        {
            get
            {
                return _modulesUserAccessRepository ??
                       (_modulesUserAccessRepository = new GenericRepository<ModuleUserAccess>(_ctx));
            }
        }

        public bool ValidUserAccess(List<Module> access , string action, string controller, string userId)
        {
            if (access == null)
            {
                access = GetAllAccessUser(userId);
            }
            return access.Any(a => a.Action == action && a.Controller == controller);
        }

        public List<Module> GetAllAccessUser(string userId)
        {
             var query =from mod in ModulesRepository.DbSet
                   join modAccess in ModuleUserAccessRepository.DbSet on mod.ModuleId equals
                       modAccess.ModuleId
                   where modAccess.UserId == userId
                   select mod;
            return query.ToList();
        }
    }
}