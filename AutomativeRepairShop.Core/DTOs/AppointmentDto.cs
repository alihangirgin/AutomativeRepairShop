using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class AppointmentDto:Dto
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public bool isApproved { get; set; }
        public bool isReal { get; set; }
    }
}
