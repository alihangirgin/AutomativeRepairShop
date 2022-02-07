using AutoMapper;
using AutomativeRepairShop.Core.DTOs;
using AutomativeRepairShop.Core.Models;
using AutomativeRepairShop.Core.Services;
using AutomativeRepairShop.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Business.Services
{
    public class WorkOrderService:IWorkOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<WorkOrderDto> GetAllWorkOrders()
        {
            var workOrderList = _unitOfWork.WorkOrders.GetAll();
            var workOrderListResource = _mapper.Map<IEnumerable<WorkOrder>, IEnumerable<WorkOrderDto>>(workOrderList);
            return workOrderListResource;
        }
    }
}
