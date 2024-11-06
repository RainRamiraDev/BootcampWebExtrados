# Tarea Número 1: Resolver el problema de las 8 Reinas

Este programa resuelve el clásico problema de las 8 reinas utilizando el algoritmo de **backtracking**. El objetivo es colocar 8 reinas en un tablero de ajedrez de tamaño 8x8 de manera que ninguna reina se amenace a otra. 

## Descripción del Problema

El problema de las 8 reinas es un rompecabezas propuesto por el ajedrecista alemán **Max Bezzel** en 1848. En el ajedrez, la reina puede atacar a cualquier pieza que se encuentre en su misma fila, columna o diagonal. El desafío consiste en encontrar una disposición de las 8 reinas en el tablero donde no se amenacen entre sí.

### Representación de las Reinas

Para representar la ubicación de las reinas en el tablero, se utiliza un vector de tamaño 8, donde cada índice del vector corresponde a una fila y el valor en ese índice representa la columna de la reina en esa fila.

Por ejemplo:
- Un vector como `(3, 1, 6, 2, 8, 6, 4, 7)` indica que:
  - La reina en la fila 1 está en la columna 3.
  - La reina en la fila 2 está en la columna 1.
  - La reina en la fila 3 está en la columna 6.
  - Y así sucesivamente...

<p align="center">
  <img src="https://mguerrero.me/wp-content/uploads/2020/05/posicion-1-2.png" alt="Tablero de Ajedre">
</p>

### Restricciones del Problema

Las reinas no pueden estar en la misma:
- **Fila**: cada reina debe estar en una fila distinta.
- **Columna**: no puede haber más de una reina en una columna.
- **Diagonal**: dos reinas no pueden estar en la misma diagonal. Esto se asegura verificando que las diferencias entre las filas y las columnas no sean iguales.

El algoritmo utilizado en este programa implementa una **búsqueda en profundidad** con **backtracking** para encontrar todas las soluciones posibles.

### Soluciones

El problema tiene **92 soluciones** posibles, de las cuales **12 son esencialmente distintas**, ya que las otras pueden obtenerse mediante rotaciones o reflexiones de las soluciones únicas. Cada solución representa una disposición de las 8 reinas en el tablero.

### Rotaciones y Reflexiones

Las soluciones del problema de las 8 reinas pueden ser **rotadas** o **reflejadas** para generar nuevas disposiciones que son esencialmente las mismas. Las transformaciones que se consideran son:

- **Rotación de 90 grados**: las filas del tablero se convierten en columnas.
- **Rotación de 180 grados**: el tablero se gira completamente, cambiando el orden de las filas y columnas.
- **Rotación de 270 grados**: una rotación de 90 grados en sentido contrario.
- **Reflexión Horizontal**: las columnas del tablero se invierten.
- **Reflexión Vertical**: las filas se invierten.
- **Reflexión Diagonal Principal**: las filas y las columnas se intercambian siguiendo la diagonal principal del tablero.
- **Reflexión Diagonal Secundaria**: las filas y las columnas se intercambian siguiendo la diagonal secundaria del tablero.

Estas rotaciones y reflexiones se utilizan para identificar soluciones que son **esencialmente la misma**, evitando contarlas más de una vez. Así, aunque el algoritmo pueda generar muchas configuraciones de soluciones, solo se consideran las soluciones únicas.

## Algoritmo Implementado

El algoritmo utilizado para resolver el problema es **Backtracking (Vuelta Atrás)**. La idea es intentar colocar una reina en una posición válida y luego continuar con las siguientes reinas. Si en algún momento se encuentra una configuración inválida, el algoritmo retrocede y prueba con otra posición.

### Funciones Principales

1. **`EsSeguro(int[] posicionesReinas, int fila, int columna)`**: Verifica si es seguro colocar una reina en la fila y columna dadas, asegurándose de que no esté en la misma fila, columna o diagonal que alguna reina ya colocada.

2. **`ColocarReina(int[] posicionesReinas, int fila)`**: Coloca una reina en una fila específica y luego intenta colocar reinas en las filas siguientes. Si se alcanza la fila 8 (todas las reinas han sido colocadas), se imprime la solución.

3. **`Resolver()`**: Inicializa el proceso de resolución, colocando las reinas en el tablero utilizando el método `ColocarReina` y luego muestra el número total de soluciones encontradas.

### Cálculo de la Constante Š(n)

El número Š(n) es una constante que indica la suma de las casillas donde se pueden ubicar las n reinas para todas las soluciones de un tablero de tamaño n x n. Este valor se calcula con la siguiente fórmula: `Š(n) = (n^3 + n) / 2`

