using CapaServicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Configuracion;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacionController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private ITokenHandlerService _service;

        public AutorizacionController(UserManager<IdentityUser> userManager, ITokenHandlerService service)
        {
            _userManager = userManager;
            _service = service;
        }

        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Registro([FromBody] SolicitudRegistroUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                var UsuarioExistente = await _userManager.FindByEmailAsync(usuario.Email);
                if (UsuarioExistente != null)
                {
                    return BadRequest("La dirección de email ya ha sido registrada.");
                }

                var isCreated = await _userManager.CreateAsync(new IdentityUser { Email = usuario.Email, UserName = usuario.Nombre }, usuario.Password);
                if (isCreated.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(isCreated.Errors.Select(d => d.Description).ToList());
                }
            }
            else
            {
                return BadRequest("Se produjo un error registrando el usuario.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] SolicitudLoginUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioExistente = await _userManager.FindByEmailAsync(usuario.Email);
                if (usuarioExistente == null)
                {
                    return BadRequest(new RespuestaLoginUsuario()
                    {
                        IsLogin = false,
                        Errors = new List<string>()
                        {
                            "El usuario o contraseña incorrectos."
                        }
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(usuarioExistente, usuario.Password);
                if (isCorrect)
                {
                    // Creamos el token de seguridad
                    var _pars = new TokenParameters()
                    {
                        Id = usuarioExistente.Id,
                        PasswordHash = usuarioExistente.PasswordHash,
                        UserName = usuarioExistente.UserName
                    };

                    var jwtToken = _service.GenerateJwtToken(_pars);

                    return Ok(new RespuestaLoginUsuario()
                    {
                        IsLogin = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new RespuestaLoginUsuario()
                    {
                        IsLogin = false,
                        Errors = new List<string>()
                        {
                            "El usuario o contraseña incorrectos."
                        }
                    });
                }
            }
            else
            {
                return BadRequest(new RespuestaLoginUsuario()
                {
                    IsLogin = false,
                    Errors = new List<string>()
                        {
                            "El usuario o contraseña incorrectos."
                        }
                });
            }
        }
    }
}
