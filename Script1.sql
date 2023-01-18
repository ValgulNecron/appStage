DROP DATABASE IF EXISTS stage2;
CREATE DATABASE stage2;
USE stage2;

CREATE TABLE utilisateur (
	nomUtilisateur varchar(20) PRIMARY KEY,
	hash varchar(120),
	themeBool bool
);

CREATE TABLE logAction (
	dateAction datetime,
	nomUtilisateur varchar(20),
	action varchar(50),
	adMac varchar(20),
	FOREIGN KEY (nomUtilisateur) REFERENCES utilisateur(nomUtilisateur),
	PRIMARY KEY (dateAction, nomUtilisateur)
);

CREATE TABLE logMotDePasse (
	dateLogMotDePasse datetime,
	hash varchar(120),
	nomUtilisateur varchar(20),
	FOREIGN KEY (hash) REFERENCES utilisateur(nomUtilisateur),
	PRIMARY KEY (dateLogMotDePasse, nomUtilisateur)
);


DROP PROCEDURE IF EXISTS getUtilisateur;
DELIMITER $$
CREATE PROCEDURE getUtilisateur()
BEGIN
	SELECT nomUtilisateur, hash
	FROM utilisateur;
END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS setUtilisateur;
DELIMITER $$
CREATE PROCEDURE setUtlisateur(targetUser varchar(20), setHash
	varchar(120), setThemeBool bool)
BEGIN
	UPDATE utilisateur 
	SET hash = setHash,
		themeBool = setThemeBool
	WHERE nomUtilisateur = targetUser;
END $$
DELIMITER ;


DROP FUNCTION IF EXISTS getLogMotDePasse;
DELIMITER $$
CREATE FUNCTION getLogMotDePasse(targetUser varchar(20)) returns date
BEGIN
	DECLARE dateRecente date;

	SELECT TOP(1) dateLogMotDePasse into dateRecente FROM logMotDePasse, utilisateur 
	WHERE logMotDePasse.nomUtilisateur = utilisateur.nomUtilisateur 
	AND nomUtilisateur = targetUser
	ORDER BY dateLogMotDePass DESC;

	return dateRecente;
END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS setLogAction;
DELIMITER $$
CREATE PROCEDURE setLogAction(nomUtilisateurValue varchar(20), 
	actionValue varchar(50), adMacValue varchar(20) )
BEGIN
	INSERT INTO logAction(dateAction, nomUtilisateur, action, adMac) VALUES
	(dateNow(), nomUtilisateurValue, actionValue, adMacValue);  
END $$
DELIMITER ;


DROP TRIGGER IF EXISTS updateMotDePasse;
DELIMITER $$
CREATE TRIGGER updateMotDePasse AFTER UPDATE ON utilisateur FOR EACH ROW
BEGIN
	IF (OLD.hash != NEW.hash) THEN
		INSERT INTO logMotDePasse(dateLogMotDePasse, hash, nomUtilisateur) VALUES
		(dateNow(), OLD.hash, OLD.nomUtilisateur);
	END IF;
END $$
DELIMITER ;


DROP USER IF EXISTS 'admin2'@'%';
CREATE USER 'admin2'@'%' Identified BY 'admin2';
GRANT ALL PRIVILEGES ON *.* to 'admin2'@'%' WITH GRANT OPTION;