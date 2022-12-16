using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesData.Model;
using VehiclesData.Interface;
using VehiclesData.Repository;

namespace VehiclesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicle veh = new VehicleRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles()
        {
            return veh.GetVehicles();
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Vehicle>> GetVehicleById(int id)
        {
            return veh.GetVehicleById(id);
        }
        [HttpPut("/updatevehicles")]
        public String UpdateVehicles(int id,int Year,string Make,string Model)
        {
            return veh.UpdateVehicles(id, Year, Make, Model);
        }
        [HttpPost("/AddVehicles")]
        public String CreateVehicle([FromBody] Vehicle newveh)
        {
            return veh.CreateVehicle(newveh.Year,newveh.Make,newveh.Model);
        }
        [HttpDelete("{id}")]
        public String RemoveVehicles(int id)
        {
            return veh.RemoveVehicles(id);
        }
    }
}
