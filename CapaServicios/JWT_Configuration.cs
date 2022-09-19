using System;

namespace CapaServicios
{
    /// <summary>
    /// Esta clase contiene las propiedades de JWT guardadas en appsettings.
    /// De momento, sólo tiene Secret.
    /// </summary>
    public class JWT_Configuration
    {
        public string Secret { get; set; }
    }
}
