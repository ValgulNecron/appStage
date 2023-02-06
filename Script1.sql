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
	nomEtablissement varchar(35) PRIMARY KEY,
	nomRueEtablissement varchar(35),
	numeroRueEtablissement int,
	codePostaleEtablissement varchar(15),
	villeEtablissement varchar(30),
	numeroTelephoneEtablissement varchar(20),
	emailEtablissement varchar(60),
	urlEtablissement varchar(120),
	codeHexa6eme varchar(7),
	codeHexa5eme varchar(7),
	codeHexa4eme varchar(7),
	codeHexa3eme varchar(7)
);

INSERT INTO utilisateur VALUES("keyuser", "xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz", "admin",0);
-- xKVfl8R9C3RJWCRMyfJUvGnhbUCfEa8NdZglhdoHBI12n7Fz -- keyuser

insert into etablissement values ("default", "default", 5, "default", "default", "default", "default", "default",   "#FFFF00", "#00FF00", "#FF0000", "#0000FF");
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