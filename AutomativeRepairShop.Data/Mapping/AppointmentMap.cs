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
    public class AppointmentMap:Mapping<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.AppointmentDate);
            builder.Property(x => x.isApproved);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.VehicleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
