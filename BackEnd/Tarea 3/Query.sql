CREATE TABLE Usuarios (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

INSERT INTO Usuarios (Nombre, Edad, Activo) VALUES 
    ('Juan', 25, 1), 
    ('Ana', 30, 1), 
    ('Luis', 22, 1);

SELECT * FROM usuarios;
