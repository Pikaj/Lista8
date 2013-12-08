using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Domain.Model.Shop;
using Core.ObjectsMother;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;


namespace Core.Infrastructure.UnitTests
{

    [TestClass]
    public class ShopRepositoryUnitTest
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


            cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), null);

            new SchemaExport(cfg).Execute(true, true, false);
            sessionFactory = cfg.BuildSessionFactory();

            Shop = new ShopObjectMother();
        }
        
        [TestMethod]
        public void InsertCustomer()
        {
            sessionFactory = cfg.BuildSessionFactory();
            using (ISession session = sessionFactory.OpenSession())
            {
                var customer = Shop.CreateShopCustomerWithOrders("FirstTest");
                session.Save(customer);
            }
        }
    }
}
