using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    internal class Tablero
    {
        private List<String> Coordenadas = new List<String>();

        
        public Tablero()
        {

            AgregarCoordenadas();

        }

        public void AgregarCoordenadas()
        {
            string[] columnas = { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int fila = 1; fila <= 8; fila++)
            {
                foreach (string columna in columnas)
                {
                    Coordenadas.Add($"{columna}{fila}");
                }
            }


        }

        public void ObtenerCoordenadas()
        {
            for (int i = 0; i < Coordenadas.Count; i++)
            {
                // Imprime la coordenada seguida de un |, excepto después de la última
                if (i < Coordenadas.Count - 1)
                {
                    Console.Write($"{Coordenadas[i]} | ");
                }
                else
                {
                    Console.Write(Coordenadas[i]); // Sin el separador al final
                }
            }
            Console.WriteLine(); // Nueva línea al final
        }


    }
}
