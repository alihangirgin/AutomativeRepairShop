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
    public class VehicleDto:Dto
    {
        [DisplayName("Plaka")]
        [Required(ErrorMessage = "Plaka gerekli")]
        public string LicensePlate { get; set; }

        [DisplayName("Marka")]
        [Required(ErrorMessage = "Marka gerekli")]
        public string Brand { get; set; }

        [DisplayName("Model")]
        [Required(ErrorMessage = "Model gerekli")]
        public string Model { get; set; }

        [DisplayName("Model Yılı")]
        [Required(ErrorMessage = "Model Yılı gerekli")]
        public int Year { get; set; }
        public int CustomerId { get; set; }

        [DisplayName("Müşteri Adı")]
        public string CustomerName { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
    }
}
