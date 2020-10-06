using System;
using System.Collections.Generic;
using System.IO;
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
        static TextWriter txtWriter;

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

            string txtName = $"../Tickets/recibo_{CompraEnCurso.DateTime.ToString("yyyy-MM-dd-HH-mm-ss")}_{CompraEnCurso.Vendedor.Dni}_{CompraEnCurso.Comprador.Dni}.txt";

            txtWriter = new StreamWriter(@txtName);

            txtWriter.Write(Comercio.CompraEnCurso.ToString());

            txtWriter.Close();

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

        public static void QuitarProductoCarrito(string descripcion)
        {
            ArticuloCompra auxArt = compraEnCurso.Productos.Find(x => x.Producto.Equals(descripcion));
            compraEnCurso.Productos.Remove(auxArt);
            compraEnCurso.PrecioTotal -= auxArt.PrecioFinal;
        }

        public static void AgregarStock(string descripcion, int cantidad)
        {
            listaProductos.Find(x => x.Descripcion.Equals(descripcion)).Stock += cantidad;
        }

        public static void PrecargaListaProductos()
        {
            listaProductos.Add(new Producto(1, "Gaseosa", 90, 140.00f, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(2, "Galletita", 180, 45.50f, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(3, "Bife de chorizo", 3, 340.50f, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(4, "Bola de lomo", 16, 290, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(5, "Carne picada", 30, 220, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(6, "Pata de pollo", 14, 210.50f, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(7, "Pechuga de pollo", 13, 180, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(8, "Muslo de pollo", 8, 175, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(9, "Leche", 24, 50, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(10, "Pan lactal blanco", 2, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(11, "Pan lactal negro", 36, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(12, "Pan frances", 48, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(13, "Huevos", 55, 10, Producto.ECategoria.almacen));
            listaProductos.Add(new Producto(14, "Costilla de Cerdo", 27, 315, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(15, "Panceta", 6, 315, Producto.ECategoria.carniceria));
            listaProductos.Add(new Producto(16, "Tomate", 4, 20, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(17, "Papa", 19, 30, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(18, "Lechuga", 7, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(19, "Cebolla", 37, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(20, "Berenjena", 9, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(21, "Batata", 21, 15, Producto.ECategoria.verduleria));
            listaProductos.Add(new Producto(22, "Zapallo", 24, 15, Producto.ECategoria.verduleria));
        }

        public static void PrecargaListaClientes()
        {
            listaClientes.Add(new Cliente("Homero", "Simpson", 19564578, 1));
            listaClientes.Add(new Cliente("Marge", "Simpson", 20124578, 2));
            listaClientes.Add(new Cliente("Lisa", "Simpson", 40599578, 3));
            listaClientes.Add(new Cliente("Bart", "Simpson", 39564578, 4));
            listaClientes.Add(new Cliente("Abraham", "Simpson", 4545578, 5));
            listaClientes.Add(new Cliente("Armando", "Barreda", 7545578, 6));
            listaClientes.Add(new Cliente("Carl", "Carlson", 16545578, 7));
            listaClientes.Add(new Cliente("Montgomery", "Burns", 2545578, 8));
            listaClientes.Add(new Cliente("Milhouse", "Van Houten", 41545578, 9));
            listaClientes.Add(new Cliente("Ned", "Flanders", 15598478, 10));
            listaClientes.Add(new Cliente("Professor", "Frink", 21564328, 11));
            listaClientes.Add(new Cliente("Barney", "Gumble", 18465218, 12));
            listaClientes.Add(new Cliente("Bob", "Patiño", 13512648, 13));
            listaClientes.Add(new Cliente("Edna", "Krabappel", 20543278, 14));
            listaClientes.Add(new Cliente("Nelson", "Muntz", 38512178, 15));
            listaClientes.Add(new Cliente("Kent", "Brockman", 25511231, 16));
            listaClientes.Add(new Cliente("Otto", "Mann", 32145578, 17));
            listaClientes.Add(new Cliente("Patty", "Bouvier", 11234578, 18));
            listaClientes.Add(new Cliente("Selma", "Bouvier", 11234579, 19));
            listaClientes.Add(new Cliente("Moe", "Szyslak", 16111178, 20));
        }

        public static void PrecargaListaVentas()
        {
            listaVentas.Add(new Compra(listaClientes[0], listaEmpleados[0], 570.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[2], listaEmpleados[1], 1570.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[3], listaEmpleados[0], 2380.75f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[4], listaEmpleados[0], 4920.75f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[1], listaEmpleados[1], 350.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[0], listaEmpleados[0], 420.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[17], listaEmpleados[1], 1900.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[12], listaEmpleados[1], 170.25f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[9], listaEmpleados[0], 145.25f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[18], listaEmpleados[1], 570.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[6], listaEmpleados[0], 990.75f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[13], listaEmpleados[1], 435.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[5], listaEmpleados[0], 260.25f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[1], listaEmpleados[0], 785.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[3], listaEmpleados[0], 95.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[12], listaEmpleados[1], 695.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[15], listaEmpleados[0], 365.25f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[14], listaEmpleados[0], 125.75f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[15], listaEmpleados[1], 565.50f, DateTime.Now));
            listaVentas.Add(new Compra(listaClientes[9], listaEmpleados[0], 5190.50f, DateTime.Now));
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[0]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[1]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[2]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[3]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[4]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[5]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[6]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[7]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[8]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[9]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[10]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[11]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[12]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[13]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[14]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[15]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[16]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[17]);
            listaEmpleados[1].ListaTransacciones.Add(listaVentas[18]);
            listaEmpleados[0].ListaTransacciones.Add(listaVentas[19]);
        }
    }
}
