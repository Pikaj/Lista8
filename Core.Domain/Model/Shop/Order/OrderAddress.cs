using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class OrderAddress
    {
        public virtual string Street { get; set; }
        public virtual string Number { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
    }
}
