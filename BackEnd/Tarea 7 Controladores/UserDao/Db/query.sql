
CREATE DATABASE IF NOT EXISTS tarea9
USE tarea9;

-- Tabla libros
CREATE TABLE libros (
  isbn bigint NOT NULL PRIMARY KEY,
  nombre VARCHAR(100) DEFAULT NULL,
  autor VARCHAR(100) DEFAULT NULL,
  genero VARCHAR(50) DEFAULT NULL
)

-- Tabla users
CREATE TABLE  users (
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  Email VARCHAR(150) NOT NULL UNIQUE,
  Contrasenia VARCHAR(255) NOT NULL
)

-- Tabla prestamos
CREATE TABLE prestamos (
  id_prestamo INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  id_usuario INT DEFAULT NULL,
  isbn BIGINT DEFAULT NULL,
  fecha_prestamo DATETIME DEFAULT NULL,
  fecha_vencimiento DATETIME DEFAULT NULL,
  CONSTRAINT fk_prestamo_libro FOREIGN KEY (isbn) REFERENCES libros (isbn),
  CONSTRAINT fk_prestamo_users FOREIGN KEY (id_usuario) REFERENCES users (Id)
);


INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456789, 'El Señor de los Anillos', 'J.R.R. Tolkien', 'Fantasía');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456788, '1984', 'George Orwell', 'Distopía');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456787, 'Matar a un ruiseñor', 'Harper Lee', 'Ficción');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456786, 'El Código Da Vinci', 'Dan Brown', 'Misterio');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456785, 'Harry Potter y la piedra filosofal', 'J.K. Rowling', 'Fantasía');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456784, 'Cien años de soledad', 'Gabriel García Márquez', 'Realismo mágico');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456783, 'El Gran Gatsby', 'F. Scott Fitzgerald', 'Clásico');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456782, 'Crónica de una muerte anunciada', 'Gabriel García Márquez', 'Ficción');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456781, 'Orgullo y prejuicio', 'Jane Austen', 'Romántico');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456780, 'Fahrenheit 451', 'Ray Bradbury', 'Ciencia ficción');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456779, 'El Hobbit', 'J.R.R. Tolkien', 'Fantasía');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456778, 'Revolución', 'Tom Peters', 'Negocios');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456777, 'La casa de los espíritus', 'Isabel Allende', 'Realismo mágico');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456776, 'El alquimista', 'Paulo Coelho', 'Ficción');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456775, 'Los juegos del hambre', 'Suzanne Collins', 'Ciencia ficción');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456774, 'La chica del tren', 'Paula Hawkins', 'Suspenso');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456773, 'El hombre en busca de sentido', 'Viktor Frankl', 'Psicología');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456772, 'Atrapados en el espejo', 'Khaled Hosseini', 'Ficción');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456771, 'Matar a un ruiseñor', 'Harper Lee', 'Drama');
INSERT INTO libros (isbn, nombre, autor, genero) VALUES (123456770, 'La sombra del viento', 'Carlos Ruiz Zafón', 'Misterio');

SELECT * FROM prestamos 

SELECT 
    prestamos.id_prestamo, 
    prestamos.fecha_prestamo, 
    prestamos.fecha_vencimiento, 
    libros.isbn, 
    usuarios.id_usuario
FROM prestamos
JOIN libros ON prestamos.isbn = libros.isbn
JOIN usuarios ON prestamos.id_usuario = usuarios.id_usuario;



