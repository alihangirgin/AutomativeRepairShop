using AutoMapper;
using AutomativeRepairShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.DTOs.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Vehicle, VehicleDto>().ForMember(dto => dto.CustomerName, conf => conf.MapFrom(ol => ol.Customer.Name + " " + ol.Customer.Surname));
            CreateMap<VehicleDto, Vehicle>();
            CreateMap<Appointment, AppointmentDto>().ForMember(dto => dto.CustomerName, conf => conf.MapFrom(ol => ol.Customer.Name + " " + ol.Customer.Surname)).ForMember(dto => dto.VehicleName, conf => conf.MapFrom(ol => ol.Vehicle.Brand + " " + ol.Vehicle.Model));
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<WorkOrder, WorkOrderDto>().ForMember(dto => dto.AppointmentDate, conf => conf.MapFrom(ol => ol.Appointment.AppointmentDate)).ForMember(dto => dto.CustomerName, conf => conf.MapFrom(ol => ol.Appointment.Customer.Name + " " + ol.Appointment.Customer.Surname)).ForMember(dto => dto.VehicleName, conf => conf.MapFrom(ol => ol.Appointment.Vehicle.Brand + " " + ol.Appointment.Vehicle.Model));
            CreateMap<WorkOrderDto, WorkOrder>();
        }
    }
}
