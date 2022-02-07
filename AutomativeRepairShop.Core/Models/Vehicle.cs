using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Models
{
    public class Vehicle:Entity
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
