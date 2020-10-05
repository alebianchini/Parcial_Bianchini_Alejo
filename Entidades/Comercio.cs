using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
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
        static Empleado empleadoActivo;
        static string nombreComercio;
        static Dictionary<string, string> credencialesUsuarios;

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
            credencialesUsuarios = new Dictionary<string, string>();
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

        public static List<Empleado> ListaEmpleados
        {
            get { return listaEmpleados; }
        }
        public static List<Compra> ListaVentas
        {
            get { return listaVentas; }
        }
        public static Compra CompraEnCurso
        {
            get { return compraEnCurso; }
        }

        public static Dictionary<string,string> CredencialesUsuarios
        {
            get { return credencialesUsuarios; }
        }

        public static void ClearSesiónEmpleadoActivo()
        {
            empleadoActivo = null;
        }

        public static void SetEmpleadoActivo(string nombreUsuario)
        {
            empleadoActivo = listaEmpleados.Find(x => x.NombreUsuario.Equals(nombreUsuario));
        }

        public static string AgregarNuevoProducto(int id, string desc, int stock, double precio, Producto.ECategoria tipo)
        {
            Producto nuevoProducto = new Producto(id, desc, stock, precio, tipo);
            if (nuevoProducto + listaProductos)
            {
                return "Producto agregado correctamente";
            }
            return "Error en la carga";
        }

        public static void PrecargaListaClientes()
        {
            listaClientes.Add(new Cliente("Homero", "Simpson", 19564578, 1));
            listaClientes.Add(new Cliente("Marge", "Simpson", 20124578, 2));
            listaClientes.Add(new Cliente("Lisa", "Simpson", 40599578, 3));
            listaClientes.Add(new Cliente("Bart", "Simpson", 39564578, 4));
            listaClientes.Add(new Cliente("Abraham", "Simpson", 16545578, 5));
            listaClientes.Add(new Cliente("Armando", "Barreda", 16545578, 5));
            listaClientes.Add(new Cliente("Carl", "Carlson", 16545578, 5));
            listaClientes.Add(new Cliente("Montgomery", "Burns", 16545578, 5));
            listaClientes.Add(new Cliente("Milhouse", "Van Houten", 16545578, 5));
            listaClientes.Add(new Cliente("Ned", "Flanders", 16545578, 5));
            listaClientes.Add(new Cliente("Professor", "Frink", 16545578, 5));
            listaClientes.Add(new Cliente("Barney", "Gumble", 16545578, 5));
            listaClientes.Add(new Cliente("Bob", "Terwilliger", 16545578, 5));
            listaClientes.Add(new Cliente("Edna", "Krabappel", 16545578, 5));
            listaClientes.Add(new Cliente("Nelson", "Muntz", 16545578, 5));
            listaClientes.Add(new Cliente("Kent", "Brockman", 16545578, 5));
            listaClientes.Add(new Cliente("Otto", "Mann", 16545578, 5));
            listaClientes.Add(new Cliente("Patty", "Bouvier", 16545578, 5));
            listaClientes.Add(new Cliente("Selma", "Bouvier", 16545578, 5));
            listaClientes.Add(new Cliente("Moe", "Szyslak", 16545578, 5));
        }

        public static void PrecargaListaProductos()
        {
            listaProductos.Add(new Producto(1, "Gaseosa", 90, 140.00f, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(2, "Galletita", 180, 45.50f, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(3, "Bife de chorizo", 18, 340.99f, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(4, "Bola de lomo", 16, 290, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(5, "Carne picada", 30, 220, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(6, "Pata de pollo", 14, 210.50f, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(7, "Pechuga de pollo", 13, 180, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(8, "Muslo de pollo", 31, 175, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(9, "Leche", 24, 50, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(10, "Pan lactal blanco", 24, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(11, "Pan lactal negro", 24, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(12, "Pan frances", 24, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(12, "Huevos", 24, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(13, "Costilla de Cerdo", 24, 315, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(14, "Panceta", 24, 315, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(15, "Tomate", 24, 20, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(16, "Papa", 24, 30, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(17, "Lechuga", 24, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(18, "Cebolla", 24, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(19, "Berenjena", 24, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(20, "Batata", 24, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(21, "Zapallo", 24, 15, Producto.ECategoria.verduleria));
        }

        public static void PrecargaListaEmpelados()
        {
            listaEmpleados.Add(new Empleado("Apu", "Nahasapeemapetilon", 41559381, 1, "apu"));
            credencialesUsuarios.Add("apu", "manyula");
            listaEmpleados.Add(new Empleado("Sanjay", "Nahasapeemapetilon", 42556963, 2, "sanjay"));
            credencialesUsuarios.Add("sanjay", "amoindia");
        }

        public static bool AgregarCliente(Cliente auxCliente)
        {
            if(!listaClientes.Exists(x => x.Dni.Equals(auxCliente.Dni)))
            {
                listaClientes.Add(auxCliente);
                return true;
            }

            return false;
        }

        public static bool AgregarArticuloAlCarrito(ArticuloCompra articuloCompra)
        {
            if(CompraEnCurso.Productos.Exists(x => x.Producto.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase)))
            {
                if (listaProductos.Find(x => x.Descripcion.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase)).Stock >=
                        (articuloCompra.Cantidad + CompraEnCurso.Productos.Find(x => x.Producto.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase)).Cantidad))
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }
            else
            {
                if (listaProductos.Find(x => x.Descripcion.Equals(articuloCompra.Producto,StringComparison.OrdinalIgnoreCase)).Stock >= articuloCompra.Cantidad)
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }

            return false;
        }

        public static bool FinalizarCompraActual(Cliente auxCliente)
        {
            CompraEnCurso.DateTime = DateTime.Now;

            compraEnCurso.Vendedor = empleadoActivo;
            compraEnCurso.Comprador = auxCliente;

            foreach (ArticuloCompra item in CompraEnCurso.Productos)
            {
                Producto p = listaProductos.Find(x => x.Descripcion.Equals(item.Producto,StringComparison.OrdinalIgnoreCase));
                p.Stock -= item.Cantidad;
            }

            listaVentas.Add(compraEnCurso);

            empleadoActivo.ListaTransacciones.Add(compraEnCurso);

            compraEnCurso = new Compra();

            return true;
        }


        /// <summary>
        /// Obtiene el stock total de una lista de productos
        /// </summary>
        /// <param name="lista">lista q ser recorrida</param>
        /// <returns></returns>
        public static int GetStockTotalLista()
        {
            int valorRetorno = 0;
            foreach (Producto item in listaProductos)
            {
                valorRetorno += item.Stock;
            }
            return valorRetorno;
        }

        public static List<Producto> GetProductosBajoStock()
        {
            List<Producto> nuevaLista = new List<Producto>();
            foreach (Producto item in listaProductos)
            {
                if(item.Stock < 10)
                {
                    nuevaLista.Add(item);
                }
            }
            return nuevaLista;
        }

        public static void LimpiarCarrito()
        {
            compraEnCurso.Productos.Clear();
            compraEnCurso.PrecioTotal = 0;
        }
    }
}
