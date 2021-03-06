using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class AppointmentDto:Dto
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        [DisplayName("Randevu Tarihi")]
        [Required(ErrorMessage = "Randevu Tarihi gerekli")]
        public DateTime? AppointmentDate { get; set; }

        [DisplayName("Randevu Onayı")]
        public bool isApproved { get; set; }

        [DisplayName("Müşteri Adı")]
        public string CustomerName { get; set; }

        [DisplayName("Araç Bilgisi")]
        public string VehicleName { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> VehicleList { get; set; }
    }
}
