using WEB_BASE.DataContexts;
using WEB_BASE.Models;

namespace WEB_BASE.Repository
{
    public class UnitOfWork
    {
        //Instanciando o Contexto da Aplicação
        private readonly ApplicationDb _ctx = new ApplicationDb();

        //Declarando as Entidades com Propriedades
        private GenericRepository<ProductModels> _productsRepository;
        private GenericRepository<ProductCategoryModels> _productsCategoryRepository;

        public GenericRepository<ProductModels> ProductsRepository
        {
            get { return _productsRepository ?? 
                        (_productsRepository = new GenericRepository<ProductModels>(_ctx)); }
        }

        public GenericRepository<ProductCategoryModels> ProductsCategoryRepository
        {
            get
            {
                return _productsCategoryRepository ??
                       (_productsCategoryRepository = new GenericRepository<ProductCategoryModels>(_ctx));
            }
        }

    }
}