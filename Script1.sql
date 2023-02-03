DROP DATABASE IF EXISTS stage2;
CREATE DATABASE stage2;
USE stage2;

CREATE TABLE utilisateur (
	nomUtilisateur varchar(20) PRIMARY KEY,
	hash varchar(120),
	typeUtilisateur varchar(20),
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
	FOREIGN KEY (nomUtilisateur) REFERENCES utilisateur(nomUtilisateur),
	PRIMARY KEY (dateLogMotDePasse, nomUtilisateur)
);

CREATE TABLE etablissement (
	nomEtablissement varchar(35) PRIMARY KEY default "default",
	nomRueEtablissement varchar(35) default "default",
	numeroRueEtablissement int default 5,
	codePostaleEtablissement varchar(15) default "default",
	villeEtablissement varchar(30) default "default",
	numeroTelephoneEtablissement varchar(20) default "default",
	emailEtablissement varchar(60) default "default",
	urlEtablissement varchar(120) default "default",
	codeHexa6eme varchar(7) default "#FFFF00",
	codeHexa5eme varchar(7) default "#00FF00",
	codeHexa4eme varchar(7) default "#FF0000",
	codeHexa3eme varchar(7) default "#0000FF"
);

INSERT INTO utilisateur VALUES("keyuser", "xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz", "admin",0);
-- xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz -- keyuser


DROP TRIGGER IF EXISTS updateMotDePasse;
DELIMITER $$
CREATE TRIGGER updateMotDePasse AFTER UPDATE ON utilisateur FOR EACH ROW
BEGIN
	IF (OLD.hash != NEW.hash) THEN
		INSERT INTO logMotDePasse(dateLogMotDePasse, hash, nomUtilisateur) VALUES
		(CURRENT_TIMESTAMP, OLD.hash, OLD.nomUtilisateur);
	END IF;
END $$
DELIMITER ;

drop trigger if exists verifTypeUtilisateur;
DELIMITER $$
create trigger verifTypeUtilisateur before insert on utilisateur for each row
begin
    if (new.typeUtilisateur != "admin" and new.typeUtilisateur != "utilisateur") then
        signal sqlstate '45000' set message_text = "Le type d'utilisateur doit être 'admin' ou 'user'";
    end if;
end $$

DROP USER IF EXISTS 'admin_user'@'%';
CREATE USER 'admin_user'@'%' Identified BY 'kreyderslam2!';
GRANT ALL PRIVILEGES ON *.* to 'admin_user'@'%' WITH GRANT OPTION;
Flush PRIVILEGES;