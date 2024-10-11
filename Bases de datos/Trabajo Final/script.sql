CREATE TABLE roles (
    id_rol INT PRIMARY KEY AUTO_INCREMENT,
    nombre_rol VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    dni VARCHAR(15) NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    nombre_usuario VARCHAR(20) NOT NULL UNIQUE,
    contrasenia VARCHAR(10) NOT NULL,
    fecha_alta VARCHAR(10) NOT NULL, 
    fecha_baja VARCHAR(10) NULL,
    id_rol INT NOT NULL,
    CONSTRAINT FK_rol FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);

CREATE TABLE clientes (
    id_cliente INT PRIMARY KEY AUTO_INCREMENT,
    dni VARCHAR(15) NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    fecha_alta VARCHAR(10) NOT NULL
);

CREATE TABLE cuartos (
    id_cuarto INT PRIMARY KEY AUTO_INCREMENT,
    numero INT NOT NULL UNIQUE,
    disponible BIT NOT NULL
);

CREATE TABLE estacionamientos (
    id_lote INT PRIMARY KEY AUTO_INCREMENT,
    numero_lote INT NOT NULL UNIQUE
);

CREATE TABLE acciones (
    id_accion INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT NOT NULL,
    mensaje VARCHAR(100) NOT NULL,
    fecha_hora VARCHAR(20) NOT NULL,
    id_cliente INT NULL, -- Para referencia al cliente creado, si es relevante
    CONSTRAINT FK_usuario FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    CONSTRAINT FK_cliente_accion FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente) -- Nombre único
);

CREATE TABLE ocupacion_cuartos (
    id_ocupacion INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT NOT NULL,
    id_cuarto INT NOT NULL,
    fecha_hora_entrada VARCHAR(20) NOT NULL,
    fecha_hora_salida VARCHAR(20) NULL,
    CONSTRAINT FK_cliente_ocupacion FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente), -- Nombre único
    CONSTRAINT FK_cuarto FOREIGN KEY (id_cuarto) REFERENCES cuartos(id_cuarto)
);

CREATE TABLE limpieza_cuartos (
    id_limpieza INT PRIMARY KEY AUTO_INCREMENT,
    id_cuarto INT NOT NULL,
    tiempo_estimado VARCHAR(10) NOT NULL,
    fecha_limpieza VARCHAR(20) NULL,
    CONSTRAINT FK_cuarto_limpieza FOREIGN KEY (id_cuarto) REFERENCES cuartos(id_cuarto)
);

CREATE TABLE cliente_estacionamientos (
    id_cliente_estacionamiento INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT NOT NULL,
    id_lote INT NOT NULL,
    CONSTRAINT FK_cliente_estacionamiento FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
    CONSTRAINT FK_lote FOREIGN KEY (id_lote) REFERENCES estacionamientos(id_lote)
);

-- Insertar roles
INSERT INTO roles (nombre_rol) VALUES
('administrador'),
('recepcionista');

-- Insertar usuarios con roles
INSERT INTO usuarios (dni, nombre, nombre_usuario, contrasenia, fecha_alta, fecha_baja, id_rol) VALUES
('12345678A', 'Juan', 'juanito', 'pass123', '01/01/2023', NULL, 1),  -- Administrador
('87654321B', 'Maria', 'mari', 'pass456', '15/01/2023', NULL, 1),  -- Administrador
('23456789C', 'Pedro', 'pedro123', 'pass789', '01/02/2023', NULL, 1),  -- Administrador
('34567890D', 'Ana', 'anita', 'pass321', '15/02/2023', '01/06/2023', 2),  -- Recepcionista
('45678901E', 'Luis', 'lucho', 'pass654', '01/03/2023', NULL, 2),  -- Recepcionista
('56789012F', 'Sofia', 'sofi', 'pass987', '15/03/2023', NULL, 2),  -- Recepcionista
('67890123G', 'Carlos', 'carlitos', 'pass852', '01/04/2023', NULL, 2),  -- Recepcionista
('78901234H', 'Laura', 'lau', 'pass963', '15/04/2023', NULL, 2),  -- Recepcionista
('89012345I', 'David', 'davidito', 'pass159', '01/05/2023', NULL, 2),  -- Recepcionista
('90123456J', 'Elena', 'ele', 'pass753', '15/05/2023', NULL, 2);  -- Recepcionista

-- Insertar clientes
INSERT INTO clientes (dni, nombre, fecha_alta) VALUES
('11223344A', 'Fernando', '01/05/2023'),
('22334455B', 'Gina', '15/05/2023'),
('33445566C', 'Hector', '01/06/2023'),
('44556677D', 'Isabel', '15/06/2023'),
('55667788E', 'Jorge', '01/07/2023'),
('66778899F', 'Karla', '15/07/2023'),
('77889900G', 'Luis', '01/08/2023'),
('88990011H', 'Monica', '15/08/2023'),
('99001122I', 'Nicolas', '01/09/2023'),
('10111213J', 'Olga', '15/09/2023');

-- Puedes registrar acciones al crear un cliente en tu aplicación
-- Ejemplo: 
-- INSERT INTO acciones (id_usuario, mensaje, fecha_hora, id_cliente) VALUES (id_usuario_creador, CONCAT('Creación del cliente: ', 'Fernando'), NOW(), LAST_INSERT_ID());
