using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string Date { get; set; }
        public virtual OrderAddress OrderAddress { get; set; }
        public virtual IList<ElementOrder> ElementsOrder { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
