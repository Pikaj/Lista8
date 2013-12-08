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
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Quantity, n => n.Column("Quantity"));
            ManyToOne<Category>(x => x.Category, n => 
                {
                    n.Column("ID_Category");
                    n.Cascade(Cascade.All);
                });
            Component(x => x.ProductData, m =>
            {
                m.Property(x => x.Name, n => n.Column("Name"));
                m.Property(x => x.Price, n => n.Column("Price"));
                m.Component(x => x.Description, j =>
                {
                    j.Property(x => x.Description, n => n.Column("Description"));
                });
            });
            Bag<ElementOrder>(x => x.ElementsOrder,
                x =>
                {
                    x.Cascade(Cascade.All);
                    x.Key(k => k.Column("ID_Product"));
                },
                y => y.OneToMany(x => x.Class(typeof(ElementOrder))));
        }
    }
}
