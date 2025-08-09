USE clinica_usuarios;
CREATE VIEW vista_doctores_especialidad_sencilla AS
SELECT
    p.nombre AS nombre_doctor,
    p.apellido AS apellido_doctor,
    e.nombre_especialidad
FROM
    doctor d
JOIN
    persona p ON d.id_persona = p.idpersona
JOIN
    doctor_especialidad de ON d.iddoctor = de.id_doctor
JOIN
    especialidad e ON de.id_especialidad = e.idespecialidad;

CREATE VIEW vista_consultas_detalladas AS
SELECT
    c.idconsulta,
    c.fecha_consulta,
    c.diagnostico,
    doc_p.nombre AS nombre_doctor,
    doc_p.apellido AS apellido_doctor,
    pac_p.nombre AS nombre_paciente,
    pac_p.apellido AS apellido_paciente
FROM
    consulta c
LEFT JOIN doctor d ON c.id_doctor = d.iddoctor
LEFT JOIN persona doc_p ON d.id_persona = doc_p.idpersona
LEFT JOIN persona pac_p ON c.id_paciente = pac_p.idpersona;

CREATE VIEW vista_tratamientos_consulta AS
SELECT
    t.idtratamiento,
    t.descripcion,
    c.fecha_consulta,
    c.diagnostico,
    p.nombre AS nombre_paciente,
    p.apellido AS apellido_paciente
FROM
    tratamiento t
JOIN
    consulta c ON t.id_consulta = c.idconsulta
JOIN
    persona p ON c.id_paciente = p.idpersona;
