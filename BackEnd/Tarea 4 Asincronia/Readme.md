## Ejercicio:
1) generar un array de enteros de tamaño 30000.
2) llenarlo de números aleatorios entre 0 y 45000. 
3) generar 2 hilos que se dividan el array mitad y mitad y busquen el mayor.
4) guardar el mayor en la variable "mayor".
5) utilizar lock para asegurar la integridad de la respuesta.

----
## El uso de lock en C#

Es una técnica de sincronización de hilos que ayuda a evitar condiciones de carrera (race conditions) cuando varios hilos intentan acceder y modificar un recurso compartido al mismo tiempo.

### ¿Qué es una Condición de Carrera?
Una condición de carrera ocurre cuando dos o más hilos intentan acceder a un recurso compartido (como una variable) y al menos uno de los hilos lo modifica. Si la sincronización entre estos hilos no se maneja correctamente, los resultados pueden ser impredecibles, lo que puede generar errores o comportamientos no deseados.

Por ejemplo, imagina que dos hilos intentan incrementar un contador simultáneamente. Si no hay sincronización, es posible que ambos hilos lean el valor actual del contador, incrementen ese valor y lo escriban de nuevo, pero sin tener en cuenta que ya se hizo un incremento, lo que causaría que uno de los incrementos se pierda.

### ¿Cómo Funciona el lock?
El lock se utiliza para envolver el acceso a un recurso compartido y garantizar que solo un hilo a la vez pueda ejecutar ese bloque de código. La palabra clave lock se utiliza con un objeto llamado "bloqueador" (que puede ser cualquier objeto de tipo Object), que actúa como un candado. Cuando un hilo entra en el bloque lock, toma el candado, y los otros hilos que intenten acceder a ese mismo bloque de código se detendrán hasta que el primer hilo termine y libere el candado.