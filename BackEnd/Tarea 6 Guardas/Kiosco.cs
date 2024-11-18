using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardasApp
{
    public class Kiosco
    {
        private static Kiosco instance = null;

        private Usuario cliente;
        private List<Producto> Productos;
        private Object bloqueador;
        private Kiosco() {

            Productos = new List<Producto>();
            cliente = new Usuario();
            bloqueador = new Object();
        }

        public static Kiosco Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kiosco();
                }
                return instance;
            }
        }

        public void CargarProductos(Producto nuevoProducto)
        {
            Productos.Add(nuevoProducto);
        }

        public void MostrarProductos()
        {
            foreach (Producto p in Productos)
            {
                Console.WriteLine(p.MostrarProductos());
            }
        }
        public bool EnVeda()
        {
            DateTime fechaActual = DateTime.Now;

            //Elecciones Argentina 2025
            DateTime fechaVeda = new DateTime(2025, 10, 6);
            bool revizarVeda = fechaActual.Date == fechaVeda.Date;
            return revizarVeda;
        }

        public string Comprar(Usuario cliente, Producto producto, object bloqueador)
        {
            string mensaje = "";

            // Verificar si el producto es apto para menores
            if (!producto.AptoMenores && !cliente.MayorDeEdad(cliente))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                mensaje += "No puede comprar porque es menor de edad.\n";
            }

            // Verificar si el producto es alcohol y estamos en veda electoral
            if (producto.EsAlcohol && EnVeda())
            {
                Console.ForegroundColor= ConsoleColor.DarkMagenta;
                mensaje += "No se puede comprar alcohol en Veda electoral.\n";

            }

            // Verificar stock
            if (!producto.EnStock(producto))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                mensaje += "El producto no se encuentra en stock.\n";
            }

            // Si hay algún mensaje, no se procede con la compra
            if (!string.IsNullOrEmpty(mensaje))
            {
                return mensaje;
            }

            // Si no hay errores, proceder con la compra bajo el bloqueo
            lock (bloqueador)
            {
                producto.QuitarStock(producto);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            return "Compra realizada con éxito.\n";

        }

        public async Task<string> ComprarAsync(Usuario cliente, Producto producto, object bloqueador)
        {
            // Ejecuta la compra en un hilo separado sin bloquear el hilo principal.
            return await Task.Run(() => Comprar(cliente, producto, bloqueador));
        }

        public async Task EjecutarComprasAsync(Usuario cliente, Producto producto, object bloqueador)
        {
            var tareas = new List<Task<string>>();

            // Crear 5 tareas de compra
            for (int i = 0; i < 5; i++)
            {
                tareas.Add(ComprarAsync(cliente, producto, bloqueador));
            }

            // Esperar que todas las compras se completen
            var resultados = await Task.WhenAll(tareas);

            // Mostrar los resultados de las compras
            foreach (var resultado in resultados)
            {
                Console.WriteLine(resultado);
            }
        }

    }
}
