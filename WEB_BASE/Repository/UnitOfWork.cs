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

    }
}