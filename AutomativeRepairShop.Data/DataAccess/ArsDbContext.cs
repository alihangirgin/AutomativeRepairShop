using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Data.DataAccess
{
    public class ArsDbContext : DbContext
    {
        public ArsDbContext() : base()
        {

        }
        public ArsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=AutomativeRepairShopDB; Trusted_Connection=True;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppointmentMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new VehicleMap());
            builder.ApplyConfiguration(new WorkOrderMap());

        }

    }
}
