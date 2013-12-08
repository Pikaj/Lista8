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
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Name, n => n.Column("Name"));
            Bag<Product>(x => x.Products, 
                 x => 
                {
                    x.Cascade(Cascade.All);
                    x.Key(k => k.Column("ID_Category"));
                }, 
                y => y.OneToMany(x => x.Class(typeof(Product))));
        }
    }
}
