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

    }
}
