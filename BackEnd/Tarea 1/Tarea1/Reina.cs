using System;
namespace Tarea1
{
    internal class Reina
    {
        const int N = 8;
        private int solucionesEncontradas = 0;
        private Tablero tablero;

        public Reina()
        {
            tablero = new Tablero();
        }

        public void Resolver()
        {
            int[] posicionesReinas = new int[N];
            ColocarReina(posicionesReinas, 0);

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            int sn = (N * N * N + N) / 2;
            Console.WriteLine($"\nNúmero total de soluciones encontradas: {solucionesEncontradas} [ Š(8) = {sn} ]");
            Console.ResetColor();
        }


        //Metodo recursivo que coloca una reina en cada fila del tablero hasta encontrar una convinacion valida.
        private void ColocarReina(int[] posicionesReinas, int fila)
        {
            if (fila == N)
            {
                solucionesEncontradas++;
                ImprimirCoordenadas(posicionesReinas);
                return;
            }

            for (int columna = 0; columna < N; columna++)
            {
                if (EsSeguro(posicionesReinas, fila, columna))
                {
                    posicionesReinas[fila] = columna;
                    ColocarReina(posicionesReinas, fila + 1);
                }
            }
        }


        // Se verifica si es seguro colocar una reina en una coordenada especifica
        private bool EsSeguro(int[] posicionesReinas, int fila, int columna)
        {
            for (int i = 0; i < fila; i++)
            {
                int otraColumna = posicionesReinas[i];
                if (otraColumna == columna || Math.Abs(otraColumna - columna) == Math.Abs(i - fila))
                    return false;
            }
            return true;
        }

        private void ImprimirCoordenadas(int[] posicionesReinas)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nSolución {solucionesEncontradas}:");

            for (int fila = 0; fila < N; fila++)
            {
                string coordenada = tablero.ObtenerCoordenada(fila, posicionesReinas[fila]);
                Console.WriteLine($"Posición {fila + 1}: {coordenada}");
            }
            Console.ResetColor();
        }
    }
}
