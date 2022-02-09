using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class WorkOrderWithoutAppointmentDto:WorkOrderDto
    {
        [DisplayName("Müşteri")]
        public int CustomerId { get; set; }

        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> VehicleList { get; set; }
    }
}
