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


        public VehicleDto AddVehicle(VehicleDto newVehicle)
        {
            var newVehicleEntity = _mapper.Map<VehicleDto, Vehicle>(newVehicle);
            _unitOfWork.Vehicles.Add(newVehicleEntity);
            _unitOfWork.Commit();
            return newVehicle;
        }

        public VehicleDto UpdateVehicle(VehicleDto updatedVehicle, int id)
        {
            var vehicleEntityToBeUpdated = _unitOfWork.Vehicles.GetById(id);
            vehicleEntityToBeUpdated.LicensePlate = updatedVehicle.LicensePlate;
            vehicleEntityToBeUpdated.Brand = updatedVehicle.Brand;
            vehicleEntityToBeUpdated.Model = updatedVehicle.Model;
            vehicleEntityToBeUpdated.Year = updatedVehicle.Year;
            var updatedEntity = _unitOfWork.Vehicles.Update(vehicleEntityToBeUpdated);
            _unitOfWork.Commit();
            return _mapper.Map<Vehicle, VehicleDto>(updatedEntity);
        }

        public void DeleteVehicle(int id)
        {
            _unitOfWork.Vehicles.Delete(id);
            //delete fk's also (appointment)
            var appointmentList = _unitOfWork.Appointments.GetAll(x => x.VehicleId == id && x.DeleteDate == null);
            _unitOfWork.Appointments.DeleteAllEntities(appointmentList);
            _unitOfWork.Commit();
        }


    }
}
