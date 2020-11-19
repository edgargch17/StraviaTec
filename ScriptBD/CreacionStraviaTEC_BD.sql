--CREATE DATABASE STRAVIATEC;

---------------------------------------------------------------------------
--CREACION DE LAS TABLAS--
---------------------------------------------------------------------------

---------------------------------------------------------------------------
------CREA LA TABLA PARA ALMACENAR LOS DATOS DE LOS DEPORTISTAS------------
---------------------------------------------------------------------------
CREATE TABLE ATHLETE (
	password VARCHAR(20) NOT NULL,
	full_name VARCHAR(50) NOT NULL,
	nationality VARCHAR(20),
	birth_date DATE,
	photo VARCHAR,			--LINK DE LA FOTO--
	age INT,				--LA EDAD SE CALCULA AUTOMATICAMENTE CON LA FECHA DE NACIMIENTO
	username VARCHAR(20),	--PRIMARY KEY--

	PRIMARY KEY (username)
);


---------------------------------------------------------------------------
------CREA LA TABLA PARA ALMACENAR LOS DATOS DE LOS PATROCINADORES---------
---------------------------------------------------------------------------
CREATE TABLE SPONSOR(
	legal_represent VARCHAR(50) NOT NULL,--NOMBRE COMPLETO DEL REPRESENTANTE--
	phone VARCHAR(9) NOT NULL,--SOLO APLICA PARA NUMEROS QUE SE ENCUENTREN DENTRO DEL PAIS--
	logo VARCHAR, --LINK DEL LOGO--
	tradename  VARCHAR (20),--PRIMARY KEY--
	
	PRIMARY KEY (tradename)
);

---------------------------------------------------------------------------
------CREA LA TABLA PARA ALMACENAR LOS DATOS DE LAS ACTIVIDADES------------
---------------------------------------------------------------------------
CREATE TABLE ACTIVITY(
	bottom_altitude VARCHAR(20) NOT NULL,
	type_act VARCHAR(20),
	duration TIME,
	distancia INT,
	date_time DATE,
	map VARCHAR(20),--DEBE CONTENER EL ARCHIVO .GPX DE LA RUTA REALIZADA
	challenge_race VARCHAR(20),
	activity_identifier VARCHAR(20), --PRIMARY KEY--

	
	PRIMARY KEY(activity_identifier)
);

---------------------------------------------------------------------------
---------CREA LA TABLA PARA ALMACENAR LOS DATOS DE LAS CARRERA-------------
---------------------------------------------------------------------------
CREATE TABLE RACE(
	race_name VARCHAR(20),
	travel VARCHAR(20),
	race_date DATE,
	money_cost INT,
	activity_type VARCHAR(20),
	race_identifier VARCHAR(20),--PRIMARY KEY--
	activity_id VARCHAR(20),

	
	PRIMARY KEY(race_identifier)
);
---------------------------------------------------------------------------
-----------ATRIBUTOS MULTIVALOR DE LA ENTIDAD CARRERA(RACE)----------------
---------------------------------------------------------------------------
CREATE TABLE BANK_ACCOUNT(
	race_id VARCHAR(20) NOT NULL,
	owner_id VARCHAR(20) NOT NULL,
	number_account INT NOT NULL,--PRIMARY KEY--
	PRIMARY KEY(number_account)
);

CREATE TABLE CATEGORY(
	race_id VARCHAR(20) NOT NULL,
	category_name VARCHAR(20) NOT NULL,
	description VARCHAR(50) NOT NULL
);

---------------------------------------------------------------------------
---------CREA LA TABLA PARA ALMACENAR LOS DATOS DE LOS RETOS---------------
---------------------------------------------------------------------------
CREATE TABLE CHALLENGE(
	description VARCHAR(50),
	name_challenge VARCHAR(20),
	start_date DATE,
	end_date DATE,
	type_challenge VARCHAR(20),--FONDO/ALTITUD
	activity_id VARCHAR(20),
	challenge_identifier VARCHAR(20),--PRIMARY KEY--
	
	PRIMARY KEY(challenge_identifier)
);

---------------------------------------------------------------------------
---------CREA LA TABLA PARA ALMACENAR LOS DATOS DE LOS GRUPOS--------------
---------------------------------------------------------------------------
CREATE TABLE TEAM(
	name VARCHAR(20) NOT NULL,
	administrator VARCHAR(20) NOT NULL,
	team_identifier VARCHAR(20),--PRIMARY KEY--
	
	PRIMARY KEY(team_identifier)
);

----------------------------------------------------------------------------------
--AGREGA LAS TABLAS PARA MANEJAR LAS RELACIONES CORRESPONDIENTES PARA LAS TABLAS--
----------------------------------------------------------------------------------

CREATE TABLE SPONSOR_RACE(
	sponsor_id VARCHAR(20) NOT NULL,
	race_id VARCHAR(20) NOT NULL
);

CREATE TABLE SPONSOR_CHALLENGE(
	sponsor_id VARCHAR(20) NOT NULL,
	challenge_id VARCHAR(20) NOT NULL
);

CREATE TABLE TEAM_RACE(
	team_id VARCHAR(20) NOT NULL,
	race_id VARCHAR(20) NOT NULL
);

CREATE TABLE TEAM_CHALLENGE(
	team_id VARCHAR(20)NOT NULL,
	challenge_id VARCHAR(20) NOT NULL
);

CREATE TABLE TEAM_ATHLETE(
	team_id VARCHAR(20),
	athlete_id VARCHAR(20)
);

CREATE TABLE ATHLETE_ACTIVITY(
	athlete_id VARCHAR(20) NOT NULL,
	activity_id VARCHAR(20) NOT NULL
);

CREATE TABLE ATHLETE_CHALLENGE(
	athlete_id VARCHAR(20) NOT NULL,
	challenge_id VARCHAR(20) NOT NULL,
	progress INT 
);

--PAGO--
CREATE TABLE ATHLETE_RACE(
	athlete_id VARCHAR(20) NOT NULL,
	race_id VARCHAR(20) NOT NULL,
	payment_receipt VARCHAR(20) NOT NULL,
	UNIQUE(payment_receipt)
);

CREATE TABLE ATHLETE_FRIEND(
	athlete_id VARCHAR(20) NOT NULL,
	friend_id VARCHAR(20) NOT NULL
);

CREATE TABLE ACTIVITY_CHALLENGE(
	activity_id VARCHAR(20) NOT NULL,
	challenge_id VARCHAR(20) NOT NULL
);