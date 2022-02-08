using AutomativeRepairShop.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Services
{
    public interface ICustomerService
    {
        List<SelectListItem> GetCustomerSelectList();
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int id);
        CustomerDto AddCustomer(CustomerDto newCustomer);
        CustomerDto UpdateCustomer(CustomerDto updatedCustomer, int id);
        void DeleteCustomer(int id);
    }
}
