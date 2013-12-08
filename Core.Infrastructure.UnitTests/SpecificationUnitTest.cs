using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Domain.Model.Shop;
using Core.Damain.Specifications;
using Core.ObjectsMother;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;


namespace Core.Infrastructure.UnitTests
{

    [TestClass]
    public class SpecificationUnitTest
    {
        private static ISessionFactory sessionFactory;
        private static Configuration cfg;
        private static ShopObjectMother Shop;

        [ClassInitialize]
        public static void CreateSchema(TestContext t)
        {
            cfg = new Configuration();
            var mapper = new ModelMapper();
            cfg.DataBaseIntegration(db =>
            {
                db.LogSqlInConsole = true;
                db.LogFormattedSql = true;
            });
            cfg.Configure();
            #region AddMappings: Category, Customer, CustomerRabate, ElementOrder, Order, Product
            mapper.AddMappings(
                System.Reflection.Assembly.GetAssembly(
                    typeof(Core.Domain.Model.Shop.Category)).GetExportedTypes());
            mapper.AddMappings(
                System.Reflection.Assembly.GetAssembly(
                    typeof(Core.Domain.Model.Shop.Customer)).GetExportedTypes());
            mapper.AddMappings(
                 System.Reflection.Assembly.GetAssembly(
                     typeof(Core.Domain.Model.Shop.CustomerRabate)).GetExportedTypes());
            mapper.AddMappings(
                System.Reflection.Assembly.GetAssembly(
                    typeof(Core.Domain.Model.Shop.ElementOrder)).GetExportedTypes());
            mapper.AddMappings(
                System.Reflection.Assembly.GetAssembly(
                    typeof(Core.Domain.Model.Shop.Order)).GetExportedTypes());
            mapper.AddMappings(
                System.Reflection.Assembly.GetAssembly(
                    typeof(Core.Domain.Model.Shop.Product)).GetExportedTypes());
            #endregion

            cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), null);

            new SchemaExport(cfg).Execute(true, true, false);
            sessionFactory = cfg.BuildSessionFactory();

            Shop = new ShopObjectMother();
            SetupDatabase();
        }

        [TestMethod]
        public static void SetupDatabase()
        {
             using (ISession session = sessionFactory.OpenSession())
            {
                 for (int i = 0; i < 10; i++)
                 {
                     Shop.Phrase = (i%5).ToString();
                     var product = Shop.CreateProduct(i%5, (float)(i+1));
                     session.Save(product);
                 }
            }
        }
        
        [TestMethod]
        public void TestQuantitySpecification()
        {
            sessionFactory = cfg.BuildSessionFactory();
            using (ISession s = sessionFactory.OpenSession())
            {
                QuantitySpecification qs = new QuantitySpecification(0);
                var q = (from product in s.Query<Product>()
                            select product).ToList();
                var list = q.Where(z => qs.IsSatisfiedBy(z));

                Assert.AreEqual(2, list.Count());
                s.Flush();
            }
        }
        
        [TestMethod]
        public void TestPriceSpecification()
        {
            sessionFactory = cfg.BuildSessionFactory();
            using (ISession s = sessionFactory.OpenSession())
            {
                PriceSpecification qs = new PriceSpecification(2.0f);
                var q = (from product in s.Query<Product>()
                         select product).ToList();
                var list = q.Where(z => qs.IsSatisfiedBy(z));

                Assert.AreEqual(1, list.Count());
                s.Flush();
            }
        }
        
        [TestMethod]
        public void TestCategorySpecification()
        {
            sessionFactory = cfg.BuildSessionFactory();
            using (ISession s = sessionFactory.OpenSession())
            {
                var cat_list = (from category in s.Query<Category>()
                                where category.Name == "Category 4"
                                select category).ToList();

                CategorySpecification qs = new CategorySpecification(cat_list.First());
                var q = (from product in s.Query<Product>()
                         select product).ToList();
                var list = q.Where(z => qs.IsSatisfiedBy(z));

                Assert.AreEqual(1, list.Count());
                s.Flush();
            }
        }
        
        [TestMethod]
        public void TestBelowPriceSpecification()
        {
            sessionFactory = cfg.BuildSessionFactory();
            using (ISession s = sessionFactory.OpenSession())
            {
                BelowPriceSpecification qs = new BelowPriceSpecification(5.5f);
                var q = (from product in s.Query<Product>()
                         select product).ToList();
                var list = q.Where(z => qs.IsSatisfiedBy(z));

                Assert.AreEqual(5, list.Count());
                s.Flush();
            }
        }

        [TestMethod]
        public void FindProductByBelowPriceAndQuantity()
        {
            sessionFactory = cfg.BuildSessionFactory();
            using (ISession s = sessionFactory.OpenSession())
            {
                BelowPriceSpecification bellowPriceSepec = new BelowPriceSpecification(3.5f);
                QuantitySpecification quantitySpec = new QuantitySpecification(2);
                OrSpecification orSpec = new OrSpecification(bellowPriceSepec, quantitySpec);

                var q = (from product in s.Query<Product>()
                         select product).ToList();
                var list = q.Where(z => orSpec.IsSatisfiedBy(z));

                Assert.AreEqual(4, list.Count());
                s.Flush();
            }
        }
        
    }
}
