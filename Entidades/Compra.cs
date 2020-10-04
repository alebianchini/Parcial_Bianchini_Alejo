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
            precioTotal += articuloCompra.PrecioFinal;

            if (Productos.Exists(x => x.Producto.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase))){
                ArticuloCompra aux = Productos.Find(x => x.Producto.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase));
                aux.Cantidad += articuloCompra.Cantidad;
                aux.PrecioFinal = aux.Cantidad * aux.PrecioUnitario;
            }
            else
            {
                productos.Add(articuloCompra);
            }

        }
    }
}
