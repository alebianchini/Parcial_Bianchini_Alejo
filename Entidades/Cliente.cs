using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        long numeroCliente;

        public long NumeroCliente
        {
            get { return  numeroCliente; }
        }


        public Cliente(string nombre, string apellido, int dni, long id, long numeroCliente) : base(nombre, apellido, dni, id)
        {
            this.numeroCliente = numeroCliente;
        }

        public static bool operator +(Cliente auxCliente, List<Cliente> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if(auxCliente.nombre == null || auxCliente == auxList[i])
                {
                    return false;
                }
            }
            auxList.Add(auxCliente);
            return true;
        }

        public static bool operator -(Cliente auxCliente, List<Cliente> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxCliente == auxList[i])
                {
                    auxList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Cliente auxCliente, Cliente auxCliente2)
        {
            if(auxCliente == auxCliente2)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Cliente auxCliente, Cliente auxCliente2)
        {
            return !(auxCliente == auxCliente2);
        }

    }
}
