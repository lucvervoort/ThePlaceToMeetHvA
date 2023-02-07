-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: theplacetomeet
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `reservatie`
--

DROP TABLE IF EXISTS `reservatie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservatie` (
  `Id` int NOT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservatie`
--

LOCK TABLES `reservatie` WRITE;
/*!40000 ALTER TABLE `reservatie` DISABLE KEYS */;
INSERT INTO `reservatie` VALUES (1,10,'2022-12-28 00:00:00.000000',8,5,10.00,0.00,10.00,2,NULL,1,1),(2,10,'2022-12-28 00:00:00.000000',14,4,10.00,0.00,10.00,NULL,NULL,1,1),(3,10,'2022-12-26 00:00:00.000000',9,4,10.00,0.00,12.00,NULL,NULL,1,2);
/*!40000 ALTER TABLE `reservatie` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-07 17:39:36
