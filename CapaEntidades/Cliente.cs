using System;

namespace CapaEntidades
{
    public class Cliente : EntidadGenerica
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Pais { get; set; }

        public string CodigoPostal { get; set; }

        public string Email { get; set; }
        
    }
}
