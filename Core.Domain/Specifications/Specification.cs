using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Damain.Specifications
{
    public abstract class Specification
    {
        public abstract bool IsSatisfiedBy(Product product);
    }
}