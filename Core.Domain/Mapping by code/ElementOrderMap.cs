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
    public class ElementOrderMap : ClassMapping<ElementOrder>
    {
        public ElementOrderMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Quantity, m => m.Column("Quantity"));
            ManyToOne<Order>(x => x.Order, n =>
                {
                    n.Column("ID_Order");
                    n.Cascade(Cascade.All);
                });
            ManyToOne<Product>(x => x.Product, n =>
                {
                    n.Column("ID_Product");
                    n.Cascade(Cascade.All);
                });
        }
    }
}
