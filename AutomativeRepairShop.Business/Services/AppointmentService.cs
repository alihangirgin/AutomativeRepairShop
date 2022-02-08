﻿using AutoMapper;
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
    public class AppointmentService:IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<AppointmentDto> GetAllAppointments()
        {
            var appointmentList = _unitOfWork.Appointments.GetAll();
            var appointmentListResource = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDto>>(appointmentList);
            return appointmentListResource;
        }

        public AppointmentDto AddAppointment(AppointmentDto newAppointment)
        {
            var newAppointmentEntity = _mapper.Map<AppointmentDto, Appointment>(newAppointment);
            _unitOfWork.Appointments.Add(newAppointmentEntity);
            _unitOfWork.Commit();
            return newAppointment;
        }

        public AppointmentDto UpdateAppointment(AppointmentDto updatedAppointment, int id)
        {
            var appointmentEntityToBeUpdated = _unitOfWork.Appointments.GetById(id);
            appointmentEntityToBeUpdated.AppointmentDate = updatedAppointment.AppointmentDate;
            appointmentEntityToBeUpdated.isApproved = updatedAppointment.isApproved;
            appointmentEntityToBeUpdated.isReal = updatedAppointment.isReal;
            var updatedEntity = _unitOfWork.Appointments.Update(appointmentEntityToBeUpdated);
            _unitOfWork.Commit();
            return _mapper.Map<Appointment, AppointmentDto>(updatedEntity);
        }

        public void DeleteAppointment(int id)
        {
            _unitOfWork.Appointments.Delete(id);
            //delete fk's also (workOrder)
            var workOrderList = _unitOfWork.WorkOrders.GetAll(x => x.AppointmentId == id && x.DeleteDate == null);
            _unitOfWork.WorkOrders.DeleteAllEntities(workOrderList);
            _unitOfWork.Commit();
        }


    }
}
