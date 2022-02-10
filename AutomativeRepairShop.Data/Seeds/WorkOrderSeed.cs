using AutomativeRepairShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.Seeds
{
    internal class WorkOrderSeed : IEntityTypeConfiguration<WorkOrder>
    {
        private readonly int[] _ids;

        public WorkOrderSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {

        }
    }
}
