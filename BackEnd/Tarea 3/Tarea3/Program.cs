using Tarea3.Data;
using UserDao.Dao;
using UserDao.Entity;

Console.WriteLine("Programa iniciado");

bool continuar = true;

DbHelper helper = new DbHelper();

while (continuar)
{
    // Mostrar el menú
    Console.Clear();
    Console.WriteLine("Menú de opciones:");
    Console.WriteLine("1. Ver todos los usuarios");
    Console.WriteLine("2. Ver un usuario por ID");
    Console.WriteLine("3. Insertar un nuevo usuario");
    Console.WriteLine("4. Actualizar un usuario");
    Console.WriteLine("5. Eliminar un usuario (Lógica)");
    Console.WriteLine("6. Salir");
    Console.Write("Selecciona una opción (1-6): ");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // Ver todos los usuarios
            helper.GetAll();
            break;

        case "2":
            // Ver un usuario por ID
            Console.WriteLine("Inserte el Id a buscar");
            int id = Convert.ToInt32(Console.ReadLine());
            helper.GetById(id);
            break;

        case "3":
            // Insertar un nuevo usuario
            Console.WriteLine("Inserte el nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Inserte la Edad");
            int edad = Convert.ToInt32(Console.ReadLine());
            helper.Insert(nombre,edad);
            break;

        case "4":
            // Actualizar un usuario
            Console.WriteLine("Inserte el Id a actualizar");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserte el nuevo nombre");
            string nuevoNombre = Console.ReadLine();
            Console.WriteLine("Inserte la nueva edad");
            int nuevaEdad = Convert.ToInt32(Console.ReadLine());
            helper.Update(idToUpdate,nuevoNombre,nuevaEdad);
            break;

        case "5":
            // Eliminar un usuario (lógica)
            Console.WriteLine("Indique el Id a eliminar");
            int IdToErrase = Convert.ToInt32(Console.ReadLine());
            helper.Delete(IdToErrase);
            break;

        case "6":
            // Salir del programa
            continuar = false;
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción no válida. Por favor, elige una opción entre 1 y 6.");
            break;
    }

    if (continuar)
    {
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}