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
    internal class VehicleSeed : IEntityTypeConfiguration<Vehicle>
    {
        private readonly int[] _ids;

        public VehicleSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(new Vehicle { Id = _ids[0], Brand = "Audi", Model = "A3 Sedan", LicensePlate = "34 ABC 123", Year = 2020, CustomerId = 1, CreateDate = DateTime.Now },
            new Vehicle { Id = _ids[1], Brand = "Fiat", Model = "Egea", LicensePlate = "34 DSA 123", Year = 2018, CustomerId = 2, CreateDate = DateTime.Now },
            new Vehicle { Id = _ids[2], Brand = "Honda", Model = "City", LicensePlate = "34 FSD 123", Year = 2017, CustomerId = 2, CreateDate = DateTime.Now },
            new Vehicle { Id = _ids[3], Brand = "Mercedes", Model = "A Serisi", LicensePlate = "34 HDS 123", Year = 2021, CustomerId = 3, CreateDate = DateTime.Now });
        }
    }
}
