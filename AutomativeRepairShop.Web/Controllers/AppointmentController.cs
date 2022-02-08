using AutoMapper;
using AutomativeRepairShop.Core.DTOs;
using AutomativeRepairShop.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        IMapper _mapper;
        public AppointmentController(IAppointmentService appointmentService,ICustomerService customerService,IVehicleService vehicleService,  IMapper mapper)
        {
            _appointmentService = appointmentService;
            _customerService = customerService;
            _vehicleService = vehicleService;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AppointmentList()
        {
            var appointmentList = _appointmentService.GetAllAppointments();
            return View(appointmentList);
        }

        public IActionResult AddAppointment()
        {
            var appointmentDto = new AppointmentDto()
            {
                CustomerList = _customerService.GetCustomerSelectList(),
                VehicleList=  _vehicleService.GetVehicleSelectList()
            };
            return View(appointmentDto);
        }

        [HttpPost]
        public IActionResult AddAppointment(AppointmentDto newAppointment)
        {
            _appointmentService.AddAppointment(newAppointment);
            return RedirectToAction("AppointmentList");
        }

        public IActionResult UpdateAppointment(int id)
        {
            var appointmentModel = _appointmentService.GetAppointmentById(id);
            appointmentModel.CustomerList = _customerService.GetCustomerSelectList();
            appointmentModel.VehicleList = _vehicleService.GetVehicleSelectList();
            return View(appointmentModel);
        }

        [HttpPost]
        public IActionResult UpdateAppointment(AppointmentDto appointmentDto, int id)
        {
            _appointmentService.UpdateAppointment(appointmentDto, id);
            return RedirectToAction("AppointmentList");
        }

        public IActionResult DeleteAppointment(int id)
        {
            _appointmentService.DeleteAppointment(id);
            return RedirectToAction("AppointmentList");
        }

    }
}
