using AutomativeRepairShop.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Services
{
    public interface IAppointmentService
    {
        List<SelectListItem> GetAppointmentSelectList();
        AppointmentDto GetAppointmentById(int id);
        IEnumerable<AppointmentDto> GetAllAppointments();
        AppointmentDto AddAppointment(AppointmentDto newAppointment);
        AppointmentDto UpdateAppointment(AppointmentDto updatedAppointment, int id);
        void DeleteAppointment(int id);
    }
}
