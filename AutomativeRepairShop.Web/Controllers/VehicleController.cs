using AutoMapper;
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
        IMapper _mapper;
        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
