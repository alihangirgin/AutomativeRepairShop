using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Repositories;
using AutomativeRepairShop.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.Repositories
{
    public class AppointmentRepository: Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ArsDbContext context) : base(context)
        {

        }
        public IEnumerable<Appointment> GetAllRealAppointments(string includeOne, string includeTwo)
        {
            return _dbSet.Where(x => x.DeleteDate == null && x.AppointmentDate !=null).Include(includeOne).Include(includeTwo).ToList();
        }
    }
}
