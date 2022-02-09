using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class CustomerDto:Dto
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "Adı gerekli")]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "Soyadı gerekli")]
        public string Surname { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Telefon gerekli")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-Posta")]
        [Required(ErrorMessage = "E-Posta Adresi gerekli")]
        [EmailAddress(ErrorMessage = "Geçersiz E-Posta")]
        public string Email { get; set; }
    }
}
