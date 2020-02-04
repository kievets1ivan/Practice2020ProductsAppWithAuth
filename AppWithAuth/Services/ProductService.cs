using AppWithAuth.DataLayer;
using AppWithAuth.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithAuth.Services
{
    public class ProductService : IProductService
    {

        private readonly ProductContext _context;

        private readonly List<ProductEntity> _prodInternalStorage;
        private static int counter = 100;
        public ProductService(ProductContext context)
        {
            _context = context;

            /*_prodInternalStorage = new List<ProductEntity>();

            for(var i = 0; i < 5; i++)
            {
                _prodInternalStorage.Add(new ProductEntity { Id = i, Name = $"Me {i}" });
            }*/
        }

        public IEnumerable<ProductEntity> GetAllProds()
        {
            return _prodInternalStorage;
        }

        public ProductEntity GetProdById(int productId)
        {
            return _prodInternalStorage.SingleOrDefault(product => product.Id == productId);
        }

        public ProductEntity AddProd(ProductEntity newProd)
        {
            /*if (newProd == null)
                throw new ArgumentNullException(nameof(newProd));
                */

            newProd.Id = counter++;
            newProd.Name = $"Me {newProd.Id}";


            _prodInternalStorage.Add(newProd);


            return GetProdById(newProd.Id);
        }

        public bool DeleteProd(int id)
        {
            var product = GetProdById(id);

            if (product == null)
                return false;

            _prodInternalStorage.Remove(product);

            return true;
        }

        public bool UpdateProd(ProductEntity productUpdated)
        {

            if (GetProdById(productUpdated.Id) == null)
                return false;

            var index = _prodInternalStorage.FindIndex(x => x.Id == productUpdated.Id);
            _prodInternalStorage[index] = productUpdated;
            return true;
        }
    }
}
