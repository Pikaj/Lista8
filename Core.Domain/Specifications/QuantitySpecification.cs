using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Damain.Specifications
{
    public class QuantitySpecification : Specification
    {
        private readonly int _productQuantity;

        public QuantitySpecification(int productQuantity)
        {
            _productQuantity = productQuantity;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Quantity.Equals(_productQuantity);
        }
    }
}