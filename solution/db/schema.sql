CREATE DATABASE  IF NOT EXISTS `timebanks` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `timebanks`;
-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: timebanks
-- ------------------------------------------------------
-- Server version	5.6.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categories` (
  `id_category` int(11) NOT NULL,
  `is_parent` bit(1) NOT NULL DEFAULT b'0',
  `name` varchar(50) DEFAULT NULL,
  `dateadded` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `country` (
  `id_country` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `abbreviation` varchar(3) DEFAULT NULL,
  `date_added` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_country`),
  UNIQUE KEY `id_country_UNIQUE` (`id_country`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `members`
--

DROP TABLE IF EXISTS `members`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `members` (
  `id_members` char(36) NOT NULL DEFAULT 'UUID()',
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `street_address_1` varchar(100) DEFAULT NULL,
  `street_address_2` varchar(100) DEFAULT NULL,
  `suburb` varchar(50) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  `postcode` varchar(6) DEFAULT NULL,
  `timebank_id` int(11) DEFAULT NULL,
  `mobile_phone` varchar(20) DEFAULT NULL,
  `home_phone` varchar(20) DEFAULT NULL,
  `work_phone` varchar(20) DEFAULT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `approved` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'New users must be approved by the local timebank administrator',
  `geo_lat` double NOT NULL,
  `geo_long` double NOT NULL,
  `address_privacy` tinyint(1) NOT NULL COMMENT '0 = private\n1 = public to members of same time-bank',
  `phone_privacy` tinyint(1) NOT NULL,
  `primary_email` varchar(100) NOT NULL,
  `secondary_email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_members`),
  UNIQUE KEY `primary_email_UNIQUE` (`primary_email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Timebank members';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `members`
--

LOCK TABLES `members` WRITE;
/*!40000 ALTER TABLE `members` DISABLE KEYS */;
/*!40000 ALTER TABLE `members` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offer_need`
--

DROP TABLE IF EXISTS `offer_need`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `offer_need` (
  `id_offer_need` int(11) NOT NULL AUTO_INCREMENT,
  `is_offer` tinyint(1) NOT NULL,
  `id_user` int(11) NOT NULL,
  `geo_lat` double NOT NULL,
  `geo_long` double NOT NULL,
  `created` datetime NOT NULL,
  `title` varchar(100) NOT NULL,
  `description` text,
  PRIMARY KEY (`id_offer_need`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='A Tradeable entity';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offer_need`
--

LOCK TABLES `offer_need` WRITE;
/*!40000 ALTER TABLE `offer_need` DISABLE KEYS */;
/*!40000 ALTER TABLE `offer_need` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `timebanks`
--

DROP TABLE IF EXISTS `timebanks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `timebanks` (
  `id_timebank` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `url` varchar(255) NOT NULL,
  `geo_long` double DEFAULT NULL,
  `geo_lat` double DEFAULT NULL,
  `Address_1` varchar(100) NOT NULL,
  `Address_2` varchar(100) DEFAULT NULL,
  `suburb` varchar(100) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `Postcode` varchar(6) NOT NULL,
  `is_member_timebanknz` bit(1) DEFAULT b'0',
  `id_country` int(11) DEFAULT '1',
  `id_theme` int(11) DEFAULT '1',
  PRIMARY KEY (`id_timebank`),
  UNIQUE KEY `id_timebank_UNIQUE` (`id_timebank`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  UNIQUE KEY `url_UNIQUE` (`url`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Timebanks of NZ.  ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timebanks`
--

LOCK TABLES `timebanks` WRITE;
/*!40000 ALTER TABLE `timebanks` DISABLE KEYS */;
/*!40000 ALTER TABLE `timebanks` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-02 12:51:02
