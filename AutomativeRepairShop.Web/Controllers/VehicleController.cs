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
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;
        IMapper _mapper;
        public VehicleController(IVehicleService vehicleService,ICustomerService customerService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _customerService = customerService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VehicleList()
        {
            var vehicleList= _vehicleService.GetAllVehicles();
            return View(vehicleList);
        }

        public IActionResult AddVehicle()
        {
            var vehicleDto = new VehicleDto()
            {
                CustomerList = _customerService.GetCustomerSelectList()
            };
            return View(vehicleDto);
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleDto newVehicle)
        {
            _vehicleService.AddVehicle(newVehicle);
            return RedirectToAction("VehicleList");
        }

        public IActionResult UpdateVehicle(int id)
        {
            var vehicleModel = _vehicleService.GetVehicleById(id);
            vehicleModel.CustomerList = _customerService.GetCustomerSelectList();
            return View(vehicleModel);
        }

        [HttpPost]
        public IActionResult UpdateVehicle(VehicleDto vehicleDto, int id)
        {
            _vehicleService.UpdateVehicle(vehicleDto, id);
            return RedirectToAction("VehicleList");
        }

        public IActionResult DeleteVehicle(int id)
        {
            _vehicleService.DeleteVehicle(id);
            return RedirectToAction("VehicleList");
        }
    }
}
