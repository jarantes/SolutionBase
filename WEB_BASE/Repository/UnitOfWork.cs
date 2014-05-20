using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using WEB_BASE.Models;

namespace WEB_BASE.Repository
{
    public class UnitOfWork
    {
        //Instanciando o Contexto da Aplicação
        private readonly ApplicationFullContext _ctx = new ApplicationFullContext();

        //Declarando as Entidades com Propriedades
        private GenericRepository<ProductsModels> _productsRepository;
        private GenericRepository<ProductsCategoryModels> _productsCategoryRepository;

        public GenericRepository<ProductsModels> ProductsRepository
        {
            get { return _productsRepository ?? 
                        (_productsRepository = new GenericRepository<ProductsModels>(_ctx)); }
        }

        public GenericRepository<ProductsCategoryModels> ProductsCategoryRepository
        {
            get
            {
                return _productsCategoryRepository ??
                       (_productsCategoryRepository = new GenericRepository<ProductsCategoryModels>(_ctx));
            }
        }

    }
}