-- create database theplacetomeet;
use theplacetomeet;

DROP TABLE IF EXISTS `vergaderruimte`;
CREATE TABLE `vergaderruimte` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Naam` varchar(4096) DEFAULT NULL,
  `VergaderruimteType` int NOT NULL,
  `MaximumAantalPersonen` int NOT NULL,
  `PrijsPerUur` decimal(18,2) NOT NULL,
  `PrijsPerPersoonStandaardCatering` decimal(18,2) NOT NULL,
  PRIMARY KEY (`Id`)
);

LOCK TABLES `vergaderruimte` WRITE;
INSERT INTO `vergaderruimte` VALUES (1,'Brainstorm Room - 1',0,10,15.00,10.00),(2,'Brainstorm Room - 2',0,20,30.00,10.00),(3,'Brainstorm Room - 3',0,30,45.00,10.00),(4,'Break Out Room - 1',1,10,16.00,10.00),(5,'Break Out Room - 2',1,20,32.00,10.00),(6,'Break Out Room - 3',1,30,48.00,10.00),(7,'Meeting Room - 1',2,10,17.00,10.00),(8,'Meting Room - 2',2,20,34.00,10.00),(9,'Meeting Room - 3',2,30,51.00,10.00);
UNLOCK TABLES;

DROP TABLE IF EXISTS `catering`;
CREATE TABLE `catering` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Titel` varchar(100) NOT NULL,
  `Beschrijving` varchar(2048) NOT NULL,
  `PrijsPerPersoon` decimal(18,2) NOT NULL,
  PRIMARY KEY (`Id`)
);

LOCK TABLES `catering` WRITE;
INSERT INTO `catering` VALUES (1,'Salad in a jar','Salad in a jar',10.00),(2,'Broodjes','Broodjes',8.00),(3,'Sushi - Sashimi','Sushi - Sashimi',12.00);
UNLOCK TABLES;

DROP TABLE IF EXISTS `klant`;
CREATE TABLE `klant` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(100) NOT NULL,
  `Naam` varchar(100) NOT NULL,
  `Voornaam` varchar(100) NOT NULL,
  `GSM` varchar(4096) DEFAULT NULL,
  `Bedrijf` varchar(4096) DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `korting`;
CREATE TABLE `korting` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Percentage` int NOT NULL,
  `MinimumAantalReservatiesInJaar` int NOT NULL,
  PRIMARY KEY (`Id`)
);

LOCK TABLES `korting` WRITE;
INSERT INTO `korting` VALUES (1,5,3),(2,10,10);
UNLOCK TABLES;

LOCK TABLES `klant` WRITE;
INSERT INTO `klant` VALUES (1,'peter@hogent.be','Claeyssens','Peter','NULL','HoGent'),(2,'jan@gmail.com','Peeters','Jan','NULL','HoGent'),(3,'luc.vervoort@gmail.com','Vervoort','Luc','+32474437397','Luveco');
UNLOCK TABLES;

DROP TABLE IF EXISTS `reservatie`;
CREATE TABLE `reservatie` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AantalPersonen` int NOT NULL,
  `Dag` datetime(6) NOT NULL,
  `BeginUur` int NOT NULL,
  `DuurInUren` int NOT NULL,
  `PrijsPerUur` decimal(18,2) NOT NULL,
  `PrijsPerPersoonStandaardCatering` decimal(18,2) NOT NULL,
  `PrijsPerPersoonCatering` decimal(18,2) NOT NULL,
  `CateringId` int DEFAULT NULL,
  `KortingId` int DEFAULT NULL,
  `VergaderruimteId` int NOT NULL,
  `KlantId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Reservatie_CateringId` (`CateringId`),
  KEY `IX_Reservatie_KlantId` (`KlantId`),
  KEY `IX_Reservatie_KortingId` (`KortingId`),
  KEY `IX_Reservatie_VergaderruimteId` (`VergaderruimteId`),
  CONSTRAINT `FK_Reservatie_Catering_CateringId` FOREIGN KEY (`CateringId`) REFERENCES `catering` (`Id`),
  CONSTRAINT `FK_Reservatie_Klant_KlantId` FOREIGN KEY (`KlantId`) REFERENCES `klant` (`Id`),
  CONSTRAINT `FK_Reservatie_Korting_KortingId` FOREIGN KEY (`KortingId`) REFERENCES `korting` (`Id`),
  CONSTRAINT `FK_Reservatie_Vergaderruimte_VergaderruimteId` FOREIGN KEY (`VergaderruimteId`) REFERENCES `vergaderruimte` (`Id`)
);

LOCK TABLES `reservatie` WRITE;
INSERT INTO `reservatie` VALUES (1,10,'2022-12-28 00:00:00.000000',8,5,10.00,0.00,10.00,2,NULL,1,1),(2,10,'2022-12-28 00:00:00.000000',14,4,10.00,0.00,10.00,NULL,NULL,1,1),(3,10,'2022-12-26 00:00:00.000000',9,4,10.00,0.00,12.00,NULL,NULL,1,2);
UNLOCK TABLES;