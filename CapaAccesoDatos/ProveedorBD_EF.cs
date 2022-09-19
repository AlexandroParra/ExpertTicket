using Abstracciones;
using CapaEntidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CapaAccesoDatos
{
    /// <summary>
    /// ProveedorBD_EF sera nuestra instancia personalizada de DbContext. Podríamos usar DbContext directamente,
    /// pero así conseguimos mayor personalización y desacoplamiento con EntityFramework.
    /// También se puede entender como la interfaz entre nuestro propio Contexto de Datos y el DBContext del 
    /// Entity Framework.
    /// Esta clase debe contener un DbSet por cada clase de objetos del dominio que queramos persistir.
    /// Empezamos por Clientes ... pero esto sólo es el comienzo, jajajajaja (tono pirata).
    /// </summary>
    public class ProveedorBD_EF : IdentityDbContext, IOrigenDeDatos
    {
        public DbSet<Cliente> Clientes { get; set; }

        public string Name => "Proveedor de Base de Datos del EntityframeworkCore";

        /// <summary>
        /// Se crea este constructor para ser invocado desde el startup de la API y, de esta forma, poder ser utilizado
        /// en cualquier capa.
        /// </summary>
        /// <param name="opciones">Parametros que necesita el DbContext del EntityFrameworkCore para funcionar.</param>
        public ProveedorBD_EF(DbContextOptions<ProveedorBD_EF> opciones): base(opciones)
        {

        }

        /// <summary>
        /// Este método es el homólogo al OnLoad de un formulario dentro de un contenedor visual.
        /// Se usa, en un principio, para prevenir que no se creen tablas que no queremos en el momento de la migración.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llamamos a este método porque, por convención, EntityFrameWorkCore crea un objeto de intercambio con la base de datos,
            // por cada clase que se le pasa. Nosotros hemos especificado que todas nuestras clases van a heredar de EntidadGenerica.
            // Pero no necesitamos que se gestione esta clase entre la capa negocio y la capa datos (Contexto y BBDD propiamente).
            modelBuilder.Ignore<EntidadGenerica>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
