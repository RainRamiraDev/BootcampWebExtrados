using Resolver8Piezas.Excepcion;
using solucionador.Interface;

namespace Resolver8Piezas.Logica
{
    public class OchoPiezas
    {
        const int N = 8;
        private int solucionesEncontradas = 0;
        private Tablero tablero;
        private List<int[]> soluciones = new List<int[]>(); 
        private IPieza pieza; 

        public OchoPiezas(IPieza pieza)
        {
            this.pieza = pieza;
            tablero = new Tablero();
        }

        public void Resolver()
        {
            try
            {
                int[] posicionesPiezas = new int[N];
                Console.WriteLine("Iniciando el proceso de resolución...");
                ColocarPieza(posicionesPiezas, 0);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (solucionesEncontradas > 0)
                {
                    int sn = (N * N * N + N) / 2;
                    Console.WriteLine($"\nNúmero total de soluciones encontradas: {solucionesEncontradas} [ Š(8) = {sn} ]");
                }
                else
                {
                    throw new SinSolucionExcepcion();
                }
            }
            catch (SinSolucionExcepcion ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Error: {ex.StackTrace}");
                Console.WriteLine("--------------------------------");
                Console.ResetColor();
            }
        }


        // Metodo recursivo que coloca una pieza en cada fila del tablero hasta encontrar una combinación válida.
        private void ColocarPieza(int[] posicionesPiezas, int fila)
        {
            if (fila == N)
            {
                if (!EsSimetrica(posicionesPiezas))
                {
                    solucionesEncontradas++;
                    soluciones.Add((int[])posicionesPiezas.Clone());
                    ImprimirCoordenadas(posicionesPiezas);
                }
                return; 
            }

            // Intentamos colocar la pieza en cada columna de la fila.
            for (int columna = 0; columna < N; columna++)
            {
                // Usamos el método EsSeguro para verificar si es seguro colocar la pieza.
                if (pieza.EsSeguro(posicionesPiezas, fila, columna))
                {
                    posicionesPiezas[fila] = columna;
                    ColocarPieza(posicionesPiezas, fila + 1);
                    posicionesPiezas[fila] = -1; 
                }
            }
        }


        // Imprime las coordenadas de una solución.
        private void ImprimirCoordenadas(int[] posicionesPiezas)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSolución {solucionesEncontradas}:");
            for (int fila = 0; fila < N; fila++)
            {
                string coordenada = tablero.ObtenerCoordenada(fila + 1, posicionesPiezas[fila] + 1);
                Console.WriteLine($"Posición {fila + 1}: {coordenada}");
            }
            Console.ResetColor();
        }

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
                    Console.WriteLine("Solución duplicada encontrada, no se agrega.");
                    return true; // Solución duplicada, detener aquí.
                }
            }
            return false; // Solución única, continúa.
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
                nuevaSolucion[N - 1 - i] = solucion[i];
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
    }
}
