using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsincroniaApp
{
    public class ArrayApp
    {
        private int[] enteros;
        private Random random;
        private Object bloqueador;
        private int mayor;

        public ArrayApp()
        {
            enteros = new int[30000];
            random = new Random();
            bloqueador = new Object();
            mayor = int.MinValue;
        }

        //llenar el array con números aleatorios
        public async Task LlenarArrayAsync()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < enteros.Length; i++)
                {
                    enteros[i] = random.Next(0, 45001);
                }
            });
        }

        //buscar el mayor valor en una porción del array
        public void BuscarMayorMitad(int inicio, int fin)
        {
            int mayorLocal = enteros[inicio];
            for (int i = inicio; i < fin; i++)
            {
                if (enteros[i] > mayorLocal)
                {
                    mayorLocal = enteros[i];
                }
            }

            //lock para actualizar la variable compartida "mayor"
            lock (bloqueador)
            {
                if (mayorLocal > mayor)
                {
                    mayor = mayorLocal;
                }
            }
        }

        //buscar el mayor valor utilizando dos tareas asincrónicas
        public async Task<int> BuscarMayorAsync()
        {
            int mitad = enteros.Length / 2;

            Task tarea1 = Task.Run(() => BuscarMayorMitad(0, mitad));
            Task tarea2 = Task.Run(() => BuscarMayorMitad(mitad, enteros.Length));

            await Task.WhenAll(tarea1, tarea2);
            return mayor;
        }

        //Mostrar el resultado
        public async Task MostrarResultadoAsync()
        {
            Console.WriteLine("Llenando el array...");
            await LlenarArrayAsync();

            Console.WriteLine("\nBuscando el mayor valor...");
            int mayor = await BuscarMayorAsync();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nEl mayor valor en el array es: {mayor}");
            Console.ResetColor();
        }
    }
}
