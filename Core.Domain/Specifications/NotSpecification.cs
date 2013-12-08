using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Damain.Specifications
{
    public class NotSpecification : Specification
    {
        private readonly Specification _specification;

        public NotSpecification(Specification specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return !_specification.IsSatisfiedBy(product);
        }
    }
}