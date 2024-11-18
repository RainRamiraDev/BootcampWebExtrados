using GuardasApp;


    // Llamada a objetos
    Kiosco kiosco = Kiosco.Instance;
    Object bloqueador = new Object();

    //Producto alcohólico con un cliente mayor de edad
    Producto producto1 = new Producto("Vino", 4500.00, 25, false, true); 
    Usuario cliente1 = new Usuario("Carlos", 25);
    await kiosco.EjecutarComprasAsync(cliente1, producto1, bloqueador);

    //roducto no apto para menores con un cliente menor de edad
    Producto producto2 = new Producto("Cerveza", 3000.00, 10, false, true);
    Usuario cliente2 = new Usuario("Lucas", 16);
    await kiosco.EjecutarComprasAsync(cliente2, producto2, bloqueador);

    //Producto sin stock con un cliente mayor de edad
    Producto producto3 = new Producto("Gaseosa", 1500.00, 0, true, false);
    Usuario cliente3 = new Usuario("Ana", 30);
    await kiosco.EjecutarComprasAsync(cliente3, producto3, bloqueador);

    //Producto para mayores de edad, pero en veda electoral
    Producto producto4 = new Producto("Vino Tinto", 5000.00, 20, false, true);
    Usuario cliente4 = new Usuario("Javier", 40); 
    await kiosco.EjecutarComprasAsync(cliente4, producto4, bloqueador);

    //Producto normal con stock suficiente y cliente mayor de edad
    Producto producto5 = new Producto("Agua Mineral", 800.00, 50, true, false);
    Usuario cliente5 = new Usuario("Sofía", 28);
    await kiosco.EjecutarComprasAsync(cliente5, producto5, bloqueador);

