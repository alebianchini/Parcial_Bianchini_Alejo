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
            set { this.precioTotal = value; }
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

        public Compra(Cliente comprador, Empleado vendedor, double precioTotal) : this()
        {
            this.comprador = comprador;
            this.vendedor = vendedor;
            this.precioTotal = precioTotal;
        }

        public Compra(Cliente comprador, Empleado vendedor, double precioTotal, DateTime dateTime) : this(comprador,vendedor,precioTotal)
        {
            this.dateTime = dateTime;
        }

        public void AgregarArticulo(ArticuloCompra articuloCompra)
        {
            precioTotal += articuloCompra.PrecioFinal;

            if (Productos.Exists(x => x.Producto.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase))){
                ArticuloCompra auxArt = Productos.Find(x => x.Producto.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase));
                auxArt.Cantidad += articuloCompra.Cantidad;
                auxArt.PrecioFinal = auxArt.Cantidad * auxArt.PrecioUnitario;
            }
            else
            {
                productos.Add(articuloCompra);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha de Compra: {this.DateTime}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Datos del Cliente: ");
            sb.AppendLine($"\tNombre Completo: {this.Comprador.Nombre} {this.Comprador.Apellido}");
            sb.AppendLine($"\tDNI: {this.Comprador.Dni}");
            sb.AppendLine($"\tNro Cliente: {this.Comprador.NumeroCliente}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Datos del Vendedor: ");
            sb.AppendLine($"\tNombre Completo: {this.Vendedor.Nombre} {this.Vendedor.Apellido}");
            sb.AppendLine($"\tDNI: {this.Vendedor.Dni}");
            sb.AppendLine($"\tNro Empleado: {this.Vendedor.NumeroEmpleado}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Productos");

            foreach(var p in this.Productos)
            {
                sb.AppendLine($"{p.Producto}\t\t\t x{p.Cantidad}  ${p.PrecioFinal}");
            }

            sb.AppendLine($"Precio Total: \t\t\t{this.precioTotal}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine($"Graciasss, Vuelvass prontosss!!!");
            return sb.ToString();
        }
    }
}
