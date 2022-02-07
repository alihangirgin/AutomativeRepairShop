using AutomativeRepairShop.Core.Repositories;
using AutomativeRepairShop.Core.UnitOfWork;
using AutomativeRepairShop.Data.DataAccess;
using AutomativeRepairShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArsDbContext _context;

        private AppointmentRepository _appointmentRepository;
        private CustomerRepository _customerRepository;
        private VehicleRepository _vehicleRepository;
        private WorkOrderRepository _workOrderRepository;

        public UnitOfWork(ArsDbContext context)
        {
            _context = context;
        }

        public IAppointmentRepository Appointments => _appointmentRepository = _appointmentRepository ?? new AppointmentRepository(_context);
        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);
        public IVehicleRepository Vehicles => _vehicleRepository = _vehicleRepository ?? new VehicleRepository(_context);
        public IWorkOrderRepository WorkOrders => _workOrderRepository = _workOrderRepository ?? new WorkOrderRepository(_context);


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
