using Abstracciones;
using System;
using System.Collections.Generic;

namespace CapaRepositorio
{
    public interface IRepositorio<T>:IOperacionesBasicas<T>
    {

    }
    public class Repositorio<T> : IRepositorio<T> where T:IEntidadGenerica
    {
        IContextoBD<T> _contexto;

        public Repositorio(IContextoBD<T> contexto)
        {
            _contexto = contexto;
        }

        public void Delete(int entityKey)
        {
            _contexto.Delete(entityKey);
        }

        public IList<T> GetAll()
        {
            return _contexto.GetAll();
        }

        public T GetById(int entityKey)
        {
            return _contexto.GetById(entityKey);
        }

        public T Save(T entity)
        {
            return _contexto.Save(entity);
        }
    }
}
