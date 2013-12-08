using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Damain.Specifications
{
    public class BelowPriceSpecification : Specification
    {
        private readonly float _price;

        public BelowPriceSpecification(float price)
        {
            _price = price;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.ProductData.Price < _price;
        }
    }
}