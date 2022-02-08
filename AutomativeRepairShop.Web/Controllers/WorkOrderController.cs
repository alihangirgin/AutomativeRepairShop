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
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderService _workOrderService;
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public WorkOrderController(IWorkOrderService workOrderService,IAppointmentService appointmentService,ICustomerService customerService,IVehicleService vehicleService,IMapper mapper)
        {
            _workOrderService = workOrderService;
            _appointmentService = appointmentService;
            _customerService = customerService;
            _vehicleService = vehicleService;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WorkOrderList()
        {
            var workOrderList = _workOrderService.GetAllWorkOrders();
            return View(workOrderList);
        }

        public IActionResult AddWorkOrder()
        {
            var workOrderDto = new WorkOrderWithoutAppointmentDto()
            {
                CustomerList = _customerService.GetCustomerSelectList(),
                VehicleList = _vehicleService.GetVehicleSelectList()
            };
            return View(workOrderDto);
        }

        [HttpPost]
        public IActionResult AddWorkOrder(WorkOrderWithoutAppointmentDto newWorkOrder)
        {
            _workOrderService.AddWorkOrderWithoutAppointment(newWorkOrder);
            return RedirectToAction("WorkOrderList");
        }

        public IActionResult DeleteWorkOrder(int id)
        {
            _workOrderService.DeleteWorkOrder(id);
            return RedirectToAction("WorkOrderList");
        }

    }
}
