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
        string nombreUsuario;

        public long NumeroEmpleado
        {
            get { return numeroEmpleado; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
        }

        public Empleado(string nombre, string apellido, int dni, long numeroEmpleado, string nombreUsuario) : base(nombre, apellido, dni)
        {
            this.numeroEmpleado = numeroEmpleado;
            this.nombreUsuario = nombreUsuario;
        }

    }
}
