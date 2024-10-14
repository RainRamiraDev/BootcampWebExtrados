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
    id_cliente INT NULL,
    CONSTRAINT FK_usuario FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    CONSTRAINT FK_cliente_accion FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);

CREATE TABLE ocupacion_cuartos (
    id_ocupacion INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT NOT NULL,
    id_cuarto INT NOT NULL,
    fecha_hora_entrada VARCHAR(20) NOT NULL,
    fecha_hora_salida VARCHAR(20) NULL,
    CONSTRAINT FK_cliente_ocupacion FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
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