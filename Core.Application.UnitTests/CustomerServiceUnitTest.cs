using System;
using Core.Application;
using Core.Domain.Model.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Core.Application.UnitTests
{
    [TestClass]
    public class CustomerServiceUnitTest
    {
        [TestMethod]
        public void CheckCreateCustomer()
        {
            // Arrange
            ICustomerService cs = new CustomerService();
            
            var ac = cs.CreateNewAddressCustomer("street", "50", "Wro", "00-000");
            var d = cs.CreateNewCustomerData(ac, "Name", "Surname");
            var c = cs.CreateNewCustomer(d, new List<CustomerRabate>(), new List<Order>());

            // Act
            Customer retrieved = cs.FindAllCustomers().Find((x) => x.Id == c.Id);

            // Assert
            Assert.AreEqual(c, retrieved);
            Assert.AreEqual(c.CustomerData, retrieved.CustomerData);
            Assert.AreEqual(c.CustomerData.CustomerAddress, retrieved.CustomerData.CustomerAddress);
        }
    }
}
