-el trabajo final esta basado en un sistema de administracion de un hotel

las siguientes son las tablas basicas:
-> existen 2 tipos de usuarios para el sistema, administrador y recepcionista
-> administrador (DNI, nombre, nombre usuario, contraseña, fecha_creacion, fecha_baja(null))
-> recepcionista (DNI, nombre, nombre usuario, contraseña, fecha_alta, fecha_baja (null), id_creador(que adminsitrador lo creo))
-> clientes (DNI, nombre, fecha_alta, id_creador(recepcionista))
-> cuartos (numero, disponible)
-> estacionamiento (numero_lote)


necesitamos que la base de datos:

-> registre las entradas y salidas de clientes a los cuartos, con fecha-hora(string)
-> registrar las acciones de los administradores y recepcionistas (que crean, que eliminan, etc.) (tabla de logs - id_usuario, mensaje)
-> registrar los tiempos de limpieza de los cuartos (luego de cada salida de un cliente, se debe tener en cuenta un tiempo de limpieza de cuarto, pedido
por el recepcionista)
-> que estacionamiento utilizo X cliente cuando visito las instalaciones


-entrega del script de creacion de las tablas.