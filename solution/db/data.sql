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
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Transporation','2015-05-02 14:01:43',0),(2,'Help At Home','2015-05-02 14:01:43',0),(3,'Companionship','2015-05-02 14:01:43',0),(4,'Community Activities','2015-05-02 14:01:43',0),(5,'Wellness','2015-05-02 14:01:43',0),(6,'Recreation','2015-05-02 14:01:43',0),(7,'Education','2015-05-02 14:01:43',0),(8,'Arts, Crafts & Music','2015-05-02 14:01:43',0),(9,'Home','2015-05-02 14:01:43',0),(10,'Business Services','2015-05-02 14:01:43',0),(11,'Misc','2015-05-02 14:01:43',0),(12,'Transporation','2015-05-02 14:04:26',0),(13,'Help At Home','2015-05-02 14:04:26',0),(14,'Companionship','2015-05-02 14:04:26',0),(15,'Community Activities','2015-05-02 14:04:26',0),(16,'Wellness','2015-05-02 14:04:26',0),(17,'Recreation','2015-05-02 14:04:26',0),(18,'Education','2015-05-02 14:04:26',0),(19,'Arts, Crafts & Music','2015-05-02 14:04:26',0),(20,'Home','2015-05-02 14:04:26',0),(21,'Business Services','2015-05-02 14:04:26',0),(22,'Misc','2015-05-02 14:04:26',0),(23,'Errands / Shopping','2015-05-02 14:04:26',1),(24,'Local','2015-05-02 14:04:26',1),(25,'Long Distance','2015-05-02 14:04:26',1),(26,'Medical','2015-05-02 14:04:26',1),(27,'Train / Bus / Airport','2015-05-02 14:04:26',1),(28,'Worship','2015-05-02 14:04:26',1),(29,'Miscellaneous','2015-05-02 14:04:26',1),(30,'Child Care','2015-05-02 14:04:26',2),(31,'Cooking & Sewing','2015-05-02 14:04:26',2),(32,'Hair & Beauty','2015-05-02 14:04:26',2),(33,'Housekeeping / Chores','2015-05-02 14:04:26',2),(34,'Pet Care','2015-05-02 14:04:26',2),(35,'Respite Care','2015-05-02 14:04:26',2),(36,'Miscellaneous','2015-05-02 14:04:26',2);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'New Zealand','NZL','2015-05-02 14:09:11',172.6362,-43.5321);
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `member_permission`
--

LOCK TABLES `member_permission` WRITE;
/*!40000 ALTER TABLE `member_permission` DISABLE KEYS */;
/*!40000 ALTER TABLE `member_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `offer_need`
--

LOCK TABLES `offer_need` WRITE;
/*!40000 ALTER TABLE `offer_need` DISABLE KEYS */;
/*!40000 ALTER TABLE `offer_need` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `permission`
--

LOCK TABLES `permission` WRITE;
/*!40000 ALTER TABLE `permission` DISABLE KEYS */;
/*!40000 ALTER TABLE `permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tag`
--

LOCK TABLES `tag` WRITE;
/*!40000 ALTER TABLE `tag` DISABLE KEYS */;
/*!40000 ALTER TABLE `tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `timebank`
--

LOCK TABLES `timebank` WRITE;
/*!40000 ALTER TABLE `timebank` DISABLE KEYS */;
INSERT INTO `timebank` VALUES (1,'Addington','www.addington.timebank.nz',172.6362,-43.5321,'21 Church Square','','Addington','Christchurch','8024','',1,1),(2,'Lyttleton','http://www.lyttelton.timebanks.org/',172.722783,-43.602495,'54a Oxford Street','','Lyttelton','Christchurch','8082','',1,1);
/*!40000 ALTER TABLE `timebank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `trade`
--

LOCK TABLES `trade` WRITE;
/*!40000 ALTER TABLE `trade` DISABLE KEYS */;
/*!40000 ALTER TABLE `trade` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-02 14:51:54
