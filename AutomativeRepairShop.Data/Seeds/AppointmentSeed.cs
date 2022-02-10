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

        }

    }
}
