using Abstracciones;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapaAccesoDatos
{
    /// <summary>
    /// Esta clase contendrá las operaciones genericas que se realizan sobre las entidades persistentes que gestiona la API:
    /// Altas, Bajas, Modificaciones y Listados son las principales, pero, si hubiesen otras, tendrían que tener su reflejo
    /// en esta clase. Esta clase es un ejercicio de generalización por agrupación de operaciones sobre "tablas".
    /// Heredamos de IEntidadGenerica para encauzar el origen de las clases a nivel de diseño y funcionalidad.
    /// Heredamos de class porque lo exige EntityFrameWorkCore (no nos sirve IEntidadGenerica porque es una Interfaz).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContextoBD<T> : IContextoBD<T> where T:class,IEntidadGenerica
    {
        DbSet<T> _registros;

        ProveedorBD_EF _proveedorBD;


        /// <summary>
        /// El constructor almacena el objeto que provee los datos y crea su propia referencia al juego de datos.
        /// </summary>
        /// <param name="proveedorBD">Clase que hereda del DBContext del EntityFramework y la personaliza.</param>
        public ContextoBD(ProveedorBD_EF proveedorBD)
        {
            _proveedorBD = proveedorBD;
            _registros = _proveedorBD.Set<T>();
        }

        public void Delete(int entityKey)
        {            
            _registros.Remove(GetById(entityKey));
        }

        public IList<T> GetAll()
        {
            return _registros.ToList();
        }

        public T GetById(int entityKey)
        {
            return _registros.Where(reg => reg.Id.Equals(entityKey)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _registros.Add(entity);
            _proveedorBD.SaveChanges();
            return entity;
        }
    }
}
