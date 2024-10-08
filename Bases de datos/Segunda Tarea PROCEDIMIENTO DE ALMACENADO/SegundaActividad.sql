--1)
DELIMITER $$

CREATE PROCEDURE IF NOT EXISTS PersonasNoEmpleadosSalarios()
BEGIN
    
    DECLARE terminado INT DEFAULT FALSE;
    DECLARE v_id_persona INT;
    DECLARE v_posicion VARCHAR(255) DEFAULT 'op';  
    DECLARE v_salario INT DEFAULT 3000;             
    DECLARE v_fecha_baja DATE DEFAULT NULL;         

    DECLARE personas_cursor CURSOR FOR
    SELECT p.id
    FROM personas p
    LEFT JOIN empleados e ON p.id = e.id_persona  
    WHERE e.id_persona IS NULL;


    DECLARE CONTINUE HANDLER FOR NOT FOUND SET terminado = TRUE;


    OPEN personas_cursor;


    read_loop: LOOP
    
        FETCH personas_cursor INTO v_id_persona;

    
        IF terminado THEN
            LEAVE read_loop;
        END IF;

        
        INSERT INTO empleados (id_persona, posicion, salario, fecha_baja)
        VALUES (v_id_persona, v_posicion, v_salario, v_fecha_baja);

    
        SET v_salario = v_salario + 200;
    END LOOP;


    CLOSE personas_cursor;
END$$

DELIMITER ;

--Llamada al sp
CALL PersonasNoEmpleadosSalarios();

--2)

DELIMITER $$
CREATE PROCEDURE IF NOT EXISTS ContarEmpleadosPorSueldo(IN valor_a_superar INT)
BEGIN
    DECLARE suma_total INT DEFAULT 0;
    DECLARE contador INT DEFAULT 0;
    DECLARE v_salario INT;
    
    DECLARE empleados_cursor CURSOR FOR
    SELECT salario
    FROM empleados
    ORDER BY salario DESC;

 
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_salario = NULL;
    OPEN empleados_cursor;
    
    read_loop: LOOP
        
        FETCH empleados_cursor INTO v_salario;

        IF v_salario IS NULL THEN
            LEAVE read_loop;
        END IF;

        SET suma_total = suma_total + v_salario;
        SET contador = contador + 1;

        IF suma_total > valor_a_superar THEN
            LEAVE read_loop;
        END IF;
    END LOOP;

    CLOSE empleados_cursor;

    SELECT contador AS numero_de_empleados_necesarios;
END$$
DELIMITER ;

--Llamada al sp
CALL ContarEmpleadosPorSueldo(27500);
