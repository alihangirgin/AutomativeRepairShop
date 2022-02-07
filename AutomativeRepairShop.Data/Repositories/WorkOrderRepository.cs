using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Repositories;
using AutomativeRepairShop.Data.DataAccess;
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
    }
}
