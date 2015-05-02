DROP DATABASE  IF EXISTS `timebanks`;
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
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `id_category` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `dateadded` datetime DEFAULT CURRENT_TIMESTAMP,
  `parent_id` int(11) DEFAULT '0',
  PRIMARY KEY (`id_category`),
  UNIQUE KEY `id_category_UNIQUE` (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `member` (
  `id_member` char(36) NOT NULL DEFAULT 'UUID()',
  `id_timebank` int(11) NOT NULL,
  `approved` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'New users must be approved by the local timebank administrator',
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `street_address_1` varchar(100) DEFAULT NULL,
  `street_address_2` varchar(100) DEFAULT NULL,
  `suburb` varchar(50) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  `postcode` varchar(6) DEFAULT NULL,
  `mobile_phone` varchar(20) DEFAULT NULL,
  `home_phone` varchar(20) DEFAULT NULL,
  `work_phone` varchar(20) DEFAULT NULL,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `geo_lat` double DEFAULT NULL,
  `geo_long` double DEFAULT NULL,
  `phone_privacy` tinyint(1) NOT NULL COMMENT '0 = private\n1 = public to members of same time-bank',
  `email_address` varchar(100) NOT NULL,
  `is_address_public` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0 = private\n1 = public to member of same time-bank',
  `is_email_validated` tinyint(1) NOT NULL DEFAULT '0',
  `is_email_public` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0 = private\n1 = public to members of same time-bank',
  `is_deleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_member`),
  UNIQUE KEY `primary_email_UNIQUE` (`email_address`),
  KEY `member_timebank_fk_idx` (`id_timebank`),
  CONSTRAINT `member_timebank_fk` FOREIGN KEY (`id_timebank`) REFERENCES `timebank` (`id_timebank`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Timebank member';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `member_permission`
--

DROP TABLE IF EXISTS `member_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `member_permission` (
  `id_member_permission` int(11) NOT NULL,
  `id_member` char(36) NOT NULL,
  `id_permission` int(11) NOT NULL,
  PRIMARY KEY (`id_member_permission`),
  UNIQUE KEY `member_permission_uk` (`id_member`,`id_permission`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `offer_need`
--

DROP TABLE IF EXISTS `offer_need`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `offer_need` (
  `id_offer_need` int(11) NOT NULL AUTO_INCREMENT,
  `id_user` char(36) NOT NULL,
  `id_timebank` int(11) NOT NULL,
  `is_offer` tinyint(1) NOT NULL,
  `title` varchar(100) NOT NULL,
  `description` text,
  `created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `start_date` datetime DEFAULT NULL,
  `expiry_date` datetime NOT NULL,
  PRIMARY KEY (`id_offer_need`),
  KEY `offer_need_member_fk_idx` (`id_user`),
  KEY `offer_need_timebank_fk_idx` (`id_timebank`),
  CONSTRAINT `offer_need_member_fk` FOREIGN KEY (`id_user`) REFERENCES `member` (`id_member`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `offer_need_timebank_fk` FOREIGN KEY (`id_timebank`) REFERENCES `timebank` (`id_timebank`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='A Tradeable entity';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `permission`
--

DROP TABLE IF EXISTS `permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permission` (
  `id_permission` int(11) NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_permission`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tag`
--

DROP TABLE IF EXISTS `tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tag` (
  `id_tag` int(11) NOT NULL AUTO_INCREMENT,
  `id_member` char(36) DEFAULT NULL,
  `id_offer_need` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id_tag`),
  KEY `tag_member_fk_idx` (`id_member`),
  KEY `tag_offer_need_fk_idx` (`id_offer_need`),
  CONSTRAINT `tag_member_fk` FOREIGN KEY (`id_member`) REFERENCES `member` (`id_member`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `tag_offer_need_fk` FOREIGN KEY (`id_offer_need`) REFERENCES `offer_need` (`id_offer_need`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Tags for member, needs, offers.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `timebank`
--

DROP TABLE IF EXISTS `timebank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `timebank` (
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
-- Table structure for table `trade`
--

DROP TABLE IF EXISTS `trade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trade` (
  `id_trade` int(11) NOT NULL AUTO_INCREMENT,
  `id_payer` char(36) NOT NULL,
  `id_payee` char(36) NOT NULL,
  `id_need_want` int(11) NOT NULL,
  `hours` decimal(7,2) unsigned NOT NULL COMMENT '99,999 hours max per transaction',
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `description` text,
  PRIMARY KEY (`id_trade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-02 15:46:01
