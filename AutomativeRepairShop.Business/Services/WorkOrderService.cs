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
        private readonly IAppointmentService _appointmentService;

        public WorkOrderService(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentService appointmentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentService = appointmentService;
        }

        public IEnumerable<WorkOrderDto> GetAllWorkOrders()
        {
            //var workOrderList = _unitOfWork.WorkOrders.GetAll("Appointment");
            var workOrderList = _unitOfWork.WorkOrders.GetAllWithIncludes();
            var workOrderListResource = _mapper.Map<IEnumerable<WorkOrder>, IEnumerable<WorkOrderDto>>(workOrderList);
            return workOrderListResource;
        }

        public WorkOrderDto AddWorkOrderWithAppointment(WorkOrderDto newWorkOrder)
        {
            //update appointment(isApproved=1)
            var appointmentEntityToBeUpdated = _unitOfWork.Appointments.GetById(newWorkOrder.AppointmentId);
            appointmentEntityToBeUpdated.isApproved = true;
            _unitOfWork.Appointments.Update(appointmentEntityToBeUpdated);

            //add workOrder
            var newWorkOrderEntity = _mapper.Map<WorkOrderDto, WorkOrder>(newWorkOrder);
            _unitOfWork.WorkOrders.Add(newWorkOrderEntity);

            _unitOfWork.Commit();
            return newWorkOrder;
        }

        public WorkOrderDto AddWorkOrderWithoutAppointment(WorkOrderWithoutAppointmentDto newWorkOrder)
        {
            //add appointment(isReal=0)
            var newAppointmentEntity = new Appointment() {
                CustomerId = newWorkOrder.CustomerId,
                VehicleId = newWorkOrder.VehicleId,
                isReal=false,
                isApproved=true
            };
            var addedAppointment= _unitOfWork.Appointments.Add(newAppointmentEntity);
            _unitOfWork.Commit();

            //add workOrder
            var newWorkOrderEntity = new WorkOrder()
            {
                AppointmentId = addedAppointment.Id
            };
            _unitOfWork.WorkOrders.Add(newWorkOrderEntity);
            _unitOfWork.Commit();
            return _mapper.Map<WorkOrder, WorkOrderDto>(newWorkOrderEntity);
        }

        public void DeleteWorkOrder(int id)
        {
            _unitOfWork.WorkOrders.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
