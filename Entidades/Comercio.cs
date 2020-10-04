using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Comercio
    {
        static List<Cliente> listaClientes;
        static List<Empleado> listaEmpleados;
        static List<Producto> listaProductos;
        static List<Producto> listaCarrito;
        static List<Compra> listaVentas;
        static Compra compraEnCurso;
        static string nombreComercio;

        /// <summary>
        /// Constructor
        /// </summary>
        static Comercio()
        {
            listaProductos = new List<Producto>();
            listaCarrito = new List<Producto>();
            listaEmpleados = new List<Empleado>();
            listaClientes = new List<Cliente>();
            listaVentas = new List<Compra>();
            compraEnCurso = new Compra();
            nombreComercio = "Kwik E Mart";
        }

        public static List<Producto> ListaProductos
        {
            get { return listaProductos; }
        }

        public static string NombreComercio
        {
            get { return nombreComercio; }
        }

        public static List<Cliente> ListaClientes
        {
            get { return listaClientes; }
        }
        public static List<Compra> ListaVentas
        {
            get { return listaVentas; }
        }
        public static Compra CompraEnCurso
        {
            get { return compraEnCurso; }
        }

        public static string AgregarNuevoProducto(int id, string desc, int stock, double precio, Producto.ECategoria tipo, List<Producto> auxLista)
        {
            Producto nuevoProducto = new Producto(id, desc, stock, precio, tipo);
            if (nuevoProducto + auxLista)
            {
                return "Producto agregado correctamente";
            }
            return "Error en la carga";
        }

        public static void PrecargaListaClientes()
        {
            listaClientes.Add(new Cliente("Alejo", "Bianchini", 231321, 3,1));
            //listaClientes.Add(new Cliente("Leonardo", "Forro", new List<Compra>()));
        }

        public static void PrecargaListaProductos()
        {
            listaProductos.Add(new Producto(1, "Gaseosa", 90, 140, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(2, "Galletita", 180, 50, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(3, "Carne", 24, 25, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(4, "Pollo", 24, 35, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(5, "Leche", 24, 50, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(6, "Pan", 24, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(7, "Cerdo", 24, 14, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(8, "Tomate", 24, 20, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(9, "Papa", 24, 30, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(10, "Lechuga", 24, 15, Producto.ECategoria.verduleria));
        }

        public static void PrecargaListaEmpelados()
        {
            listaEmpleados.Add(new Empleado("Apu", "Nahasapeemapetilon", 41559381, 1, 1));
            listaEmpleados.Add(new Empleado("Sanjay", "Nahasapeemapetilon", 42556963, 2, 2));
        }

        public static bool AgregarArticuloAlCarrito(ArticuloCompra articuloCompra)
        {
            if(CompraEnCurso.Productos.Exists(x => x.Producto.Equals(articuloCompra.Producto)))
            {
                if (listaProductos.Find(x => x.Descripcion.Equals(articuloCompra.Producto)).Stock >=
                        (articuloCompra.Cantidad + CompraEnCurso.Productos.Find(x => x.Producto.Equals(articuloCompra.Producto)).Cantidad))
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }
            else
            {
                if (listaProductos.Find(x => x.Descripcion.Equals(articuloCompra.Producto)).Stock >= articuloCompra.Cantidad)
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }

            return false;
        }

        public static bool FinalizarCompraActual()
        {
            CompraEnCurso.DateTime = DateTime.Now;

            compraEnCurso.Vendedor = listaEmpleados[0];
            compraEnCurso.Comprador = listaClientes[0];

            foreach (ArticuloCompra item in CompraEnCurso.Productos)
            {
                Producto p = listaProductos.Find(x => x.Descripcion.Equals(item.Producto));
                p.Stock -= item.Cantidad;
            }

            listaVentas.Add(compraEnCurso);

            compraEnCurso = new Compra();

            return true;
        }

    }
}
