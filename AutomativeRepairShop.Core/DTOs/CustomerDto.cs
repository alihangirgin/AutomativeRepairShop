using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs
{
    public class CustomerDto:Dto
    {
        [DisplayName("Adı")]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        public string Surname { get; set; }

        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-Posta")]
        public string Email { get; set; }
    }
}
