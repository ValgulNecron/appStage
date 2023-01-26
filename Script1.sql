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

DROP USER IF EXISTS 'admin2'@'%';
CREATE USER 'admin2'@'%' Identified BY 'admin2';
GRANT ALL PRIVILEGES ON *.* to 'admin2'@'%' WITH GRANT OPTION;
