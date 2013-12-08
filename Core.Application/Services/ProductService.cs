using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Application
{
    public class ProductService : IProductService
    {
        private IProductRepository ProductRepository;

        public ProductService()
        {
            throw new NotImplementedException();
        }

        public ProductService(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public Product CreateNewProduct(ProductData Data, DateTime issueDate, int quantity)
        {
            throw new NotImplementedException();
        }

        public Category CreateNewCategory(string name, List<Product> Products)
        {
            throw new NotImplementedException();
        }

        public ProductData CreateNewProductDate(string name, float price, ProductDescription Description)
        {
            throw new NotImplementedException();
        }

        public ProductDescription CreateNewProductDescription(string description)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAllProducts(int CategoryId)
        {
            return ProductRepository.RetrieveAllProducts(CategoryId);
        }

        public List<Category> FindAllCategories()
        {
            throw new NotImplementedException();
        }

    }
}
