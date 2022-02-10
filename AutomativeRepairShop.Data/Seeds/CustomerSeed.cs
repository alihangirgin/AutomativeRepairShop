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
    internal class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        private readonly int[] _ids;

        public CustomerSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer { Id = _ids[0], Name = "Mülayim", Surname = "Sert", Email = "mulayimsert@gmail.com", PhoneNumber = "12345", CreateDate = DateTime.Now },
            new Customer { Id = _ids[1], Name = "Keanu", Surname = "Reeves", Email = "keanureeves@gmail.com", PhoneNumber = "12345", CreateDate = DateTime.Now },
            new Customer { Id = _ids[2], Name = "Donald", Surname = "Trump", Email = "donaldtrump@gmail.com", PhoneNumber = "12345", CreateDate = DateTime.Now },
            new Customer { Id = _ids[3], Name = "Testere", Surname = "Necmi", Email = "testerenecmi@gmail.com", PhoneNumber = "12345", CreateDate = DateTime.Now },
            new Customer { Id = _ids[4], Name = "Bugs", Surname = "Bunny", Email = "bugsbunny@gmail.com", PhoneNumber = "12345", CreateDate = DateTime.Now });
        }
    }
}
