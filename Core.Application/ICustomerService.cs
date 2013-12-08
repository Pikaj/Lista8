using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Model.Shop;

namespace Core.Application
{
    public interface ICustomerService
    {
        Customer CreateNewCustomer(CustomerData Data, List<CustomerRabate> Rabates, List<Order> Orders);

        CustomerData CreateNewCustomerData(CustomerAddress Address, string name, string surname);
        CustomerRabate CreateNewRabate(float percent, string name);
        CustomerAddress CreateNewAddressCustomer(string street, string number, string city, string postalCode);

        List<Customer> FindAllCustomers();
        List<CustomerRabate> FindAllRabate();
    }
}
