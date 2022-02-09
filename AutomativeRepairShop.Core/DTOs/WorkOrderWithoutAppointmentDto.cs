using Microsoft.AspNetCore.Mvc.Rendering;
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
        //public int VehicleId { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> VehicleList { get; set; }
    }
}
