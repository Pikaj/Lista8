using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public interface IProductRepository
    {
        // Product
        void InsertProduct(int CategoryId, Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product RetrieveProduct(int id);
        List<Product> RetrieveAllProducts(int CategoryId);
    }
}
