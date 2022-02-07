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
    public class VehicleMap:Mapping<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.LicensePlate).IsRequired().HasMaxLength(30); ;
            builder.Property(x => x.Brand).IsRequired().HasMaxLength(100); ;
            builder.Property(x => x.Model).IsRequired().HasMaxLength(30); ;
            builder.Property(x => x.Year);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
