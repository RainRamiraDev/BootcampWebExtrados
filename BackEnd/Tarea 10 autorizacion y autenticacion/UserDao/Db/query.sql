-- Crear la base de datos
CREATE DATABASE tarea9;

-- Usar la base de datos
USE tarea9;

-- Crear la tabla users
CREATE TABLE users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Contrasenia VARCHAR(255) NOT NULL -- Almacena el hash de la contraseña
);

-- Insertar valores en la tabla users con contraseñas hasheadas usando SHA2
INSERT INTO users (Nombre, Email, Contrasenia)
VALUES
    ('Juan Pérez', 'juan.perez@example.com', SHA2('password123', 256)),
    ('Ana García', 'ana.garcia@example.com', SHA2('ana_pass', 256)),
    ('Luis Fernández', 'luis.fernandez@example.com', SHA2('luis1234', 256)),
    ('María López', 'maria.lopez@example.com', SHA2('maria_lopez', 256)),
    ('Carlos Gómez', 'carlos.gomez@example.com', SHA2('carlos2024', 256));

-- Consultar todos los registros de la tabla users
SELECT * FROM users;
