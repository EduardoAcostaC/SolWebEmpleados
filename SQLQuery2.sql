CREATE TABLE Empleados(
	idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(200),
	sueldo DECIMAL(18,2),
	fechaNacimiento DATE,
	tiempoCompleto BIT
);

SELECT * FROM Empleados;

--Formato de fechas en SQL es YYYY-MM-DD

INSERT INTO Empleados (nombre,sueldo,fechaNacimiento, tiempoCompleto)
VALUES ('Jose Lopez Torres', 4859.35,'1982-12-17',1);

SELECT idEmpleado, nombre,sueldo,fechaNacimiento, tiempoCompleto
FROM Empleados;

DELETE Empleados WHERE idEmpleado = 7;