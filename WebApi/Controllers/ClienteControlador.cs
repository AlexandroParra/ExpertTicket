using CapaAplicacion;
using CapaEntidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteControlador : ControllerBase
    {
        IAplicacion<Cliente> _cliente;
        public ClienteControlador(IAplicacion<Cliente> cliente)
        {
            _cliente = cliente;
        }
        
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok
            (
               _cliente.GetAll()
            );
        }
        

        [HttpPost]
        public IActionResult Save(Cliente cliente)
        {
            return Ok
            (
               _cliente.Save(cliente)
            );
        }

        /*
        [HttpGet]
        public IActionResult Get()
        {
            return Ok
            (
                new Cliente()
                {
                    Nombre = "Luis Alejandro",
                    Apellidos = "Parra Jiménez",
                    Sexo = "Casi nada, por decir algo.",
                    FechaNacimiento = new DateTime(1974, 12, 22),
                    Direccion = "Avda. Ildefonso Marañón Lavín 1, 5º, puerta 23",
                    CodigoPostal = "41019",
                    Ciudad = "Sevilla",
                    Pais = "España",
                    Email = "luis.alexandro.parra@gmail.com"
                }
            ) ;
        }
        */
        
    }
}
