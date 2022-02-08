using AutoMapper;
using AutomativeRepairShop.Core.DTOs;
using AutomativeRepairShop.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            var customerResource = _customerService.GetAllCustomers();
            return View(customerResource);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDto newCustomer)
        {
            _customerService.AddCustomer(newCustomer);
            return RedirectToAction("CustomerList");
        }

        public IActionResult UpdateCustomer(int id)
        {
            var customer= _customerService.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerDto customerDto, int id)
        {
            _customerService.UpdateCustomer(customerDto, id);
            return RedirectToAction("CustomerList");
        }

        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("CustomerList");
        }

    }
}
