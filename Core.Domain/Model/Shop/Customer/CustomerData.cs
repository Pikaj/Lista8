using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public class CustomerData
    {
        public virtual int Id { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }
    }
}
