using AutoMapper;
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
        private readonly IMapper _mapper;

        public WorkOrderController(IWorkOrderService workOrderService, IMapper mapper)
        {
            _workOrderService = workOrderService;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
