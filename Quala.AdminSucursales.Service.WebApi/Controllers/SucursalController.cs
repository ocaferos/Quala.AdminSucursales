using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Application.Interface;

namespace Quala.AdminSucursales.Service.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SucursalController : Controller
    {
        private readonly ISucursalApplication _sucursalApplication;

        public SucursalController(ISucursalApplication sucursalApplication)
        {
            _sucursalApplication = sucursalApplication;
        }

        [HttpPost]
        public ActionResult Insert([FromBody]SucursalDTO sucursalDTO)
        {
            if(sucursalDTO == null)
                return BadRequest();

            var response = _sucursalApplication.InsertSucursales(sucursalDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public ActionResult Update([FromBody]SucursalDTO sucursalDTO)
        {
            if (sucursalDTO == null)
                return BadRequest();

            var response = _sucursalApplication.UpdateSucursales(sucursalDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{codigo}")]
        public ActionResult Delete(int codigo)
        {
            if (codigo < 1)
                return BadRequest();

            var response = _sucursalApplication.DeleteSucursales(codigo);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public IEnumerable<SucursalDTO> GetAll()
        {
            var response = _sucursalApplication.GetSucursales();
            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        [HttpGet("{codigo}")]
        public SucursalDTO GetById(int codigo)
        {
            //if (codigo < 1)
            //    return BadRequest();

            var response = _sucursalApplication.GetSucursalByCodigo(codigo);
            //if (response.IsSuccess)
                return response.Data;

            //return BadRequest(response.Message); 
        }
    }
}
