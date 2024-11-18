using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GuardasApp
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public bool AptoMenores { get; set; }
        public bool EsAlcohol { get; set; }

        public Producto()
        {
            
        }

        public Producto(string nombre,double precio, int stock,bool aptoMenores,bool esAlcohol)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.AptoMenores = aptoMenores;
            this.EsAlcohol = esAlcohol;
        }


        public void QuitarStock(Producto producto)
        {
          
            if (producto.Stock <= 0)
            {
                Console.WriteLine("No hay stock suficiente para realizar la compra.");
                return;
            }
            producto.Stock -= 1;
        }


        public bool EnStock(Producto producto)
        {
            return producto.Stock > 0;
        }


        public bool TieneAlcohol(Producto producto)
        {
            return producto.EsAlcohol;
        }

        public string MostrarProductos()
        {
            return $"Nombre: {Nombre}\nPrecio: {Precio}\nStock: {Stock}";
        }

    }
}
