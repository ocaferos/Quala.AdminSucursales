using Microsoft.AspNetCore.Mvc;
using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quala.AdminSucursales.Service.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MonedaController : Controller
    {
        private readonly IMonedaApplication _monedaApplication;

        public MonedaController(IMonedaApplication monedaApplication)
        {
            _monedaApplication = monedaApplication;
        }
        [HttpGet]
        public IEnumerable<MonedaDTO> GetAll()
        {
            var response = _monedaApplication.GetMonedas();
            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        [HttpGet("{codigo}")]
        public MonedaDTO GetById(int codigo)
        {
            //if (codigo < 1)
            //    return BadRequest();

            var response = _monedaApplication.GetMonedaByCodigo(codigo);
            //if (response.IsSuccess)
            return response.Data;

            //return BadRequest(response.Message); 
        }
    }
}
