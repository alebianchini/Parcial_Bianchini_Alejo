using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        long idProducto;
        string descripcion;
        int stock;
        double precioUnitario;
        ECategoria categoriaProducto;

        public enum ECategoria
        {
            almacen,
            carniceria,
            verduleria,
            limpieza
        }

        /// <summary>
        /// Getter del campo idProducto
        /// </summary>
        public long IdProducto
        {
            get { return idProducto; }
        }

        /// <summary>
        /// Getter del campo descripcion
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
        }

        /// <summary>
        /// Getter del campo stock
        /// </summary>
        public int Stock
        {
            get { return stock; }
            set { this.stock = value; }
        }

        /// <summary>
        /// Getter del campo precioUnitario
        /// </summary>
        public double PrecioUnitario
        {
            get { return precioUnitario; }
        }

        /// <summary>
        /// Getter del campo estado
        /// </summary>
        public ECategoria TipoProducto
        {
            get { return categoriaProducto; }
        }

        /// <summary>
        /// Constructor del objeto Producto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="estado"></param>
        public Producto(long idProducto, string descripcion, int stock, double precioUnitario, ECategoria tipoProducto)
        {
            this.idProducto = idProducto;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precioUnitario = precioUnitario;
            this.categoriaProducto = tipoProducto;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Producto: " + this.descripcion);
            sb.AppendLine("Stock: " + this.stock.ToString());
            sb.AppendLine("Precio por Unidad: " + this.precioUnitario.ToString());
            sb.AppendLine("Tipo de Producto: " + this.categoriaProducto.ToString());
            return sb.ToString();
        }

        public static bool operator +(Producto auxProducto, List<Producto> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxProducto.descripcion == null || auxProducto == auxList[i])
                {
                    return false;
                }
            }
            auxList.Add(auxProducto);
            return true;
        }

        public static bool operator -(Producto auxProducto, List<Producto> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxProducto == auxList[i])
                {
                    auxList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Producto auxProducto, Producto auxProducto2)
        {
            if (auxProducto.descripcion == auxProducto2.descripcion)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Producto auxProducto, Producto auxProducto2)
        {
            return !(auxProducto.descripcion == auxProducto2.descripcion);
        }

    }
}