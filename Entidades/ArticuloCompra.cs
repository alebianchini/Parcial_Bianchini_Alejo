using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArticuloCompra
    {
        int cantidad;
        Producto producto;
        double precioFinal;
        double precioUnitario;

        public int Cantidad
        {
            get { return cantidad; }
            set { this.cantidad = value; }
        }
        public string Producto
        {
            get { return producto.Descripcion; }
        }
        public double PrecioFinal
        {
            get { return precioFinal; }
        }
        public double PrecioUnitario
        {
            get { return precioUnitario; }
        }

        public ArticuloCompra(int cantidad, Producto producto, double precioFinal, double precioUnitario)
        {
            this.cantidad = cantidad;
            this.producto = producto;
            this.precioFinal = precioFinal;
            this.precioUnitario = precioUnitario;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cantidad: " + this.cantidad);
            sb.AppendLine("Producto: " + this.producto.Descripcion);
            sb.AppendLine("Precio por Unidad: " + this.precioUnitario.ToString());
            sb.AppendLine("Precio Final: " + this.precioFinal.ToString());
            return sb.ToString();
        }
    }
}
