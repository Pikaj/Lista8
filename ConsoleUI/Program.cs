using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application;
using Core.Domain.Model.Shop;


namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICustomerService customers = new CustomerService();
            var result = customers.FindAllCustomers();

           Console.Read();
        }
    }
}
