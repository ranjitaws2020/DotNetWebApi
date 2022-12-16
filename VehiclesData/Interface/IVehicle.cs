using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesData.Model;

namespace VehiclesData.Interface
{
    public interface IVehicle
    {
        List<Vehicle> GetVehicles();
        List<Vehicle> GetVehicleById(int id);
        string UpdateVehicles(int id, int Year,string Make,string Model);
        string CreateVehicle(int Year,string Make,string Model);
        string RemoveVehicles(int id);
    }
}
