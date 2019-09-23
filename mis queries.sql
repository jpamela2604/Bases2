CREATE OR REPLACE  FUNCTION  login
( usuario  in INT,password  IN VARCHAR2) 
RETURN INTEGER is resultado integer;
	BEGIN
		  select  rol into resultado from "SYSTEM"."EMPLEADO" WHERE codigo_empleado=usuario and contrasena=password;
          return resultado;
    END login;
	


INSERT INTO "SYSTEM"."ESTADO_CHEQUERA" (CODIGO_ESTADO, NOMBRE) VALUES ('1', 'Solicitada')
INSERT INTO "SYSTEM"."ESTADO_CHEQUERA" (CODIGO_ESTADO, NOMBRE) VALUES ('2', 'En Proceso')
INSERT INTO "SYSTEM"."ESTADO_CHEQUERA" (CODIGO_ESTADO, NOMBRE) VALUES ('3', 'Entregada')

CREATE SEQUENCE chequera_id_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER chequera_id__trg BEFORE
    INSERT ON chequera
    FOR EACH ROW
    WHEN ( new.codigo_chequera IS NULL )
BEGIN
    :new.codigo_chequera := chequera_id_seq.nextval;
END;
	
	
CREATE OR REPLACE PROCEDURE solicitar_chequera (cantidad in INTEGER,numero_cuenta in INTEGER) IS
BEGIN 
INSERT INTO CHEQUERA (cantidad_cheques,CUENTA,ESTADO_CHEQUERA)values (cantidad,numero_cuenta,1);
END solicitar_chequera;

execute solicitar_chequera(50,23);


INSERT INTO "SYSTEM"."ESTADO_CHEQUE" (CODIGO, NOMBRE) VALUES ('1', 'normal')
INSERT INTO "SYSTEM"."ESTADO_CHEQUE" (CODIGO, NOMBRE) VALUES ('2', 'extraviado')
INSERT INTO "SYSTEM"."ESTADO_CHEQUE" (CODIGO, NOMBRE) VALUES ('3', 'robado')
INSERT INTO "SYSTEM"."CHEQUE_LOCAL" (CODIGO_CHEQUE, FECHA, MONTO, CHEQUERA, ESTADO_CHEQUE) VALUES ('1001', TO_DATE('2019-09-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '0', '5', '1')
INSERT INTO "SYSTEM"."CHEQUE_LOCAL" (CODIGO_CHEQUE, FECHA, MONTO, CHEQUERA, ESTADO_CHEQUE) VALUES ('1002', TO_DATE('2019-08-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '0', '5', '1')
INSERT INTO "SYSTEM"."CHEQUE_LOCAL" (CODIGO_CHEQUE, FECHA, MONTO, CHEQUERA, ESTADO_CHEQUE) VALUES ('1003', TO_DATE('2019-07-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '0', '7', '1')
INSERT INTO "SYSTEM"."CHEQUE_LOCAL" (CODIGO_CHEQUE, FECHA, MONTO, CHEQUERA, ESTADO_CHEQUE) VALUES ('1004', TO_DATE('2019-06-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), '0', '1', '1')


CREATE OR REPLACE PROCEDURE reporte_cheque (estado in INTEGER,cod in INTEGER) IS
BEGIN 
UPDATE "SYSTEM"."CHEQUE_LOCAL" SET ESTADO_CHEQUE=estado WHERE CODIGO_CHEQUE=cod;

END reporte_cheque;

execute reporte_cheque(2,1003);

CREATE OR REPLACE PROCEDURE estadocheque_select(registros out sys_refcursor)
as
begin 
    open registros for select * from estado_Cheque;
end;

CREATE OR REPLACE PROCEDURE empleado_select(registros out sys_refcursor)
as
begin 
    open registros for select e.codigo_empleado,e.nombre,e.direccion,e.telefono,e.correo,r.nombre as rol,
a.direccion as agencia,e.dpi,e.contrasena from empleado e,rol r , agencia a where e.rol=r.id_rol and e.agencia=a.id_agencia;
end;

CREATE OR REPLACE PROCEDURE rol_select(registros out sys_refcursor)
as
begin 
    open registros for select * from rol;
end;

CREATE OR REPLACE PROCEDURE agencia_select(registros out sys_refcursor)
as
begin 
    open registros for select * from agencia;
end;

INSERT INTO "SYSTEM"."ROL" (ID_ROL, NOMBRE) VALUES ('1', 'DBA')
INSERT INTO "SYSTEM"."ROL" (ID_ROL, NOMBRE) VALUES ('2', 'VISA')
INSERT INTO "SYSTEM"."ROL" (ID_ROL, NOMBRE) VALUES ('3', 'RECEPTOR')


INSERT INTO "SYSTEM"."AGENCIA" (ID_AGENCIA, DIRECCION, DESCRIPCION) VALUES ('1', 'Zona 1, Ciudad de Guatemala', 'banca central')
INSERT INTO "SYSTEM"."AGENCIA" (ID_AGENCIA, DIRECCION, DESCRIPCION) VALUES ('2', 'zona 3, Quetzaltenango', 'sub banca')
INSERT INTO "SYSTEM"."AGENCIA" (ID_AGENCIA, DIRECCION, DESCRIPCION) VALUES ('3', 'zona 5, jutiapa', 'sub banca')

INSERT INTO "SYSTEM"."EMPLEADO" (CODIGO_EMPLEADO, NOMBRE, DIRECCION, TELEFONO, CORREO, ROL, AGENCIA, DPI, CONTRASENA) VALUES ('1', 'empelado 1', 'casa', '911', '@empleado', '1', '1', '2256', 'hola');


CREATE OR REPLACE PROCEDURE empleado_delete (id in INT) IS
BEGIN 
DELETE FROM empleado 
WHERE codigo_empleado = id;
END empleado_delete;

CREATE OR REPLACE PROCEDURE empleado_actualizar 
(cod in integer,namee varchar2,dir in varchar2,tel in integer, email in varchar2,ro in integer,agen in integer,dp in varchar2,pass in varchar2) IS
BEGIN 
UPDATE "SYSTEM"."EMPLEADO" SET nombre=namee,direccion=dir,telefono=tel, correo=email,rol=ro, agencia=agen,dpi=dp,contrasena=pass WHERE CODIGO_empleado=cod;

END empleado_actualizar;

CREATE OR REPLACE PROCEDURE empleado_crear
(cod in integer,namee varchar2,dir in varchar2,tel in integer, email in varchar2,ro in integer,agen in integer,dp in varchar2,pass in varchar2) IS
BEGIN 
INSERT INTO  "SYSTEM"."EMPLEADO" values (cod,namee,dir,tel, email,ro, agen,dp,pass );

END empleado_crear;


CREATE OR REPLACE  FUNCTION  validar_cuenta
( cuent  in INT) 
RETURN INTEGER is resultado integer;
	BEGIN
		  select  numero_cuenta into resultado from "SYSTEM"."CUENTA" WHERE numero_cuenta=cuent;
          return resultado;
    END validar_cuenta;
	
	
	
	CREATE OR REPLACE  FUNCTION  validar_empleado
( cod  in INT) 
RETURN INTEGER is resultado integer;
	BEGIN
		  select  codigo_empleado into resultado from "SYSTEM"."EMPLEADO" WHERE codigo_empleado=cod;
          return resultado;
    END validar_empleado;
	

	CREATE OR REPLACE  FUNCTION  validar_cheque
( cod  in INT) 
RETURN INTEGER is resultado integer;
	BEGIN
		  select  codigo_cheque into resultado from "SYSTEM"."CHEQUE_LOCAL" WHERE codigo_cheque=cod;
          return resultado;
    END validar_cheque;
	
	
CREATE OR REPLACE  FUNCTION  validad_cuenta_cheque
( cuen  in INT, che in INT) 
RETURN INT 
as 
resultado INT;
cuentareal number;
	BEGIN
		  select  c.cuenta into cuentareal from chequera c,cheque_local l where  c.codigo_chequera=l.chequera  and l.codigo_cheque=che;
		  if cuentareal=cuen THEN resultado := 1;
		  ELSE  resultado := 0;
          END IF;
		  return resultado;
    END validad_cuenta_cheque;
	
	
