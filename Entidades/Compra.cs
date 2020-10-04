using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compra
    {
        Cliente comprador;
        Empleado vendedor;
        List<ArticuloCompra> productos;
        double precioTotal;
        DateTime dateTime;
        

        public Cliente Comprador
        {
            get { return comprador; }
            set { this.comprador = value; }
        }

        public Empleado Vendedor
        {
            get { return vendedor; }
            set { this.vendedor = value; }
        }

        public double PrecioTotal
        {
            get { return precioTotal; }
        }

        public List<ArticuloCompra> Productos
        {
            get { return productos; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set { this.dateTime = value; }
        }

        public Compra()
        {
            this.productos = new List<ArticuloCompra>();
        }

        public Compra(Cliente comprador, Empleado vendedor, double precioTotal)
        {
            this.comprador = comprador;
            this.vendedor = vendedor;
            this.precioTotal = precioTotal;
            this.productos = new List<ArticuloCompra>();
        }
        
        public void AgregarArticulo(ArticuloCompra articuloCompra)
        {

            if(Productos.Exists(x => x.Producto.Equals(articuloCompra.Producto))){
                Productos.Find(x => x.Producto.Equals(articuloCompra.Producto)).Cantidad += articuloCompra.Cantidad;
            }
            else
            {
                productos.Add(articuloCompra);
            }
                ////Agregar validacion para no repetir las cosas
            //for (int i = 0; i < productos.Count; i++)
            //{
            //    if(articuloCompra.Producto == productos[i].Producto)
            //    {
            //        productos[i].Cantidad += articuloCompra.Cantidad;
            //    }
            //    else
            //    {
            //        productos.Add(articuloCompra);
            //    }
            //}
        }
    }
}
