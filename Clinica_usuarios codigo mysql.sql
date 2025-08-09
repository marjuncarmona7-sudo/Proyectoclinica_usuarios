Use clinica_usuarios;

DESCRIBE usuarios;
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'Nina1234';
FLUSH PRIVILEGES;
Use clinica_usuarios;
INSERT INTO persona (idpersona, nombre, apellido, fecha_nacimiento, identificacion) VALUES
(10, 'Ana', 'López', '1992-04-10', '321654987');

INSERT INTO persona (idpersona, nombre, apellido, fecha_nacimiento, identificacion) VALUES
(11, 'Luis', 'Martínez', '1988-07-22', '654987321');

INSERT INTO doctor (iddoctor, identificacion, id_persona, licencia_medica) VALUES
(2, '654987321', 11, 'LM-1002');

INSERT INTO especialidad (idespecialidad, nombre_especialidad) VALUES
(1, 'Cardiología'),
(2, 'Dermatología');

INSERT INTO doctor_especialidad (iddoctor_especialidad, id_doctor, id_especialidad) VALUES
(1, 1, 1),  -- Doctor 1 es Cardiología
(2, 2, 2);  -- Doctor 2 es Dermatología

INSERT INTO consulta (idconsulta, fecha_consulta, diagnostico, id_doctor, id_paciente) VALUES
(1, '2025-08-08', 'Hipertensión controlada', 1, 10),
(2, '2025-08-07', 'Eczema leve', 2, 11);


INSERT INTO tratamiento (idtratamiento, descripcion, id_consulta) VALUES
(1, 'Medicamento antihipertensivo, dieta baja en sal y ejercicio regular', 1),
(2, 'Crema hidratante tópica y evitar irritantes en la piel', 2);


SELECT * FROM vista_consultas_detalladas;
SELECT * FROM vista_doctores_especialidad_sencilla;
SELECT * FROM vista_tratamientos_consulta;



