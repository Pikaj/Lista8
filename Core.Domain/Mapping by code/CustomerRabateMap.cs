using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Core.Domain
{
    public class CustomerRabateMap :ClassMapping<CustomerRabate>
    {
        public CustomerRabateMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Name, n => n.Column("Name"));
            Property(x => x.Percent, n => n.Column("PercentRabate"));
            Bag<Customer>(x => x.Customers, 
                 x => 
                {
                    x.Cascade(Cascade.All);
                    x.Key(k => k.Column("ID_Rabate"));
                }, 
                y => y.OneToMany(x => x.Class(typeof(Customer))));
        }
    }
}
