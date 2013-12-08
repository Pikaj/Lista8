using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Domain.Model.Shop
{
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
