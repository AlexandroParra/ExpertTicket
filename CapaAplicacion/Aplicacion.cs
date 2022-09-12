using Abstracciones;
using CapaRepositorio;
using System;
using System.Collections.Generic;

namespace CapaAplicacion
{
    public interface IAplicacion<T>:IOperacionesBasicas<T>
    {

    }

    /// <summary>
    /// Gestión de entidades filtradas por la interfaz IEntidadGenerica.
    /// </summary>
    /// <typeparam name="T">tipo de la entidad a gestionar.</typeparam>
    public class Aplicacion<T> : IAplicacion<T> where T: IEntidadGenerica 
    {
        IRepositorio<T> _repositorio;

        public Aplicacion(IRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Delete(int entityKey)
        {
            _repositorio.Delete(entityKey);
        }

        public IList<T> GetAll()
        {
            return _repositorio.GetAll();
        }

        public T GetById(int entityKey)
        {
            return _repositorio.GetById(entityKey);
        }

        public T Save(T entity)
        {
            return _repositorio.Save(entity);
        }
    }
}
