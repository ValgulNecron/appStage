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

CREATE TABLE etablissement (
	nomEtablissement varchar(35) PRIMARY KEY,
	nomRueEtablissement varchar(35),
	numeroRueEtablissement int,
	codePostaleEtablissement varchar(15),
	villeEtablissement varchar(30),
	numeroTelephoneEtablissement varchar(15),
	emailEtablissement varchar(60)
);

---------
INSERT INTO utilisateur(nomUtilisateur, hash, themeBool) VALUES
("keyuser", "xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz", 0);

-- xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz -- keyuser

---------- 

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

-- local que depuis localhost et le % c'est partout, oui partout
DROP USER IF EXISTS 'admin_user'@'%';
CREATE USER 'admin_user'@'%' Identified BY 'kreyderslam2!';
GRANT ALL PRIVILEGES ON *.* to 'admin_user'@'%' WITH GRANT OPTION;
Flush PRIVILEGES;
