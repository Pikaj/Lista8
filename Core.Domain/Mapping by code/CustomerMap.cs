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
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Component(x => x.CustomerData, m =>
            {
                m.Property(x => x.Firstname, n => n.Column("Firstname"));
                m.Property(x => x.Lastname, n => n.Column("Lastname"));
                m.Component(x => x.CustomerAddress, j =>
                {
                    j.Property(x => x.Street, n => n.Column("Street"));
                    j.Property(x => x.Number, n => n.Column("Number"));
                    j.Property(x => x.City, n => n.Column("City"));
                    j.Property(x => x.PostalCode, n => n.Column("PostalCode"));
                });
            });
            ManyToOne<CustomerRabate>(x => x.Rabate, n =>
                {
                    n.Column("ID_Rabate");
                    n.Cascade(Cascade.All);
                });
            Bag<Order>(x => x.Orders,
                 x =>
                 {
                     x.Cascade(Cascade.All);
                     x.Key(k => k.Column("ID_Customer"));
                 }, 
                 y => y.OneToMany(x => x.Class(typeof(Order))));
        }
    }
}
