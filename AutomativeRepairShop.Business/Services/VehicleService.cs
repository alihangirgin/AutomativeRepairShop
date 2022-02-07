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
    public class VehicleService:IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<VehicleDto> GetAllVehicles()
        {
            var vehicleList = _unitOfWork.Vehicles.GetAll();
            var vehicleListResource = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDto>>(vehicleList);
            return vehicleListResource;
        }
    }
}
