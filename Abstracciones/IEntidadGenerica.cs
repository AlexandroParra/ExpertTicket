using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones
{
    public interface IEntidadGenerica
    {
        int Id { get; set; }
        string CodDescEntidad { get; set; }
    }
}
