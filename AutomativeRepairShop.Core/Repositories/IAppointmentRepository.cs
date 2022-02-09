using AutomativeRepairShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Repositories
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllRealAppointments(string includeOne, string includeTwo);
    }
}
