using AutomativeRepairShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Services
{
    public interface IWorkOrderService
    {
        IEnumerable<WorkOrderDto> GetAllWorkOrders();
        WorkOrderDto AddWorkOrderWithAppointment(WorkOrderDto newWorkOrder);
        WorkOrderDto AddWorkOrderWithoutAppointment(WorkOrderWithoutAppointmentDto newWorkOrder);
        void DeleteWorkOrder(int id);
    }
}
