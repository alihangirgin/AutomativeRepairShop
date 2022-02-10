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
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
       
        public VehicleRepository(ArsDbContext context) : base(context)
        {

        }
        public IEnumerable<Vehicle> GetAllWithIncludes(int id)
        {
            return _dbSet.Where(x => x.CustomerId == id)
               .Include(x => x.Appointments)
               .ThenInclude(x => x.WorkOrders).ToList();
        }

    }
}
