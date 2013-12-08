using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Damain.Specifications
{
    public class OrSpecification : Specification
    {
        private readonly Specification _leftSpecification;

        private readonly Specification _rightSpecification;

        public OrSpecification(Specification leftSpecification, Specification rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return _leftSpecification.IsSatisfiedBy(product) || _rightSpecification.IsSatisfiedBy(product);
        }
    }
}