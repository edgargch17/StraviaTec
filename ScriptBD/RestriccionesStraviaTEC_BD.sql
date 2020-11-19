---------------------------------------------------------------------------
----------AGREGA LAS RESTRICCIONES  CORRESPONDIENTES LAS TABLAS------------
---------------------------------------------------------------------------

---------------------------------------------------------------------------
----------------RELACION DE LA TABLA CARRERA - ACTIVIDAD-------------------
---------------------------------------------------------------------------

ALTER TABLE RACE 
ADD CONSTRAINT RACE_ACTIVITY_FK FOREIGN KEY (activity_id)
REFERENCES ACTIVITY(activity_identifier);

ALTER TABLE BANK_ACCOUNT
ADD CONSTRAINT BANK_ACCOUNT_RACE_FK FOREIGN KEY (race_id)
REFERENCES RACE(race_identifier);

ALTER TABLE CATEGORY
ADD CONSTRAINT CATEGORY_RACE_FK FOREIGN KEY (race_id)
REFERENCES RACE(race_identifier);

---------------------------------------------------------------------------
------------------RELACION DE LA TABLA RETO - ACTIVIDAD--------------------
---------------------------------------------------------------------------
ALTER TABLE CHALLENGE
ADD CONSTRAINT CHALLENGE_ACTIVITY_FK FOREIGN KEY (activity_id)
REFERENCES ACTIVITY(activity_identifier);



---------------------------------------------------------------------------
-------------------RELACIONES DE LA TABLA SPONSOR_RACE---------------------
---------------------------------------------------------------------------
ALTER TABLE SPONSOR_RACE
ADD CONSTRAINT SPONSOR_RACE_FK FOREIGN KEY (sponsor_id)
REFERENCES SPONSOR(tradename);

ALTER TABLE SPONSOR_RACE
ADD CONSTRAINT RACE_SPONSOR_FK FOREIGN KEY (race_id)
REFERENCES RACE(race_identifier);

---------------------------------------------------------------------------
----------------RELACIONES DE LA TABLA SPONSOR_CHALLENGE-------------------
---------------------------------------------------------------------------
ALTER TABLE SPONSOR_CHALLENGE
ADD CONSTRAINT SPONSOR_CHALLENGE_FK FOREIGN KEY (sponsor_id)
REFERENCES SPONSOR(tradename);

ALTER TABLE SPONSOR_CHALLENGE
ADD CONSTRAINT CHALLENGE_SPONSOR_FK FOREIGN KEY (challenge_id)
REFERENCES CHALLENGE(challenge_identifier);

---------------------------------------------------------------------------
---------------------RELACIONES DE LA TABLA TEAM_RACE----------------------
---------------------------------------------------------------------------
ALTER TABLE TEAM_RACE
ADD CONSTRAINT TEAM_RACE_FK FOREIGN KEY (team_id)
REFERENCES TEAM(team_identifier);

ALTER TABLE TEAM_RACE
ADD CONSTRAINT RACE_TEAM_FK FOREIGN KEY (race_id)
REFERENCES RACE(race_identifier);

---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA TEAM_CHALLENGE---------------------
---------------------------------------------------------------------------
ALTER TABLE TEAM_CHALLENGE
ADD CONSTRAINT TEAM_CHALLENGE_FK FOREIGN KEY (team_id)
REFERENCES TEAM(team_identifier);

ALTER TABLE TEAM_CHALLENGE
ADD CONSTRAINT CHALLENGE_TEAM_FK FOREIGN KEY (challenge_id)
REFERENCES CHALLENGE(challenge_identifier);


---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA TEAM_ATHLETE-----------------------
---------------------------------------------------------------------------
ALTER TABLE TEAM_ATHLETE
ADD CONSTRAINT TEAM_ATHLETE_FK FOREIGN KEY (team_id)
REFERENCES TEAM(team_identifier);

ALTER TABLE TEAM_ATHLETE
ADD CONSTRAINT ATHLETE_TEAM_FK FOREIGN KEY (athlete_id)
REFERENCES ATHLETE(username);


---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA ATHLETE_ACTIVITY-------------------
---------------------------------------------------------------------------
ALTER TABLE ATHLETE_ACTIVITY
ADD CONSTRAINT ATHLETE_ACTIVITY_FK FOREIGN KEY (athlete_id)
REFERENCES ATHLETE(username);

ALTER TABLE ATHLETE_ACTIVITY
ADD CONSTRAINT ACTIVITY_ATHLETE_FK FOREIGN KEY (activity_id)
REFERENCES ACTIVITY(activity_identifier);


---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA ATHLETE_CHALLENGE------------------
---------------------------------------------------------------------------
ALTER TABLE ATHLETE_CHALLENGE
ADD CONSTRAINT ATHLETE_CHALLENGE_FK FOREIGN KEY (athlete_id)
REFERENCES ATHLETE(username);

ALTER TABLE ATHLETE_CHALLENGE
ADD CONSTRAINT CHALLENGE_ATHLETE_FK FOREIGN KEY (challenge_id)
REFERENCES CHALLENGE(challenge_identifier);


---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA ATHLETE_RACE-----------------------
---------------------------------------------------------------------------
ALTER TABLE ATHLETE_RACE
ADD CONSTRAINT ATHLETE_RACE_FK FOREIGN KEY (athlete_id)
REFERENCES ATHLETE(username);

ALTER TABLE ATHLETE_RACE
ADD CONSTRAINT RACE_ATHLETE_FK FOREIGN KEY (race_id)
REFERENCES RACE(race_identifier);


---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA ATHLETE_FRIEND---------------------
---------------------------------------------------------------------------
ALTER TABLE ATHLETE_FRIEND
ADD CONSTRAINT ATHLETE_FRIEND_FK FOREIGN KEY (athlete_id)
REFERENCES ATHLETE(username);

ALTER TABLE ATHLETE_FRIEND
ADD CONSTRAINT FRIEND_ATHLETE_FK FOREIGN KEY (friend_id)
REFERENCES ATHLETE(username);


---------------------------------------------------------------------------
-----------------RELACIONES DE LA TABLA ACTIVITY_CHALLENGE-----------------
---------------------------------------------------------------------------
ALTER TABLE ACTIVITY_CHALLENGE
ADD CONSTRAINT ACTIVITY_CHALLENGE_FK FOREIGN KEY (activity_id)
REFERENCES ACTIVITY(activity_identifier);

ALTER TABLE ACTIVITY_CHALLENGE
ADD CONSTRAINT CHALLENGE_ACTIVITY_FK FOREIGN KEY (challenge_id)
REFERENCES CHALLENGE(challenge_identifier);