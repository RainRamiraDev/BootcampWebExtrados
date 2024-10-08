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
