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

        public void DeleteAllByCustomerId(int id)
        {
            _dbSet.Where(x => x.CustomerId == id)
                .Include(x => x.Appointments)
                .ThenInclude(x => x.WorkOrders)
                .ForEachAsync(vehicle =>
                {
                    vehicle.DeleteDate = DateTime.Now;

                    foreach (var appointment in vehicle.Appointments )
                    {
                        appointment.DeleteDate = DateTime.Now;

                        foreach (var workOrder in appointment.WorkOrders)
                        {
                            workOrder.DeleteDate = DateTime.Now;
                        }
                    }

                    
                });
        }
    }
}
