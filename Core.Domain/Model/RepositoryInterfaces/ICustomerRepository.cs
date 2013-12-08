using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Shop
{
    public interface ICustomerRepository
    {
        // Customer
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Customer RetrieveCustomer(int id);
        List<Customer> RetrieveAllCustomers();

    }
}
