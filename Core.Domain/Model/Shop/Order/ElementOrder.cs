using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class ElementOrder
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}