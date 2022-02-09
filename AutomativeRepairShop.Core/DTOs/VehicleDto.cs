using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class VehicleDto:Dto
    {
        [DisplayName("Plaka")]
        public string LicensePlate { get; set; }

        [DisplayName("Marka")]
        public string Brand { get; set; }

        [DisplayName("Model")]
        public string Model { get; set; }

        [DisplayName("Model Yılı")]
        public int Year { get; set; }
        public int CustomerId { get; set; }

        [DisplayName("Müşteri Adı")]
        public string CustomerName { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
    }
}
