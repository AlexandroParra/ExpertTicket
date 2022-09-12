using Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public abstract class EntidadGenerica : IEntidadGenerica
    {
        public int Id { get; set; }
        public string CodDescEntidad { get; set; }
    }
}
