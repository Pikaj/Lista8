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
    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Date, n => n.Column("Date"));
            Component(x => x.OrderAddress, m =>
            {
                m.Property(x => x.Street, n => n.Column("Street"));
                m.Property(x => x.Number, n => n.Column("Number"));
                m.Property(x => x.City, n => n.Column("City"));
                m.Property(x => x.PostalCode, n => n.Column("PostalCode"));
            });
            ManyToOne<Customer>(x => x.Customer, n =>
                {
                    n.Column("ID_Customer");
                    n.Cascade(Cascade.All);
                });
            Bag<ElementOrder>(x => x.ElementsOrder, 
                x => 
                {
                    x.Cascade(Cascade.All);
                    x.Key(k => k.Column("ID_Order"));
                }, 
                y => y.OneToMany(x => x.Class(typeof(ElementOrder))));
        }
    }
}
