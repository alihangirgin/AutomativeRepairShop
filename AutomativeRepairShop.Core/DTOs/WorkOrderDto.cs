using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class WorkOrderDto:Dto
    {
        public int AppointmentId { get; set; }
        public int VehicleId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CustomerName { get; set; }
        public string VehicleName { get; set; }
    }
}
