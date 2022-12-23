using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesData.Model;
using VehiclesData.Interface;
using VehiclesData.Repository;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VehiclesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicle veh = new VehicleRepository();

        db obj = new db();

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles()
        {
            string conStr = obj.dbConString();
            return veh.GetVehicles(conStr);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Vehicle>> GetVehicleById(int id)
        {
            string conStr = obj.dbConString();
            return veh.GetVehicleById(id,conStr);
        }

        [HttpPut("/updatevehicles")]
        public String UpdateVehicles(int id,int Year,string Make,string Model)
        {
            string conStr = obj.dbConString();
            return veh.UpdateVehicles(id, Year, Make, Model,conStr);
        }

        [HttpPost("/AddVehicles")]
        public String CreateVehicle([FromBody] Vehicle newveh)
        {
            string conStr = obj.dbConString();
            return veh.CreateVehicle(newveh.Year,newveh.Make,newveh.Model,conStr);
        }
        /// <summary>
        /// This method will remove the vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public String RemoveVehicles(int id)
        {
            string conStr = obj.dbConString();
            return veh.RemoveVehicles(id,conStr);
            
        }
    }
}
