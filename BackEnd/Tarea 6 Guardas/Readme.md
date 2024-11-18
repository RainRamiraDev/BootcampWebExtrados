## Ejercicio:

1) Cear un programa que emule la operación de un kiosco.

2) Al iniciar el kiosco, se deberá cargar una lista de productos junto a su precio y stock.
   
3) El kiosco debe ser singleton para que el stock sea compartido entre múltiples hilos.
   
4) Los productos deben tener una bandera que indiquen si se pueden vender a menores de edad.
   
5) Los productos deben tener una bandera que indique si son alcohol.
   
6) Crear un objeto Usuario que tenga nombre y edad.
   
7) El quisco debe tener un método comprar() que tenga como atributos un cliente(Usuario)  y un producto.
   
8) Si el producto esta marcado como para mayores de edad, comprobar que el usuario sea mayor de edad antes de vender
el producto.

9) Si el producto esta marcado como alcohol, comprobar que no estemos en veda electoral antes de venderlo. (hagan una función "EnVeda()" que devuelva true o false, y hardcodeen el return)
    
10)  Antes de proceder con la venta de un producto, se debe confirmar que el producto este en stock.
    
11) Para estos controles, y cualquier otro control que se crea necesario,  utilizar condiciones de guarda.
    
12) Al vender un producto, se debe reducir el stock en 1.
    
13) Al vender un producto, cuando se reduzca el stock, recordar utilizar lock para protejer la reducción del stock.
    
14) Al ejecutar el programa, ejecutar con múltiples hilos (pongamos 5 como minimo, todos haciendo compras simultaneas).
    
15) Mostrar por consola el resultado de una compra. si la compra fue rechazada, la razón, si la compra fue aceptada, el stock que quede del producto.
