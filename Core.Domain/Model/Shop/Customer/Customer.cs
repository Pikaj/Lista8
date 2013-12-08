using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class Customer
    {
        public virtual int Id { get; set; }

        public virtual IList<Order> Orders { get; set; }
        public virtual CustomerData CustomerData { get; set; }
        public virtual CustomerRabate Rabate { get; set; }
    }
}
