using AutomativeRepairShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.Mapping
{
    public class WorkOrderMap:Mapping<WorkOrder>
    {
        public override void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Appointment)
                .WithMany(x => x.WorkOrders)
                .HasForeignKey(x => x.AppointmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
