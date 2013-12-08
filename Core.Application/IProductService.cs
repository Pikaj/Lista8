using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Model.Shop;

namespace Core.Application
{
    public interface IProductService
    {
        Product CreateNewProduct(ProductData Data, DateTime issueDate, int quantity);
        Category CreateNewCategory(string name, List<Product> Products);

        ProductData CreateNewProductDate(string name, float price, ProductDescription Description);
        ProductDescription CreateNewProductDescription(string name);


        List<Product> FindAllProducts(int CategoryId);
        List<Category> FindAllCategories();
    }
}
