using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace WebApi.DTOs
{
    public class SolicitudLoginUsuario
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
