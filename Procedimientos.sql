
--------------------------------------------------------------------------------------------------------------------------------- BANCO
CREATE OR REPLACE PROCEDURE banco_insert (nombre in VARCHAR2) IS
BEGIN 
INSERT INTO banco values (id_banco.NEXTVAL,nombre);
END banco_insert;

CREATE OR REPLACE PROCEDURE banco_select(registros out sys_refcursor)
AS
BEGIN
    OPEN registros FOR SELECT * FROM banco;
END;

CREATE OR REPLACE PROCEDURE banco_update (pid_banco in INT ,pnombre in VARCHAR2) IS
BEGIN 
UPDATE banco SET nombre = pnombre
WHERE id_banco = pid_banco;
END banco_update;

CREATE OR REPLACE PROCEDURE banco_delete (pid_banco in INT) IS
BEGIN 
DELETE FROM banco 
WHERE id_banco = pid_banco;
END banco_delete;

--------------------------------------------------------------------------------------------------------------------------------- AGENCIA
CREATE OR REPLACE PROCEDURE agencia_insert (direccion in VARCHAR2, descripcion in VARCHAR2 DEFAULT 'Nueva Agencia') IS
BEGIN 
INSERT INTO agencia values (agencia_id_agencia_seq.NEXTVAL, direccion, descripcion );
END agencia_insert;

CREATE OR REPLACE PROCEDURE agencia_select(registros out sys_refcursor)
AS
BEGIN
    OPEN registros FOR SELECT * FROM agencia;
END;

CREATE OR REPLACE PROCEDURE agencia_update (pid_agencia in INT , pdireccion in VARCHAR2, pdescripcion in VARCHAR2) IS
BEGIN 
UPDATE agencia SET direccion = pdireccion, descripcion = pdescripcion
WHERE id_agencia = pid_agencia;
END agencia_update;


CREATE OR REPLACE PROCEDURE agencia_delete (pid_agencia in INT) IS
BEGIN 
DELETE FROM agencia 
WHERE id_agencia = pid_agencia;
END agencia_delete;

--------------------------------------------------------------------------------------------------------------------------------- EQUIPO
CREATE OR REPLACE PROCEDURE equipo_insert (descripcion in VARCHAR2 DEFAULT 'Nuevo equipo', id_agencia in INT) IS
BEGIN 
INSERT INTO equipo values (equipo_sku_seq.NEXTVAL, descripcion, id_agencia);
END equipo_insert;

CREATE OR REPLACE PROCEDURE equipo_update (psku in INT , pdescripcion in VARCHAR2, id_agencia in INT) IS
BEGIN 
UPDATE equipo SET descripcion = pdescripcion, agencia_id_agencia = id_agencia
WHERE sku = psku;
END equipo_update;

CREATE OR REPLACE PROCEDURE equipo_select(registros out sys_refcursor)
AS
BEGIN
    OPEN registros FOR SELECT * FROM equipo;
END;

CREATE OR REPLACE PROCEDURE equipo_delete (psku in INT) IS
BEGIN 
DELETE FROM equipo 
WHERE sku = psku;
END equipo_delete;

--------------------------------------------------------------------------------------------------------------------------------- ROL
CREATE OR REPLACE PROCEDURE rol_insert (nombre in VARCHAR2 ,descripcion in VARCHAR2 DEFAULT 'Nuevo rol') IS
BEGIN 
INSERT INTO rol values (rol_id_rol_seq.NEXTVAL, nombre, descripcion);
END rol_insert;

CREATE OR REPLACE PROCEDURE rol_select(registros out sys_refcursor)
AS
BEGIN
    OPEN registros FOR SELECT * FROM rol;
END;

CREATE OR REPLACE PROCEDURE rol_delete (pid_rol in INT) IS
BEGIN 
DELETE FROM rol 
WHERE id_rol = pid_rol;
END rol_delete;

--------------------------------------------------------------------------------------------------------------------------------- FUNCIONES
CREATE OR REPLACE PROCEDURE funcionalidad_insert (nombre in VARCHAR2 ,descripcion in VARCHAR2 DEFAULT 'Nueva funcionalidad') IS
BEGIN 
INSERT INTO funcionalidad values (funcionalidad_codigo_funcional.NEXTVAL, nombre, descripcion);
END funcionalidad_insert;

CREATE OR REPLACE PROCEDURE funcionalidad_select(registros out sys_refcursor)
AS
BEGIN
    OPEN registros FOR SELECT * FROM funcionalidad;
END;

CREATE OR REPLACE PROCEDURE funcionalidad_delete (pid_rol in INT) IS
BEGIN 
DELETE FROM funcionalidad 
WHERE codigo_funcionalidad = pid_rol;
END funcionalidad_delete;

--------------------------------------------------------------------------------------------------------------------------------- PERMISOS
CREATE OR REPLACE PROCEDURE permiso_insert (rol in INT, funcionalidad in INT) IS
BEGIN 
INSERT INTO permiso values (rol, funcionalidad);
END permiso_insert;


CREATE OR REPLACE PROCEDURE get_rol_empleado (codigo_empleado in INT, registros out sys_refcursor) IS
BEGIN 
OPEN registros FOR select rol from empleado where codigo_empleado = codigo_empleado;
END get_rol_empleado;
select * from empleado;
insert into empleado (nombre,direccion,telefono,correo,ROL,AGENCIA,dpi,constrasena) values ('dani','dir',12345678,'dani@correo',3,7,'2525','pass');
insert into empleado (nombre,direccion,telefono,correo,ROL,AGENCIA,dpi,constrasena) values ('patricio','dir',12345678,'pat@correo',2,7,'2525','pass');

--------------------------------------------------------------------------------------------------------------------------------- EMPLEADO
CREATE OR REPLACE PROCEDURE empleado_select(registros out sys_refcursor)
AS
BEGIN
    OPEN registros FOR SELECT * FROM empleado;
END;

CREATE OR REPLACE PROCEDURE empleado_update (pce in INT, id_rol in INT) IS
BEGIN 
UPDATE empleado SET rol = id_rol
WHERE codigo_empleado = pce;
END empleado_update;

--------------------------------------------------------------------------------------------------------------------------------- AUDITORIA Cuenta
CREATE OR REPLACE PROCEDURE equipo_select(registros out sys_refcursor, cuenta_id in INT)
AS
BEGIN
    OPEN registros FOR select t.correlativo_transaccion, t.fecha, t.saldo_inicial, t.saldo_final, t.valor, t.cuenta, tt.nombre from transaccion t, tipo_transaccion tt
                     where t.tipo_transaccion = tt.codigo_tipo_transac and t.cuenta = cuenta_id
END;

--------------------------------------------------------------------------------------------------------------------------------- CONSULTAS
CREATE OR REPLACE PROCEDURE saldos_por_agencia(registros out sys_refcursor, id_agencia_ in INT)
AS
BEGIN
    OPEN registros FOR select sum(t.saldo_inicial) AS "Saldo Inicial", sum(t.saldo_final) AS "Saldo Final", (sum(t.saldo_inicial)+ sum(t.saldo_final)) AS "Saldo Real" 
                       from transaccion t where t.agencia = id_agencia_;
END;

CREATE OR REPLACE PROCEDURE clientes_no_agencia(registros out sys_refcursor, agencia_num in INT)
AS
BEGIN
    OPEN registros FOR select unique(cl.nombre) from cuenta c, cliente_cuenta cc, cliente cl, transaccion t
                        where (c.numero_cuenta = t.cuenta and cc.cuenta = c.numero_cuenta and cl.codigo_cliente = cc.cliente and t.cuenta = c.numero_cuenta and t.agencia != agencia_num);
END;