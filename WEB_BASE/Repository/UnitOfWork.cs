﻿using WEB_BASE.DataContexts;
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
    }
}