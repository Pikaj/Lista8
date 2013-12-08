using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }

        public virtual ProductData ProductData { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<ElementOrder> ElementsOrder { get; set; }
    }
}
