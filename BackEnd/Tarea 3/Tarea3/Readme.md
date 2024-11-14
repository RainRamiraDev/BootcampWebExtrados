## Ejercicio 1

 - Crear una base de datos con una sola tabla: “Usuarios”
 - esta tabla deberá tener Id, Nombre y Edad
 - Crear 2 funciones: una que traiga la lista de usuarios de la tabla Usuarios y la muestre por pantalla, y una que busque y traiga la información de un usuario a partir de su Id

## Ejercicio:

- Siguiendo con el ejercicio anterior de este mismo documento:

- Crear un DAO, en una biblioteca de clases aparte, que permita hacer un CRUD (Create - Read - Update - Delete, crear -leer - actualizar - borrar) a la tabla “Usuarios”.

- Se deberá enviar las variables de tal forma que nos proteja de SQL injection

- Se deberá tener en cuenta el uso de “using” para no dejar conexiones abiertas con la base de datos
- El borrado de datos debe ser lógico

- Consumir el DAO de la biblioteca desde el program.cs
