using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Damain.Specifications
{
    public class CategorySpecification : Specification
    {
        private readonly Category _productCategory;

        public CategorySpecification(Category productCategory)
        {
            _productCategory = productCategory;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Category.Equals(_productCategory);
        }
    }
}