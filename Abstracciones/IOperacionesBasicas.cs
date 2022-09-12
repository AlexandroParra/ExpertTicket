using System;
using System.Collections.Generic;

namespace Abstracciones
{
    public interface IOperacionesBasicas<T>
    {
        /// <summary>
        /// Se encargará de insertar o actualizar la entidad (según corresponda).
        /// </summary>
        /// <param name="entity">La entidad a actualizar o insertar.</param>
        /// <returns>Referencia a la entidad recién actualizada o insertada.</returns>
        T Save(T entity);

        /// <summary>
        /// Devuelve todas las entidades.
        /// </summary>
        /// <returns>Lista de entidades devueltas.</returns>
        IList<T> GetAll();

        /// <summary>
        /// Devuelve una entidad por su ID.
        /// </summary>
        /// <param name="entityKey">Id de la entidad que se pretende recuperar.</param>
        /// <returns>Entidad devuelta.</returns>
        T GetById(int entityKey);

        /// <summary>
        /// Elimina la entidad cuyo Id se pasa por parámetro.
        /// </summary>
        /// <param name="entityKey">Id de la entidad que se pretende eliminar.</param>
        void Delete(int entityKey);
    }
}
