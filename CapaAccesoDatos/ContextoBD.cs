using Abstracciones;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class ContextoBD<T> : IContextoBD<T> where T:IEntidadGenerica
    {
        IList<T> _datos;

        public ContextoBD()
        {
            _datos = new List<T>(); 
        }

        public void Delete(int entityKey)
        {
            var e = _datos.Where(r => r.Id.Equals(entityKey)).FirstOrDefault();
            if (e!= null)
            {
                _datos.Remove((T)e);
            }
        }

        public IList<T> GetAll()
        {
            return _datos;
        }

        public T GetById(int entityKey)
        {
            return _datos.Where(r => r.Id.Equals(entityKey)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            if(entity.Id.Equals(null))
            {
                _datos.Add(entity); 
            }
            else
            {

            }
            return entity;
        }
    }
}
