using AutomativeRepairShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Services
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDto> GetAllAppointments();
    }
}
