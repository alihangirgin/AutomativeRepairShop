using AutomativeRepairShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomativeRepairShop.Core.Services
{
    public interface IVehicleService
    {
        VehicleDto GetVehicleById(int id);
        IEnumerable<VehicleDto> GetAllVehicles();
        VehicleDto AddVehicle(VehicleDto newVehicle);
        VehicleDto UpdateVehicle(VehicleDto updatedVehicle, int id);
        void DeleteVehicle(int id);
    }
}
