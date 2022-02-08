using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class WorkOrderWithoutAppointmentDto:WorkOrderDto
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
    }
}
