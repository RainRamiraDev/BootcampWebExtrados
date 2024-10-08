CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    dni VARCHAR(15),
    nombre VARCHAR(20),
    nombre_usuario VARCHAR(20),
    contrasenia VARCHAR(10),
    fecha_alta VARCHAR(10), 
    fecha_baja VARCHAR(10) -- admite NULL
);

CREATE TABLE administradores (
    id_administrador INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    CONSTRAINT FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);

CREATE TABLE recepcionistas (
    id_recepcionista INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    id_creador INT,
    CONSTRAINT FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    CONSTRAINT FOREIGN KEY (id_creador) REFERENCES administradores(id_administrador)
);

CREATE TABLE clientes (
    id_cliente INT PRIMARY KEY AUTO_INCREMENT,
    dni VARCHAR(15),
    nombre VARCHAR(15),
    fecha_alta VARCHAR(10), 
    id_creador INT,
    CONSTRAINT FOREIGN KEY (id_creador) REFERENCES recepcionistas(id_recepcionista)
);

CREATE TABLE cuartos (
    id_cuarto INT PRIMARY KEY AUTO_INCREMENT,
    numero INT,
    disponible BIT
);

CREATE TABLE estacionamientos (
    id_lote INT PRIMARY KEY AUTO_INCREMENT,
    numero_lote INT
);

CREATE TABLE acciones (
    id_accion INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    mensaje VARCHAR(100),
    fecha_hora VARCHAR(20), 
    CONSTRAINT FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario) 
);

CREATE TABLE ocupacion_cuartos (
    id_ocupacion_cuarto INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT,
    id_cuarto INT,
    fecha_hora VARCHAR(20),
    CONSTRAINT FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    CONSTRAINT FOREIGN KEY (id_cuarto) REFERENCES cuartos(id_cuarto)
);

CREATE TABLE limpieza_cuartos (
    id_limpieza_cuartos INT PRIMARY KEY AUTO_INCREMENT,
    id_cuarto INT,
    tiempo_estimado VARCHAR(10), 
    CONSTRAINT FOREIGN KEY (id_cuarto) REFERENCES cuartos(id_cuarto)
);

CREATE TABLE cliente_estacionamientos (
    id_cliente_estacionamiento INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT,
    id_lote INT,
    CONSTRAINT FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    CONSTRAINT FOREIGN KEY (id_lote) REFERENCES estacionamientos(id_lote)
);

INSERT INTO usuarios (dni, nombre, nombre_usuario, contrasenia, fecha_alta, fecha_baja) VALUES
('12345678A', 'Juan', 'juanito', 'pass123', '01/01/2023', NULL),
('87654321B', 'Maria', 'mari', 'pass456', '15/01/2023', NULL),
('23456789C', 'Pedro', 'pedro123', 'pass789', '01/02/2023', NULL),
('34567890D', 'Ana', 'anita', 'pass321', '15/02/2023', '01/06/2023'),
('45678901E', 'Luis', 'lucho', 'pass654', '01/03/2023', NULL),
('56789012F', 'Sofia', 'sofi', 'pass987', '15/03/2023', NULL),
('67890123G', 'Carlos', 'carlitos', 'pass852', '01/04/2023', NULL),
('78901234H', 'Laura', 'lau', 'pass963', '15/04/2023', NULL),
('89012345I', 'David', 'davidito', 'pass159', '01/05/2023', NULL),
('90123456J', 'Elena', 'ele', 'pass753', '15/05/2023', NULL);

INSERT INTO administradores (id_usuario) VALUES
(1),
(2),
(3),
(1),
(2),
(3),
(1),
(2),
(3),
(1);

INSERT INTO recepcionistas (id_usuario, id_creador) VALUES
(4, 1),
(5, 2),
(6, 3),
(7, 1),
(8, 2),
(9, 3),
(4, 1),
(5, 2),
(6, 3),
(7, 1);

INSERT INTO clientes (dni, nombre, fecha_alta, id_creador) VALUES
('11223344A', 'Fernando', '01/05/2023', 1),
('22334455B', 'Gina', '15/05/2023', 2),
('33445566C', 'Hector', '01/06/2023', 3),
('44556677D', 'Isabel', '15/06/2023', 4),
('55667788E', 'Jorge', '01/07/2023', 5),
('66778899F', 'Karla', '15/07/2023', 6),
('77889900G', 'Luis', '01/08/2023', 7),
('88990011H', 'Monica', '15/08/2023', 8),
('99001122I', 'Nicolas', '01/09/2023', 9),
('10111213J', 'Olga', '15/09/2023', 4);

INSERT INTO cuartos (numero, disponible) VALUES
(101, 1),
(102, 1),
(103, 0),
(104, 1),
(105, 0),
(106, 1),
(107, 1),
(108, 0),
(109, 1),
(110, 0);

INSERT INTO estacionamientos (numero_lote) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10);

INSERT INTO acciones (id_usuario, mensaje, fecha_hora) VALUES
(1, 'Usuario registrado', '01/01/2023 08:00'),
(2, 'Inicio de sesión', '15/01/2023 09:00'),
(3, 'Actualización de perfil', '01/02/2023 10:00'),
(4, 'Contraseña cambiada', '15/02/2023 11:00'),
(5, 'Registro de cliente', '01/03/2023 12:00'),
(6, 'Salida del sistema', '15/03/2023 13:00'),
(7, 'Nueva reserva', '01/04/2023 14:00'),
(8, 'Consulta realizada', '15/04/2023 15:00'),
(9, 'Eliminación de cuenta', '01/05/2023 16:00'),
(10, 'Acceso denegado', '15/05/2023 17:00');

INSERT INTO ocupacion_cuartos (id_cliente, id_cuarto, fecha_hora) VALUES
(1, 1, '01/06/2023 14:00'),
(2, 2, '02/06/2023 15:00'),
(3, 3, '03/06/2023 16:00'),
(4, 4, '04/06/2023 17:00'),
(5, 5, '05/06/2023 18:00'),
(6, 6, '06/06/2023 19:00'),
(7, 7, '07/06/2023 20:00'),
(8, 8, '08/06/2023 21:00'),
(9, 9, '09/06/2023 22:00'),
(10, 10, '10/06/2023 23:00');


INSERT INTO limpieza_cuartos (id_cuarto, tiempo_estimado) VALUES
(1, '30m'),
(2, '45m'),
(3, '1h'),
(4, '30m'),
(5, '45m'),
(6, '1h'),
(7, '30m'),
(8, '45m'),
(9, '1h'),
(10, '30m');


INSERT INTO cliente_estacionamientos (id_cliente, id_lote) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);


-- Crear usuario administrador
CREATE USER 'admin_user'@'localhost' IDENTIFIED BY 'G4v@1rM8xZ';

-- Crear usuario recepcionista
CREATE USER 'reception_user'@'localhost' IDENTIFIED BY 'Pq9$kLm7rB';

-- Otorgar permisos de administrador al usuario administrador
GRANT ALL PRIVILEGES ON *.* TO 'admin_user'@'localhost' WITH GRANT OPTION;

-- Otorgar permisos específicos al usuario recepcionista para alterar ciertas tablas
GRANT SELECT, INSERT, UPDATE, DELETE ON final.clientes TO 'reception_user'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON final.cuartos TO 'reception_user'@'localhost';


-- Aplicar cambios
FLUSH PRIVILEGES;
