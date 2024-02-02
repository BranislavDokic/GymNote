CREATE DATABASE gymnotedb;

USE gymnotedb;

CREATE TABLE users (
user_id INT PRIMARY KEY AUTO_INCREMENT,
user_name VARCHAR(45),
user_password VARCHAR(15)
);

CREATE TABLE workout (
workout_id INT PRIMARY KEY AUTO_INCREMENT,
workout_name VARCHAR(45)
);

CREATE TABLE users_workout(
user_id INT,
workout_id INT,
FOREIGN KEY (user_id) REFERENCES users(user_id),
FOREIGN KEY (workout_id) REFERENCES workout(workout_id)
);

CREATE TABLE info (
info_id INT PRIMARY KEY AUTO_INCREMENT,
weight INT,
sets INT,
reps INT
);

CREATE TABLE workout_info(
workout_id INT,
info_id INT,
FOREIGN KEY (workout_id) REFERENCES workout(workout_id),
FOREIGN KEY (info_id) REFERENCES info(info_id)
);

ALTER TABLE workout_info
ADD COLUMN grade VARCHAR(10);
SELECT * FROM workout_info;

INSERT INTO users VALUES 
(DEFAULT, "branislav", "branislav"),
(DEFAULT, "milica", "milica"),
(DEFAULT, "vasilija", "vasilija"),
(DEFAULT, "jovan", "jovan");

SELECT * FROM users;

INSERT INTO workout VALUES
(DEFAULT,"Bench Press"),
(DEFAULT,"Deadlift"),
(DEFAULT,"Squat"),
(DEFAULT,"Overhead Press"),
(DEFAULT,"Leg Press"),
(DEFAULT,"Dumbbell Curl"),
(DEFAULT,"Lat Pulldown");

SELECT * FROM workout;

INSERT INTO users_workout VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 5),
(2, 7),
(2, 4),
(3, 6),
(3, 1),
(4, 5);

SELECT users.user_id, users.user_name, workout.workout_name FROM users_workout uw
JOIN users ON uw.user_id = users.user_id
JOIN workout ON uw.workout_id = workout.workout_id;

INSERT INTO info VALUES
(DEFAULT, "80", "4", "10"),
(DEFAULT, "180", "6", "3"),
(DEFAULT, "100", "4", "8"),
(DEFAULT, "200", "4", "8"),
(DEFAULT, "60", "4", "12"),
(DEFAULT, "40", "3", "6"),
(DEFAULT, "15", "5", "12"),
(DEFAULT, "100", "3", "8"),
(DEFAULT, "150", "5", "6");

SELECT * FROM info;

INSERT INTO workout_info VALUES
("1", "1", "G"),
("2", "2", "VG"),
("3", "3", "F"),
("5", "4", "G"),
("7", "5", "VG"),
("4", "6", "VG"),
("6", "7", "G"),
("1", "8", "F"),
("5", "9", "G");

SELECT workout.workout_name, info.weight, info.sets, info.reps FROM workout_info wi 
JOIN workout ON wi.workout_id = workout.workout_id
JOIN info ON wi.info_id = info.info_id;

SELECT users.user_name, workout.workout_name, info.weight, info.sets, info.reps, workout_info.grade
FROM users
JOIN users_workout ON users.user_id = users_workout.user_id
JOIN workout ON users_workout.workout_id = workout.workout_id
JOIN workout_info ON workout_info.workout_id = workout.workout_id
JOIN info ON workout_info.info_id = info.info_id;

CREATE INDEX index_userName ON users(user_name(4));

CREATE USER gymnoteAppUser@localhost IDENTIFIED BY "gymnoteUser123";
GRANT SELECT, UPDATE, DELETE, INSERT
ON gymnotedb.*
TO gymnoteAppUser@localhost;

DELIMITER //
CREATE PROCEDURE add_user(
user_name_par VARCHAR(45),
user_password_par VARCHAR(15)
)
BEGIN
DECLARE user_name_count INT;
SET user_name_count = (SELECT COUNT(*) FROM users WHERE user_name = user_name_par);
   IF user_name_count = 0 THEN
      INSERT INTO users VALUES(DEFAULT, user_name_par, user_password_par);
   ELSE   
      SELECT "There already exists user with that name " AS message;
   END IF;   
END//
DELIMITER ;
SHOW GRANTS FOR "gymnoteAppUser"@"localhost";
CALL add_user("zorana", "zorana");
GRANT EXECUTE ON PROCEDURE add_user TO "gymnoteAppUser"@"localhost";
SELECT * FROM users;

DELIMITER //
CREATE PROCEDURE add_users_workout (
user_name_par VARCHAR(45),
workout_name_par VARCHAR(45),
sets_par INT,
reps_par INT,
weight_par INT,
grade_par VARCHAR(10)
)
BEGIN
DECLARE count_userName INT;
DECLARE this_user_id INT;
DECLARE this_workout_id INT;
DECLARE this_info_id INT;
DECLARE this_workout INT;

SET count_userName = (SELECT COUNT(*) FROM users WHERE user_name = user_name_par);
IF count_userName > 0 THEN
  INSERT INTO workout (workout_name) VALUES (workout_name_par);
  SET this_workout_id =  LAST_INSERT_ID();
  SET this_user_id = (SELECT user_id FROM users WHERE user_name = user_name_par);
  INSERT INTO users_workout (user_id, workout_id) VALUES (this_user_id, this_workout_id);
  INSERT INTO info (weight, sets, reps) VALUES (weight_par, sets_par, reps_par);
  SET this_workout = (SELECT MAX(workout_id) FROM workout);
  SET this_info_id = (SELECT MAX(info_id) FROM info);
  INSERT INTO workout_info (workout_id, info_id, grade) VALUES (this_workout, this_info_id, grade_par);
  ELSE
        SELECT 'User does not exist' AS message;
END IF;  
END//
DELIMITER ;


CALL add_users_workout ("Branislav", "Bench Press", 3, 4, 100, "G");

SELECT * FROM workout_info;
SELECT * FROM workout;
GRANT EXECUTE ON PROCEDURE add_users_workout TO "gymnoteAppUser"@"localhost";
SELECT * FROM info;


SELECT * FROM workout 
WHERE workout_name LIKE  "%b%";



CREATE VIEW show_users_workout AS
SELECT users.user_name, workout.workout_name, info.sets, info.reps, info.weight, workout_info.grade, workout.workout_id
FROM users 
JOIN users_workout ON users.user_id = users_workout.user_id
JOIN workout ON users_workout.workout_id = workout.workout_id
JOIN workout_info ON workout_info.workout_id = workout.workout_id
JOIN info ON workout_info.info_id = info.info_id;
SELECT * FROM show_users_workout;
SELECT * FROM show_users_workout
WHERE workout_name LIKE "s%";

DELIMITER //
CREATE PROCEDURE delet_workout (
user_name_par VARCHAR(45),
workout_id_par INT 
)
BEGIN
DECLARE userID INT;
SET userID = (SELECT user_id FROM users WHERE user_name_par = user_name);
DELETE FROM workout_info WHERE workout_id = workout_id_par;
DELETE FROM users_workout WHERE userID = user_id AND workout_id_par = workout_id;
END //
DELIMITER ;

GRANT EXECUTE ON PROCEDURE delet_workout TO "gymnoteAppUser"@"localhost";
SELECT * FROM users;
