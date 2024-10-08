CREATE TABLE personas (
    dni varchar(15) PRIMARY KEY,
    nombre varchar(15),
    apellido varchar(15),
    email varchar(50)
);

CREATE TABLE empleados (
    id_empleado int AUTO_INCREMENT PRIMARY KEY,
    dni varchar(15),
    sueldo decimal(10,2),
    rol varchar(15),
    fecha_igreso varchar(15),
    fecha_egreso varchar(15),
    FOREIGN KEY (dni) REFERENCES personas (dni)
);

CREATE TABLE vehiculos (
    id_vehiculo int AUTO_INCREMENT PRIMARY KEY,
    patente varchar(15) UNIQUE,
    modelo varchar(50),
    color varchar(10),
    id_empleado int,
    FOREIGN KEY (id_empleado) REFERENCES empleados (id_empleado)
);

CREATE TABLE estacionamiento (
    patente varchar(15) PRIMARY KEY,
    fecha_igreso varchar(15),
    lote int,
    FOREIGN KEY (patente) REFERENCES vehiculos(patente)
);

CREATE TABLE productos (
    codigo_barra int PRIMARY KEY,
    descripcion varchar(50),
    precio decimal(10,2)
);

CREATE TABLE ventas (
    dni varchar(15),
    id_empleado int,
    codigo_barra int,
    fecha_hora varchar(15),
    FOREIGN KEY (dni) REFERENCES personas(dni),
    FOREIGN KEY (id_empleado) REFERENCES empleados(id_empleado),
    FOREIGN KEY (codigo_barra) REFERENCES productos(codigo_barra)
);

-- 1. lista de empleados sin el sueldo
CREATE VIEW empleadosSinSueldo AS
    SELECT dni as 'DNI',
           rol as 'ROL',
           fecha_igreso as 'Fecha de Ingreso',
           fecha_egreso AS 'Fecha de Egreso'
    FROM empleados;

-- 2. lista de los empleados vigentes (fecha_egreso = null) (sin el sueldo)
CREATE VIEW empleadosVigentes AS
    SELECT dni as 'DNI',
           rol as 'ROL',
           fecha_igreso as 'Fecha de Ingreso'
    FROM empleados
    WHERE fecha_egreso IS NULL;

-- 3. lista de vehículos con los datos del empleado al que pertenece (sin el sueldo) (hacer join)
CREATE VIEW vehiculosConEmpleados AS
    SELECT v.patente as 'PATENTE',
           v.modelo as 'MODELO',
           v.color as 'COLOR',
           e.dni as 'DNI EMPLEADO',
           e.rol as 'ROL',
           e.fecha_igreso as 'Fecha Ingreso',
           e.fecha_egreso as 'Fecha Egreso'
    FROM vehiculos v 
    JOIN empleados e ON v.id_empleado = e.id_empleado;

-- 4. lista de personas que no sean empleados
CREATE VIEW personasNoEmpleados AS
    SELECT p.dni as 'DNI',
           p.nombre as 'NOMBRE',
           p.apellido as 'APELLIDO',
           p.email as 'EMAIL'
    FROM personas p 
    WHERE p.dni NOT IN (
        SELECT e.dni
        FROM empleados e
    );

-- 5. lista de todos los empleados que hayan venido a trabajar el 10 OCT 2023
CREATE VIEW empleadosTrabajandoEl10Oct2023 AS
    SELECT e.dni AS 'DNI EMPLEADO',
           e.rol AS 'ROL',
           e.fecha_igreso AS 'FECHA DE INGRESO'
    FROM empleados e 
    JOIN vehiculos v ON e.id_empleado = v.id_empleado
    JOIN estacionamiento es ON es.patente = v.patente
    WHERE es.fecha_igreso = '10/10/2023';

-- 6. lista de todos los productos comprados por la persona cuyo dni = 36789111
CREATE VIEW comprasDePersonaDni_36789111 AS
    SELECT p.codigo_barra as 'CODIGO',
           p.descripcion as 'DESCRIPCION',
           p.precio as 'PRECIO'
    FROM productos p 
    JOIN ventas v ON p.codigo_barra = v.codigo_barra
    WHERE v.dni = '36789111';

-- 7. cantidad total de ventas en monto (plata), generada por el vendedor id = 2
CREATE VIEW cantidadDeVentasId2 AS
    SELECT v.id_empleado AS 'ID EMPLEADO',
           SUM(p.precio) AS 'Cantidad total generada por el vendedor id = 2'
    FROM ventas v 
    JOIN productos p ON v.codigo_barra = p.codigo_barra
    WHERE v.id_empleado = 2;



INSERT INTO personas (dni, nombre, apellido, email) VALUES
('36789111', 'Juan', 'Pérez', 'juan.perez@example.com'),
('12345678', 'Ana', 'Gómez', 'ana.gomez@example.com'),
('87654321', 'Luis', 'Martínez', 'luis.martinez@example.com');

INSERT INTO empleados (dni, sueldo, rol, fecha_igreso, fecha_egreso) VALUES
('36789111', 3000.00, 'Vendedor', '01/01/2020', NULL),  -- Vigente
('12345678', 2500.00, 'Administrador', '15/02/2021', '10/10/2023'),  -- Egresado
('87654321', 4000.00, 'Gerente', '05/05/2019', NULL);  -- Vigente


INSERT INTO vehiculos (patente, modelo, color, id_empleado) VALUES
('ABC123', 'Toyota Corolla', 'Rojo', 1),  -- Juan
('DEF456', 'Honda Civic', 'Negro', 2),   -- Ana
('GHI789', 'Ford Fiesta', 'Azul', 3);    -- Luis


INSERT INTO estacionamiento (patente, fecha_igreso, lote) VALUES
('ABC123', '10/10/2023', 1),
('DEF456', '10/10/2023', 2),
('GHI789', '09/10/2023', 3);


INSERT INTO productos (codigo_barra, descripcion, precio) VALUES
(111111, 'Producto A', 50.00),
(222222, 'Producto B', 100.00),
(333333, 'Producto C', 150.00);

INSERT INTO ventas (dni, id_empleado, codigo_barra, fecha_hora) VALUES
('36789111', 1, 111111, '10/10/2023'), 
('36789111', 1, 222222, '10/10/2023'),  
('12345678', 2, 333333, '10/10/2023');  


INSERT INTO personas (dni, nombre, apellido, email) VALUES
('98765432', 'María', 'López', 'maria.lopez@example.com'),
('11223344', 'Pedro', 'Sánchez', 'pedro.sanchez@example.com'),
('44556677', 'Lucía', 'Fernández', 'lucia.fernandez@example.com');

INSERT INTO empleados (dni, sueldo, rol, fecha_igreso, fecha_egreso) VALUES
('98765432', 3200.00, 'Vendedor', '01/03/2022', NULL), 
('11223344', 2800.00, 'Asistente', '15/04/2021', '10/09/2023'), 
('44556677', 3500.00, 'Supervisor', '10/08/2020', NULL);  


INSERT INTO vehiculos (patente, modelo, color, id_empleado) VALUES
('JKL012', 'Chevrolet Tracker', 'Blanco', 4), 
('MNO345', 'Nissan Versa', 'Gris', 5),        
('PQR678', 'Kia Rio', 'Verde', 6);             


INSERT INTO estacionamiento (patente, fecha_igreso, lote) VALUES
('JKL012', '10/10/2023', 4), 
('MNO345', '10/10/2023', 5),  
('PQR678', '09/10/2023', 6);   


INSERT INTO productos (codigo_barra, descripcion, precio) VALUES
(444444, 'Producto D', 200.00),
(555555, 'Producto E', 300.00),
(666666, 'Producto F', 120.00);


INSERT INTO ventas (dni, id_empleado, codigo_barra, fecha_hora) VALUES
('98765432', 4, 444444, '10/10/2023'),
('11223344', 5, 555555, '10/10/2023'),  
('44556677', 6, 666666, '10/10/2023');  

INSERT INTO personas (dni, nombre, apellido, email) VALUES
('12312312', 'Carlos', 'Torres', 'carlos.torres@example.com'),
('32132132', 'Sofía', 'Reyes', 'sofia.reyes@example.com'),
('45645645', 'Diego', 'Hernández', 'diego.hernandez@example.com'),
('78978978', 'Valentina', 'Morales', 'valentina.morales@example.com'),
('14725836', 'Fernando', 'García', 'fernando.garcia@example.com');

CREATE USER 'usuario_vistas'@'localhost' IDENTIFIED BY 'G7kL9mX2#fP3qR';

GRANT SELECT ON empleadosSinSueldo TO 'usuario_vistas'@'localhost';
GRANT SELECT ON empleadosVigentes TO 'usuario_vistas'@'localhost';
GRANT SELECT ON vehiculosConEmpleados TO 'usuario_vistas'@'localhost';
GRANT SELECT ON personasNoEmpleados TO 'usuario_vistas'@'localhost';
GRANT SELECT ON empleadosTrabajandoEl10Oct2023 TO 'usuario_vistas'@'localhost';
GRANT SELECT ON comprasDePersonaDni_36789111 TO 'usuario_vistas'@'localhost';
GRANT SELECT ON cantidadDeVentasId2 TO 'usuario_vistas'@'localhost';

FLUSH PRIVILEGES;