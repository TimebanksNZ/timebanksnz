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
  `id_category` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `dateadded` datetime DEFAULT CURRENT_TIMESTAMP,
  `parent_id` int(11) DEFAULT '0',
  PRIMARY KEY (`id_category`),
  UNIQUE KEY `id_category_UNIQUE` (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Transporation','2015-05-02 14:01:43',0),(2,'Help At Home','2015-05-02 14:01:43',0),(3,'Companionship','2015-05-02 14:01:43',0),(4,'Community Activities','2015-05-02 14:01:43',0),(5,'Wellness','2015-05-02 14:01:43',0),(6,'Recreation','2015-05-02 14:01:43',0),(7,'Education','2015-05-02 14:01:43',0),(8,'Arts, Crafts & Music','2015-05-02 14:01:43',0),(9,'Home','2015-05-02 14:01:43',0),(10,'Business Services','2015-05-02 14:01:43',0),(11,'Misc','2015-05-02 14:01:43',0),(12,'Transporation','2015-05-02 14:04:26',0),(13,'Help At Home','2015-05-02 14:04:26',0),(14,'Companionship','2015-05-02 14:04:26',0),(15,'Community Activities','2015-05-02 14:04:26',0),(16,'Wellness','2015-05-02 14:04:26',0),(17,'Recreation','2015-05-02 14:04:26',0),(18,'Education','2015-05-02 14:04:26',0),(19,'Arts, Crafts & Music','2015-05-02 14:04:26',0),(20,'Home','2015-05-02 14:04:26',0),(21,'Business Services','2015-05-02 14:04:26',0),(22,'Misc','2015-05-02 14:04:26',0),(23,'Errands / Shopping','2015-05-02 14:04:26',1),(24,'Local','2015-05-02 14:04:26',1),(25,'Long Distance','2015-05-02 14:04:26',1),(26,'Medical','2015-05-02 14:04:26',1),(27,'Train / Bus / Airport','2015-05-02 14:04:26',1),(28,'Worship','2015-05-02 14:04:26',1),(29,'Miscellaneous','2015-05-02 14:04:26',1),(30,'Child Care','2015-05-02 14:04:26',2),(31,'Cooking & Sewing','2015-05-02 14:04:26',2),(32,'Hair & Beauty','2015-05-02 14:04:26',2),(33,'Housekeeping / Chores','2015-05-02 14:04:26',2),(34,'Pet Care','2015-05-02 14:04:26',2),(35,'Respite Care','2015-05-02 14:04:26',2),(36,'Miscellaneous','2015-05-02 14:04:26',2);
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
  `date_added` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `geo_long` double NOT NULL DEFAULT '0',
  `geo_lat` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_country`),
  UNIQUE KEY `id_country_UNIQUE` (`id_country`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'New Zealand','NZL','2015-05-02 14:09:11',172.6362,-43.5321);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='Timebanks of NZ.  ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timebanks`
--

LOCK TABLES `timebanks` WRITE;
/*!40000 ALTER TABLE `timebanks` DISABLE KEYS */;
INSERT INTO `timebanks` VALUES (1,'Addington','www.addington.timebanks.nz',172.6362,-43.5321,'21 Church Square','','Addington','Christchurch','8024','',1,1),(2,'Lyttleton','http://www.lyttelton.timebanks.org/',172.722783,-43.602495,'54a Oxford Street','','Lyttelton','Christchurch','8082','',1,1);
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

-- Dump completed on 2015-05-02 14:12:20
