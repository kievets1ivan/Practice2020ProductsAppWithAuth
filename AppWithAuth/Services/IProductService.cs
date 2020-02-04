using AppWithAuth.Entity;
using System.Collections.Generic;

namespace AppWithAuth.Services
{
    public interface IProductService
    {
        ProductEntity AddProd(ProductEntity newProd);
        bool UpdateProd(ProductEntity productToUpdate);
        bool DeleteProd(int id);
        IEnumerable<ProductEntity> GetAllProds();
        ProductEntity GetProdById(int id);
    }
}