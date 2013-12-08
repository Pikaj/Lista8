using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Shop;

namespace Core.Application
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository CustomerRepository;

        public CustomerService()
        {
            throw new NotImplementedException();
        }

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        public Customer CreateNewCustomer(CustomerData Data, List<CustomerRabate> Rabates, List<Order> Orders)
        {
            throw new NotImplementedException();
        }

        public CustomerData CreateNewCustomerData(CustomerAddress Address, string name, string surname)
        {
            throw new NotImplementedException();
        }

        public CustomerRabate CreateNewRabate(float percent, string name)
        {
            throw new NotImplementedException();
        }

        public CustomerAddress CreateNewAddressCustomer(string street, string number, string city, string postalCode)
        {
            throw new NotImplementedException();
        }

        public List<Customer> FindAllCustomers()
        {
            return CustomerRepository.RetrieveAllCustomers();
        }

        public List<CustomerRabate> FindAllRabate()
        {
            throw new NotImplementedException();
        }

    }
}
