---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LOS DEPORTISTAS------------
---------------------------------------------------------------------------
INSERT INTO ATHLETE(password,full_name,nationality,birth_date,photo,age,username) VALUES
    ('1234','Allan Calderón','Uruguayo','2000-09-14',NULL,DATEDIFF(year, '2000-09-14',GETDATE()),'calquito'),
    ('abcd','Ronny Santamaría','Panameño','1999-09-25',NULL,DATEDIFF(year,'1999-09-25',GETDATE()),'RoJo_Savs'),
    ('adsabcd','Fabian Fallas','Suizo','2000-02-14',NULL,DATEDIFF(year,'2000-02-14',GETDATE()),'Fallas'),
    ('adsabcd','Edgar Gonzales','Simbaweño','2000-04-14',NULL,DATEDIFF(year,'2000-04-14',GETDATE()),'EdgarGonza');

---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LOS PATROCINADORES------------
---------------------------------------------------------------------------
INSERT INTO SPONSOR(legal_represent,phone,logo,tradename) VALUES 
    ('Pedro Perico',813654289,NULL,'Gatorade'),
    ('Jaimito',35129654,NULL,'Powerade'); 

---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LAS ACTIVIDADES------------
---------------------------------------------------------------------------
INSERT INTO  ACTIVITY(category ,type_act ,duration ,distancia ,date_time ,map ,challenge_race ,activity_identifier) VALUES
    ('altitud','correr','12:00:00',52,'2021-02-14',NULL,'reto','actividad1'),
    ('fondo','nadar','12:00:00',52,'2021-02-14',NULL,'reto','actividad3'),
    ('fondo','kayak','15:00:00',10,'2021-03-20',NULL,'carrera','actividad20');

---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LAS CARRERAS------------
---------------------------------------------------------------------------
INSERT INTO RACE(race_name,travel,race_date,money_cost,activity_type,race_identifier,activity_id) VALUES
    ('la gran carrera',NULL,'2021-03-20',20000,'correr','carrera1','actividad1'),
    ('nadar o morir',NULL,'2021-05-20',15000,'nadar','carrera2','actividad20');

---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LAS CUENTAS BANCARIAS------------
---------------------------------------------------------------------------

INSERT INTO BANK_ACCOUNT(race_id,owner_id,number_account) VALUES
    ('actividad20','Alan Turing','165-186-141-422-240-420-20'),
    ('actividad1','Fulanito','124-126-254-432-540-450-52');

    
---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LAS CATEGORIAS------------
---------------------------------------------------------------------------

INSERT INTO CATEGORY(race_id,category_name,description) VALUES
    ('actividad20','Open','de 24 a 30 años'),
    ('actividad20','Master A','de 30 a 40 años'),
    ('actividad1','Master B',' de 41 a 50 años');


---------------------------------------------------------------------------
------INSERTA LOS DATOS DE LOS RETOS------------
---------------------------------------------------------------------------
INSERT INTO CHALLENGE(description,name_challenge,start_date,end_date,type_challenge,activity_id,challenge_identifier) VALUES
    ('correr 100km en un mes en honor a los fallecidos por el COVID','carerra contra el COVID','2020-20-11','2020-20-12','altitud','actividad1','reto1'),
    ('nadar 50km en un mes en honor a los fallecidos por el COVID','natación contra el COVID','2020-20-11','2020-20-12','fondo','actividad20','reto2');


INSERT INTO TEAM(name,administrator,team_identifier) VALUES
    ('los ak7', 'Benito Soza','team1'),
    ('los mete goles', 'Uvuvwevwevwe Onyetenyevwe Ugwemuhwem Osas', 'team2'),
    ('los musicos', 'Tongo', 'team3');

CREATE TABLE SPONSOR_RACE(sponsor_id,race_id) VALUES
    ('Pedro Perico','carrera1'),
    ('Jaimito','carrera2');

CREATE TABLE SPONSOR_CHALLENGE(sponsor_id,challenge_id) VALUES
    ('Pedro Perico','reto1'),
    ('Jaimito','reto2');

CREATE TABLE TEAM_RACE(team_id,race_id) VALUES
    ('team1','carrera1'),
    ('team2','carrera1'),
    ('team3','carrera2');

CREATE TABLE TEAM_CHALLENGE(team_id,challenge_id) VALUES
    ('team1','reto1'),
    ('team2','reto1'),
    ('team3','reto2');

CREATE TABLE TEAM_ATHLETE(team_id,athlete_id) VALUES
    ('team1','Calquito'),
    ('team2','Fallas'),
    ('team3','EdgarGonza');

CREATE TABLE ATHLETE_ACTIVITY(athlete_id,activity_id) VALUES
    ('Calquito', 'Actividad1'),
    ('EdgarGonza', 'Actividad3'),
    ('Fallas', 'Actividad20');

CREATE TABLE ATHLETE_CHALLENGE(athlete_id,challenge_id,progress) VALUES
    ('Calquito','reto2',25),
    ('EdgarGonza','reto1',50),
    ('Fallas', 'reto2',64);


CREATE TABLE ATHLETE_RACE(athlete_id,race_id,payment_receipt) VALUES
    ('Calquito','carrera2','recibo'),
    ('EdgarGonza','carrera2','recibo 50'),
    ('Fallas', 'carrera1','recibo 64');

CREATE TABLE ATHLETE_FRIEND(athlete_id,friend_id) VALUES
    ('Calquito','RoJo_Savs'),
    ('Fallas', 'EdgarGonza');


CREATE TABLE ACTIVITY_CHALLENGE(activity_id,challenge_id) VALUES
    ('actividad20','reto1'),
    ('actividad3','reto2');