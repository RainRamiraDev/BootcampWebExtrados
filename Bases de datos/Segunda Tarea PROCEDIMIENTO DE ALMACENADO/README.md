## 1)

- crear un proc. alm. que tome a todas las personas (de la tabla personas), que NO
  sean empleados, y los cargue como empleados, con un salario
  base de 3000, sumandole 200 a cada nuevo empleado, todos con la posicion de "op"

  //no empleados

  jose -> 3000
  samanta -> 3200
  erika -> 3400

  -notese que, por ser un ejercicio, se debe ejecutar un insert into... por cada una
  de las personas que NO son empleados.
  -va a ser muy util entender el left join.

## 2)

- crear un proc. alm. que reciba un parametro de entrada integer ("valor_a_superar"),
  el proc. alm. debe seleccionar, de mayor a menor, los empleados ordenados por sueldo,
  y luego debe decirme cuantos empleados en este orden, son necesarios para lograr una sumatoria
  del sueldo mayor al "valor_a_superar"

  "valor_a_superar" = 10000

  emp_a 5500
  emp_b 4000
  emp_c 3500
  emp_d 3000
  emp_e 3000

  resultado final: 3, por que 5500 + 4000 < 10000 pero 5500+4000+3500 > 10000
