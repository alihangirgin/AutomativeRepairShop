using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Models
{
    public class WorkOrder:Entity
    {
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
