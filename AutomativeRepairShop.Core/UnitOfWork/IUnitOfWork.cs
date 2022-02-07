using AutomativeRepairShop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        ICustomerRepository Customers { get; }
        IVehicleRepository Vehicles { get; }
        IWorkOrderRepository WorkOrders { get; }
        int Commit();
    }
}
