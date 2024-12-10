## Ejercicio:

### agregar al ejercicio de la clase pasada:
- Un endpoint para que un usuario pueda pedir un libro
- Se debe ingresar a este endpoint una hora/fecha en la que se le da al usuario el libro, un nombre del libro y un id del usuario al que se le esta prestando el libro
- El endpoint debe dar una fecha de vencimiento del alquiler del libro, que sera 5 d?as despu?s de la fecha de pr?stamo
- El endpoint debe recibir un token de usuario con un id
- El endpoint debe revisar que el usuario que esta pidiendo el libro, y el usuario al que se esta dando el pr?stamo sean el mismo
- El endpoint solo debe poder ser accedido por el rol ?usuario?

- Modificar la creaci?n del jwt para que obtenga los datos desde configuraci?n (tanto en el program.cs como en el controlador)
- Modificar la conexi?n a la bd para que obtenga el connectionstring desde configuraci?n

- Aplicar inyecci?n de dependencias al obtener el DAO
s como en el controlador