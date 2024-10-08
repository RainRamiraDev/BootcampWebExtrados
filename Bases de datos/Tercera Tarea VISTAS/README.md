ejercicios vistas:

teniendo 5 tablas:

-personas (dni, nombre, apellido, email )
-empleados (id_empleado, dni, sueldo, rol("vendedor"-"manager"), fehca_ingreso(varchar), fecha_egreso(varchar)(null)) - fecha egreso = null significa que todabia es empleado.\*\*\*\*
-vehiculos (id_vehiculo, patente, modelo, color, id_empleado)
-estacionamiento (patente, fecha ingreso(varchar), lote) -- lleva el regristro de quienes estacionaron donde cada dia
-productos (codigo_barra, descripcion, precio)
-ventas (dni (que compro), id_empleado (el que vendio),codigo_barras, fecha_hora)

generar un usuario nuevo para la BD que solo tenga acceso a las siguientes vistas:

1. lista de empleados sin el sueldo
2. lista de los empelados vigentes (fecha_egreso = null) (sin el sueldo)
3. lista de vehiculos con los datos del empleado al que pertence (sin el sueldo) (hacer join)
4. lista de personas que no sean empleados
5. lista de todos los empleados que hayan venido a trabajar el 10 OCT 2023 (tomar aquellos que usaron estacionamiento como los que se presentaron a trabajar)
6. lista de todos los productos comprados por la persona cuyo dni = 36789111
7. cantidad total de ventas en monto(plata), generada por el vendedor id = 2
