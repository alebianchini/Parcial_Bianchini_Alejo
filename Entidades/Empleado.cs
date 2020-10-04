using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Persona
    {
        long numeroEmpleado;

        public long NumeroEmpleado
        {
            get { return numeroEmpleado; }
        }

        public Empleado(string nombre, string apellido, int dni, long id, long numeroEmpleado) : base(nombre, apellido, dni, id)
        {
            this.numeroEmpleado = numeroEmpleado;
        }
    }
}
