-- 1- obtener todas las locaciones de los estados unidos (ID de pais “US”)

SELECT ESTADO_PROVINCIA AS 'ESTADO' ,CIUDAD,DIRECCION,CODIGO_POSTAL AS 'CODIGO POSTAL'
FROM locaciones
WHERE ID_PAIS = 'US'
ORDER BY ESTADO ASC

-- 2- obtener todos los departamentos de los estado unidos

SELECT d1.NOMBRE AS 'Departamentos ubicaods en Estados Unidos'
FROM departamentos d1
WHERE d1.ID_LOCACION IN (
    SELECT d2.ID_LOCACION 
    FROM departamentos d2 
    JOIN locaciones l ON d2.ID_LOCACION = l.ID_LOCACION 
    WHERE l.ID_PAIS = 'US'
)
ORDER BY d1.NOMBRE ASC

-- 3- obtener todos los managers que reporten a un departamento de los estados unidos.


SELECT CONCAT(e.NOMBRE, ' , ', e.APELLIDO) AS 'Managers que reportan a un departamento de los estados unidos'
FROM empleados e
WHERE e.ID_EMPLEADO IN (
    SELECT d.ID_MANAGER
    FROM departamentos d
    WHERE d.ID_LOCACION IN (
        SELECT l.ID_LOCACION
        FROM locaciones l
        WHERE l.ID_PAIS = 'US'
    )
)
ORDER BY e.NOMBRE asc

-- 4- obtener todos los usuarios que reporten a un manager que
-- reporte a un departamento de los estados unidos.

SELECT CONCAT(e.NOMBRE, ' , ', e.APELLIDO) AS 'Nombre Completo'
FROM empleados e
WHERE ID_MANAGER IN 
(
    SELECT ID_MANAGER
    FROM departamentos d
    WHERE d.ID_LOCACION IN
    (
        SELECT l.ID_LOCACION
        FROM locaciones l
        WHERE l.ID_PAIS = 'US'
    )
)
ORDER BY e.NOMBRE ASC