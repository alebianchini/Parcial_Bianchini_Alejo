using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        protected int dni;
        protected long id;
        protected List<Compra> listaTransacciones;

        public string Nombre
        {
            get { return nombre; }
        }        
        
        public int Dni
        {
            get { return dni; }
        }


        public string Apellido
        {
            get { return apellido; }
        }

        public long Id
        {
            get { return id; }
        }

        public List<Compra> ListaTransacciones
        {
            get 
            {
                if(listaTransacciones == null)
                {
                    listaTransacciones = new List<Compra>();
                }
                return listaTransacciones; 
            }
        }

        private Persona()
        {
            this.nombre = "sin nombre";
            this.apellido = "sin apellido";
        }

        public Persona(string nombre, string apellido, int dni, long id):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.id = id;
            listaTransacciones = new List<Compra>();
        }

    }
}
