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
    internal class AppointmentSeed:IEntityTypeConfiguration<Appointment>
    {
        private readonly int[] _ids;

        public AppointmentSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasData(new Appointment { Id = _ids[0], VehicleId = 1, CustomerId = 1, AppointmentDate = DateTime.Now, CreateDate=DateTime.Now, isApproved = false },
                new Appointment { Id = _ids[1], VehicleId = 2, CustomerId = 2, AppointmentDate = null, CreateDate=DateTime.Now, isApproved = true },
                new Appointment { Id = _ids[2], VehicleId = 3, CustomerId = 2, AppointmentDate = DateTime.Now, CreateDate = DateTime.Now, isApproved = true });

        }

    }
}
