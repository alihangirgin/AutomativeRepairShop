using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class WorkOrderDto:Dto
    {
        public int AppointmentId { get; set; }

        [DisplayName("Araç")]
        public int VehicleId { get; set; }

        [DisplayName("Randevu Tarihi")]
        public DateTime? AppointmentDate { get; set; }

        [DisplayName("Müşteri Adı")]
        public string CustomerName { get; set; }

        [DisplayName("Araç Bilgisi")]
        public string VehicleName { get; set; }
    }
}
