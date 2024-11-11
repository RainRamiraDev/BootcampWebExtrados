using System;
using System.Collections.Generic;

namespace Tarea1
{
    internal class Reina
    {
        const int N = 8;
        private int solucionesEncontradas = 0;
        private Tablero tablero;
        private List<int[]> soluciones = []; // Almacena todas las soluciones encontradas.

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

        // Metodo recursivo que coloca una reina en cada fila del tablero hasta encontrar una combinación válida.
        private void ColocarReina(int[] posicionesReinas, int fila)
        {
            if (fila == N)
            {
                solucionesEncontradas++;
                if (!EsSimetrica(posicionesReinas))
                {
                    soluciones.Add((int[])posicionesReinas.Clone());
                    ImprimirCoordenadas(posicionesReinas, true);
                }
                else
                {
                    ImprimirCoordenadas(posicionesReinas, false);
                }
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

        // Verifica si es seguro colocar una reina en una coordenada específica.
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

        // Verifica si la solución ya está en la lista de soluciones únicas.
        private bool EsSimetrica(int[] solucion)
        {
            foreach (var solucionExistente in soluciones)
            {
                if (SonIguales(solucion, solucionExistente) ||
                    SonIguales(Rotar90(solucion), solucionExistente) ||
                    SonIguales(Rotar180(solucion), solucionExistente) ||
                    SonIguales(Rotar270(solucion), solucionExistente) ||
                    SonIguales(ReflejarHorizontal(solucion), solucionExistente) ||
                    SonIguales(ReflejarVertical(solucion), solucionExistente) ||
                    SonIguales(ReflejarDiagonalPrincipal(solucion), solucionExistente) ||
                    SonIguales(ReflejarDiagonalSecundaria(solucion), solucionExistente))
                {
                    return true;
                }
            }
            return false;
        }

        // Función para comparar dos soluciones.
        private bool SonIguales(int[] solucion1, int[] solucion2)
        {
            for (int i = 0; i < N; i++)
            {
                if (solucion1[i] != solucion2[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Funciones de rotación y reflexión.
        public int[] Rotar90(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[solucion[i]] = N - 1 - i;
            }
            return nuevaSolucion;
        }

        public int[] Rotar180(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[i] = N - 1 - solucion[N - 1 - i];
            }
            return nuevaSolucion;
        }

        public int[] Rotar270(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[N - 1 - solucion[i]] = i;
            }
            return nuevaSolucion;
        }

        public int[] ReflejarHorizontal(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[i] = N - 1 - solucion[i];
            }
            return nuevaSolucion;
        }

        public int[] ReflejarVertical(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[N - 1 - i] = solucion[i]; // Reflejo de izquierda a derecha
            }
            return nuevaSolucion;
        }


        public int[] ReflejarDiagonalPrincipal(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[solucion[i]] = i;
            }
            return nuevaSolucion;
        }

        public int[] ReflejarDiagonalSecundaria(int[] solucion)
        {
            int[] nuevaSolucion = new int[N];
            for (int i = 0; i < N; i++)
            {
                nuevaSolucion[N - 1 - solucion[i]] = N - 1 - i;
            }
            return nuevaSolucion;
        }


        // Imprime las coordenadas de una solución.
        private void ImprimirCoordenadas(int[] posicionesReinas, bool esUnica)
        {
            if (esUnica)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Resaltamos las soluciones únicas
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // Soluciones simétricas
            }

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