

CREATE TABLE BANCO 
(
  ID_BANCO INT NOT NULL 
, NOMBRE VARCHAR2(150) NOT NULL 
, DIRECCION VARCHAR2(150) NOT NULL 
, CONSTRAINT BANCO_PK PRIMARY KEY 
  (
    ID_BANCO 
  )
  ENABLE 
);

CREATE SEQUENCE id_banco
START WITH 1
INCREMENT BY 1;

CREATE TRIGGER banco_incrementable 
BEFORE INSERT ON BANCO
FOR EACH ROW 
BEGIN 
SELECT id_banco.NEXTVAL INTO :NEW.ID_BANCO FROM DUAL;
END;

select * from BANCO;

insert into banco values (id_banco.NEXTVAL,'haha','hahahaha');

DROP TRIGGER banco_incrementable;

CREATE OR REPLACE PROCEDURE banco_insert (nombre in VARCHAR2, direccion in VARCHAR2) IS
BEGIN 
INSERT INTO banco values (id_banco.NEXTVAL,nombre, direccion);
END banco_insert;

execute banco_insert('holass','hahaha');

CREATE OR REPLACE PROCEDURE banco_update (pid_banco in INT ,pnombre in VARCHAR2, pdireccion in VARCHAR2) IS
BEGIN 
UPDATE banco SET nombre = pnombre, direccion = pdireccion
WHERE id_banco = pid_banco;
END banco_update;

execute banco_update(16,'banco 16', 'direccion banco 16');

CREATE OR REPLACE PROCEDURE banco_delete (pid_banco in INT) IS
BEGIN 
DELETE FROM banco 
WHERE id_banco = pid_banco;
END banco_delete;

execute banco_delete(20);

CREATE OR REPLACE PROCEDURE banco_select(registros out sys_refcursor)
as
begin 
    open registros for select * from banco;
end;

execute banco_select();

CREATE TABLE agencia (
    id_agencia   INTEGER NOT NULL,
    direccion    VARCHAR2(150)
);

ALTER TABLE agencia ADD CONSTRAINT agencia_pk PRIMARY KEY ( id_agencia );
CREATE SEQUENCE agencia_id_agencia_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER agencia_id_agencia_trg BEFORE
    INSERT ON agencia
    FOR EACH ROW
    WHEN ( new.id_agencia IS NULL )
BEGIN
    :new.id_agencia := agencia_id_agencia_seq.nextval;
END;

insert into agencia (direccion) values ('sdfadfasdfas');

CREATE OR REPLACE PROCEDURE agencia_insert (direccion in VARCHAR2) IS
BEGIN 
INSERT INTO agencia values (agencia_id_agencia_seq.NEXTVAL, direccion);
END agencia_insert;

execute agencia_insert('diiiirrection');

CREATE OR REPLACE PROCEDURE agencia_update (pid_agencia in INT , pdireccion in VARCHAR2) IS
BEGIN 
UPDATE agencia SET direccion = pdireccion
WHERE id_agencia = pid_agencia;
END agencia_update;

execute agencia_update(4, 'mi direccion');

CREATE OR REPLACE PROCEDURE agencia_delete (pid_agencia in INT) IS
BEGIN 
DELETE FROM agencia 
WHERE id_agencia = pid_agencia;
END agencia_delete;

execute agencia_delete(6);

CREATE OR REPLACE PROCEDURE agencia_select(registros out sys_refcursor)
as
begin 
    open registros for select * from agencia;
end;

select * from agencia;

--------------------------------------------------------------------------------------------------------------------------------- TABLA TIPO_CLIENTE
CREATE TABLE tipo_cliente (
    id_tipo       INTEGER NOT NULL,
    tipo          VARCHAR2(25),
    descripcion   VARCHAR2(250)
);

ALTER TABLE tipo_cliente ADD CONSTRAINT tipo_cliente_pk PRIMARY KEY ( id_tipo );

CREATE SEQUENCE tipo_cliente_id_tipo_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER tipo_cliente_id_tipo_trg BEFORE
    INSERT ON tipo_cliente
    FOR EACH ROW
    WHEN ( new.id_tipo IS NULL )
BEGIN
    :new.id_tipo := tipo_cliente_id_tipo_seq.nextval;
END;

INSERT INTO TIPO_CLIENTE (tipo, descripcion) VALUES('Premium','Cliente Premium');
INSERT INTO TIPO_CLIENTE (tipo, descripcion) VALUES('Oro','Cliente Oro');
--------------------------------------------------------------------------------------------------------------------------------- TABLA CLIENTE
CREATE TABLE cliente (
    id_cliente             INTEGER NOT NULL,
    nombre                 VARCHAR2(150) NOT NULL,
    direccion              VARCHAR2(150) NOT NULL,
    nit                    VARCHAR2(10),
    telefono               INTEGER,
    correo                 VARCHAR2(25),
    tipo_cliente_id_tipo   INTEGER NOT NULL
);

ALTER TABLE cliente ADD CONSTRAINT cliente_pk PRIMARY KEY ( id_cliente );

CREATE SEQUENCE cliente_id_cliente_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER cliente_id_cliente_trg BEFORE
    INSERT ON cliente
    FOR EACH ROW
    WHEN ( new.id_cliente IS NULL )
BEGIN
    :new.id_cliente := cliente_id_cliente_seq.nextval;
END;

ALTER TABLE cliente
    ADD CONSTRAINT cliente_tipo_cliente_fk FOREIGN KEY ( tipo_cliente_id_tipo )
        REFERENCES tipo_cliente ( id_tipo );
        
------------------- PROCEDIMIENTOS CLIENTE
--CREATE
CREATE OR REPLACE PROCEDURE cliente_insert (pnombre in VARCHAR2, pdireccion in VARCHAR2, pnit in VARCHAR2, ptelefono in INT, pcorreo in VARCHAR2, ptipo_cliente in INT) IS
BEGIN 
INSERT INTO cliente values (cliente_id_cliente_seq.NEXTVAL,pnombre, pdireccion, pnit, ptelefono, pcorreo, ptipo_cliente);
END cliente_insert;

execute cliente_insert('Dani3','Guate xD', '14-856-96', 12345678, 'danialjim@gmail.com',1);

-- UPDATE
CREATE OR REPLACE PROCEDURE cliente_update (pid_cliente in INT ,pnombre in VARCHAR2, pdireccion in VARCHAR2, pnit in VARCHAR2, ptelefono in INT, pcorreo in VARCHAR2, ptipo_cliente in INT) IS
BEGIN 
UPDATE cliente SET nombre = pnombre, direccion = pdireccion, nit = pnit, telefono = ptelefono, correo = pcorreo, tipo_cliente_id_tipo=ptipo_cliente
WHERE id_cliente = pid_cliente;
END cliente_update;

execute cliente_update(1,'Carlos','update dir','152-35',87654321,'nue@gmi',2);

--DELETE
CREATE OR REPLACE PROCEDURE cliente_delete (pid_cliente in INT) IS
BEGIN 
DELETE FROM cliente 
WHERE id_cliente = pid_cliente;
END cliente_delete;

execute cliente_delete(2);

--SELECT
CREATE OR REPLACE PROCEDURE cliente_select(registros out sys_refcursor)
as
begin 
    open registros for select * from cliente;
end;

select * from cliente;


--------------------------------------------------------------------------------------------------------------------------------- TABLA ESTADO CUENTA
CREATE TABLE estado_cuenta (
    id_estado     INTEGER NOT NULL,
    estado        VARCHAR2(25) NOT NULL,
    descripcion   VARCHAR2(250)
);

ALTER TABLE estado_cuenta ADD CONSTRAINT estado_cuenta_pk PRIMARY KEY ( id_estado );

CREATE SEQUENCE estado_cuenta_id_estado_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER estado_cuenta_id_estado_trg BEFORE
    INSERT ON estado_cuenta
    FOR EACH ROW
    WHEN ( new.id_estado IS NULL )
BEGIN
    :new.id_estado := estado_cuenta_id_estado_seq.nextval;
END;

INSERT INTO ESTADO_CUENTA (estado, descripcion) VALUES('Activa','La cuenta tiene permitido operar');
INSERT INTO ESTADO_CUENTA (estado, descripcion) VALUES('Bloqueada','La cuenta esta bloqueada, no tiene permitido operar');
INSERT INTO ESTADO_CUENTA (estado, descripcion) VALUES('Cancelada','La cuenta esta cancelada, no tiene permitido operar');

SELECT * FROM ESTADO_CUENTA;

--------------------------------------------------------------------------------------------------------------------------------- TABLA CUENTA
CREATE TABLE cuenta (
    id_cuenta                 INTEGER NOT NULL,
    estado                    VARCHAR2(50) NOT NULL,
    saldo                     FLOAT NOT NULL,
    estado_cuenta_id_estado   INTEGER NOT NULL
);

ALTER TABLE cuenta ADD CONSTRAINT cuenta_pk PRIMARY KEY ( id_cuenta );

ALTER TABLE cuenta
    ADD CONSTRAINT cuenta_estado_cuenta_fk FOREIGN KEY ( estado_cuenta_id_estado )
        REFERENCES estado_cuenta ( id_estado );
        
CREATE SEQUENCE cuenta_id_cuenta_seq START WITH 1 NOCACHE ORDER;

CREATE OR REPLACE TRIGGER cuenta_id_cuenta_trg BEFORE
    INSERT ON cuenta
    FOR EACH ROW
    WHEN ( new.id_cuenta IS NULL )
BEGIN
    :new.id_cuenta := cuenta_id_cuenta_seq.nextval;
END;        

--------------------------------------------------------------------------------------------------------------------------------- TABLA CLIENTE CUENTA
CREATE TABLE cliente_cuenta (
    cliente_id_cliente   INTEGER NOT NULL,
    cuenta_id_cuenta     INTEGER NOT NULL
);

ALTER TABLE cliente_cuenta
    ADD CONSTRAINT cliente_cuenta_cliente_fk FOREIGN KEY ( cliente_id_cliente )
        REFERENCES cliente ( id_cliente );

ALTER TABLE cliente_cuenta
    ADD CONSTRAINT cliente_cuenta_cuenta_fk FOREIGN KEY ( cuenta_id_cuenta )
        REFERENCES cuenta ( id_cuenta );

--CREATE

CREATE OR REPLACE PROCEDURE cuenta_insert (pestado in VARCHAR2, psaldo in FLOAT, pestado_id in INT) IS
BEGIN 
INSERT INTO cuenta values (cuenta_id_cuenta_seq.NEXTVAL, pestado, psaldo, pestado_id);
END cuenta_insert;

execute cuenta_insert('Nueva Cuenta', 1500.25, 1);

--UPDATE
CREATE OR REPLACE PROCEDURE cuenta_estado_update (pid_cuenta in INT, pestado_id in VARCHAR2) IS
BEGIN 
UPDATE cuenta SET estado_cuenta_id_estado = pestado_id
WHERE id_cuenta = pid_cuenta;
END cuenta_estado_update;

execute cuenta_estado_update(1, 2);

--SELECT 
CREATE OR REPLACE PROCEDURE cuenta_select(registros out sys_refcursor)
as
begin 
    open registros for select * from cuenta;
end;
select * from cuenta;