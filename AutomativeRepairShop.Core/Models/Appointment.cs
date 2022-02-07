using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Models
{
    public class Appointment:Entity
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public bool isApproved { get; set; }
        public bool isReal { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
