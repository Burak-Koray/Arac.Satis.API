using Arac.Satis.API.Controllers.Base;
using Arac.Satis.Model.VehicleDtos;
using Arac.Satis.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arac.Satis.API.Controllers
{  
    public class VehicleController :BaseController
    {
        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AddVehicleDto addVehicleDto)
        {
            VehicleManager vehicleManager = new();

            string[] fileBytesStringFormat = addVehicleDto.File.Split(',');
            byte[] fileByte = new byte[fileBytesStringFormat.Length];

            for (int i = 0; i < fileBytesStringFormat.Length; i++)
            {
                fileByte[i] = Convert.ToByte(fileBytesStringFormat[i]);
            }

            System.IO.File.WriteAllBytes(Directory.GetCurrentDirectory() + "/wwwroot/" + addVehicleDto.FileName, fileByte);

            vehicleManager.Add(addVehicleDto);
        }

        [HttpPut]
        [Route("Update")]
        public void Update([FromBody] UpdateVehicleDto updateVehicleDto, int vehicleId)
        {

            VehicleManager vehicleManager = new();
            vehicleManager.Update(updateVehicleDto, vehicleId);
        }

        [HttpGet]
        [Route("Delete")]
        public void Delete(int vehicleId)
        {

            Shared shared = new();
            string token = HttpContext.Request.Headers["Authorization"];

            if (shared.GetUsername(token) == "BURAK")
            {
                VehicleManager vehicleManager = new();
                vehicleManager.Delete(vehicleId);
            }


        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetById")]
        public VehicleDto GetById(int id)
        {
            VehicleManager vehicleManager = new();
            return vehicleManager.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<VehicleDto> GetAll()
        {
            VehicleManager vehicleManager = new();
            return vehicleManager.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllNonDeleted")]
        public List<VehicleDto> GetAllNonDeleted()
        {
            VehicleManager vehicleManager = new();
            return vehicleManager.GetAllNonDeleted();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllByCategoryId")]
        public List<VehicleDto> GetAllByCategoryId(int categoryId)
        {
            VehicleManager manager = new();
            return manager.GetAll(categoryId);
        }

        [HttpPut]
        [Route("SetActive")]
        public void SetActive(int vehicleId)
        {
            VehicleManager vehicleManager = new();
            vehicleManager.SetActive(vehicleId);
        }
    }
}
