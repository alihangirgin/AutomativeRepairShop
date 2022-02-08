using AutomativeRepairShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int id);
        CustomerDto AddCustomer(CustomerDto newCustomer);
        CustomerDto UpdateCustomer(CustomerDto updatedCustomer, int id);
        void DeleteCustomer(int id);
    }
}
