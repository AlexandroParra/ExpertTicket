using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    /// <summary>
    /// Esta clase recoge los datos que necesita un usuario para registrarse en la aplicación.
    /// </summary>
    public class SolicitudRegistroUsuario
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
