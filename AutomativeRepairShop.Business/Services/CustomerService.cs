using AutoMapper;
using AutomativeRepairShop.Core.DTOs;
using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Services;
using AutomativeRepairShop.Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<SelectListItem> GetCustomerSelectList()
        {
            var selectList = new List<SelectListItem>();
            GetAllCustomers().ToList().ForEach(x =>
            {
                selectList.Add(new SelectListItem()
                {
                    Text = x.Name + " " + x.Surname,
                    Value = x.Id.ToString()
                });

            });

            return selectList;
        }


        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customerList = _unitOfWork.Customers.GetAll();
            var customerListResource = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customerList);
            return customerListResource;
        }

        public CustomerDto GetCustomerById(int id)
        {
            return _mapper.Map<Customer, CustomerDto>(_unitOfWork.Customers.GetById(id));
        }

        public CustomerDto AddCustomer(CustomerDto newCustomer)
        {
            var newCustomerEntity = _mapper.Map<CustomerDto, Customer>(newCustomer);
            _unitOfWork.Customers.Add(newCustomerEntity);
            _unitOfWork.Commit();
            return newCustomer;
        }

        public CustomerDto UpdateCustomer(CustomerDto updatedCustomer, int id)
        {
            var customerEntityToBeUpdated = _unitOfWork.Customers.GetById(id);
            customerEntityToBeUpdated.Name = updatedCustomer.Name;
            customerEntityToBeUpdated.Surname = updatedCustomer.Surname;
            customerEntityToBeUpdated.Email = updatedCustomer.Email;
            customerEntityToBeUpdated.PhoneNumber = updatedCustomer.PhoneNumber;
            var updatedEntity = _unitOfWork.Customers.Update(customerEntityToBeUpdated);
            _unitOfWork.Commit();
            return _mapper.Map<Customer, CustomerDto>(updatedEntity);
        }

        public void DeleteCustomer(int id)
        {
            //delete fk's also
            var vehicleList = _unitOfWork.Vehicles.GetAllWithIncludes(id);
            if (vehicleList != null)
            {
                foreach (var vehicle in vehicleList)
                {
                    foreach (var appointment in vehicle.Appointments)
                    {
                        if (appointment != null)
                        {
                            foreach (var workOrder in appointment.WorkOrders)
                            {
                                _unitOfWork.WorkOrders.Delete(workOrder.Id);
                            }
                            _unitOfWork.Appointments.Delete(appointment.Id);
                        }
                    }
                    _unitOfWork.Vehicles.Delete(vehicle.Id);
                }
            }
            _unitOfWork.Customers.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
