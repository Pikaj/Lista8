using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class ProductData
    {
        public virtual string Name { get; set; }
        public virtual float Price { get; set; }
        public virtual ProductDescription Description { get; set; }
    }
}
