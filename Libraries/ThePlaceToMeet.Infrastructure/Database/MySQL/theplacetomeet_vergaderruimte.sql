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
-- Table structure for table `vergaderruimte`
--

DROP TABLE IF EXISTS `vergaderruimte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vergaderruimte` (
  `Id` int NOT NULL,
  `Naam` varchar(4096) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `VergaderruimteType` int NOT NULL,
  `MaximumAantalPersonen` int NOT NULL,
  `PrijsPerUur` decimal(18,2) NOT NULL,
  `PrijsPerPersoonStandaardCatering` decimal(18,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vergaderruimte`
--

LOCK TABLES `vergaderruimte` WRITE;
/*!40000 ALTER TABLE `vergaderruimte` DISABLE KEYS */;
INSERT INTO `vergaderruimte` VALUES (1,'Brainstorm Room - 1',0,10,15.00,10.00),(2,'Brainstorm Room - 2',0,20,30.00,10.00),(3,'Brainstorm Room - 3',0,30,45.00,10.00),(4,'Break Out Room - 1',1,10,16.00,10.00),(5,'Break Out Room - 2',1,20,32.00,10.00),(6,'Break Out Room - 3',1,30,48.00,10.00),(7,'Meeting Room - 1',2,10,17.00,10.00),(8,'Meting Room - 2',2,20,34.00,10.00),(9,'Meeting Room - 3',2,30,51.00,10.00);
/*!40000 ALTER TABLE `vergaderruimte` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-07 17:39:37
