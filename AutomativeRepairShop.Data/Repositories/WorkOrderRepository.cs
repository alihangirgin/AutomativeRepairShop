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
    public class WorkOrderRepository: Repository<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(ArsDbContext context) : base(context)
        {

        }

        public IEnumerable<WorkOrder> GetAllWithIncludes()
        {
            return _dbSet.Where(x => x.DeleteDate == null).Include(x=>x.Appointment).ThenInclude(x=>x.Customer).ThenInclude(x=>x.Vehicles).ToList();
        }
    }
}
