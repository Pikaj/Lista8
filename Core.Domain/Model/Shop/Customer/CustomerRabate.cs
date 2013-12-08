using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class CustomerRabate
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual float Percent { get; set; }
        public virtual IList<Customer> Customers { get; set; }
    }
}
