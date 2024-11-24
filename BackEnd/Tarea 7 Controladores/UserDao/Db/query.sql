CREATE DATABASE tarea7
CREATE TABLE
    users (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        Email VARCHAR(150) NOT NULL UNIQUE,
        Edad INT NOT NULL
    );

INSERT INTO
    users (Nombre, Email, Edad)
VALUES
    ('Juan Pérez', 'juan.perez@example.com', 30),
    ('Ana García', 'ana.garcia@example.com', 25),
    (
        'Luis Fernández',
        'luis.fernandez@example.com',
        28
    ),
    ('María López', 'maria.lopez@example.com', 35),
    ('Carlos Gómez', 'carlos.gomez@example.com', 40);

SELECT
    *
FROM
    users