using AutoMapper;
using AutomativeRepairShop.Core.DTOs;
using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Services;
using AutomativeRepairShop.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Business.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customerList = _unitOfWork.Customers.GetAll();
            var customerListResource = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customerList);
            return customerListResource;
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

        public void DeleteCustomer (int id)
        {
            _unitOfWork.Customers.Delete(id);
            //delete fk's also (vehicle,appointment plus appointment's work order)
            var vehicleList = _unitOfWork.Vehicles.GetAll(x => x.CustomerId == id && x.DeleteDate == null);
            var appointmentList = _unitOfWork.Appointments.GetAll(x => x.CustomerId == id && x.DeleteDate == null);

            _unitOfWork.Vehicles.DeleteAllEntities(vehicleList);
            _unitOfWork.Appointments.DeleteAllEntities(appointmentList);
            _unitOfWork.Commit();
        }
    }
}
