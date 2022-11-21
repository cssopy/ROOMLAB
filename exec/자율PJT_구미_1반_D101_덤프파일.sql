-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: k7d101.p.ssafy.io    Database: dream
-- ------------------------------------------------------
-- Server version	8.0.31-0ubuntu0.20.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `experimentations`
--

DROP TABLE IF EXISTS `experimentations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `experimentations` (
  `exp_idx` bigint NOT NULL AUTO_INCREMENT,
  `exp_answer_1` varchar(255) DEFAULT NULL,
  `exp_answer_2` varchar(255) DEFAULT NULL,
  `exp_answer_3` varchar(255) DEFAULT NULL,
  `exp_answer_4` varchar(255) DEFAULT NULL,
  `exp_answer_5` varchar(255) DEFAULT NULL,
  `exp_grade` int DEFAULT NULL,
  `exp_subject` varchar(255) DEFAULT NULL,
  `exp_title` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`exp_idx`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `experimentations`
--

LOCK TABLES `experimentations` WRITE;
/*!40000 ALTER TABLE `experimentations` DISABLE KEYS */;
INSERT INTO `experimentations` VALUES (1,'-','정전기 유도','절연체','털 뭉치','+',2,'물리','마찰 전기 관찰'),(2,'팽창','열 팽창률','철','구리','수축',2,'화학','열 팽창과 바이메탈'),(3,'염화 나트륨','질산 구리','보라색','빨간색','황록색',2,'화학','불꽃 반응'),(4,'용해도','크로마토그래피','성분 물질','노랑','보라',2,'화학','종이 크로마토그래피'),(5,'염화 은','아이오딘 화','납','아이오딘화 납','앙금',2,'화학','앙금 생성 반응'),(6,'북','남','N','S','동일한',2,'물리','자석 주위의 자기장 관찰'),(7,'흰색','없다','보존','탄산 칼슘','질량 보존',3,'화학','화학 반응에서의 질량 보존 법칙'),(8,'산소','가장자리','1.0','0.2','일정 성분비',3,'화학','구리의 연소 반응'),(9,'세포 주기','세포 핵','염색체','간기','개수',3,'생물','체세포 분열 관찰'),(10,'긴','넘치지 않도록','염화 나트륨','나프탈렌','거름',2,'화학','거름 실험');
/*!40000 ALTER TABLE `experimentations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pictures`
--

DROP TABLE IF EXISTS `pictures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pictures` (
  `pic_idx` bigint NOT NULL AUTO_INCREMENT,
  `pic_name` varchar(255) DEFAULT NULL,
  `pic_size` bigint DEFAULT NULL,
  `pic_url` text,
  `rep_idx` int DEFAULT NULL,
  PRIMARY KEY (`pic_idx`),
  KEY `FKs7m5uhib2cjkivraklnkxi45y` (`rep_idx`),
  CONSTRAINT `FKs7m5uhib2cjkivraklnkxi45y` FOREIGN KEY (`rep_idx`) REFERENCES `reports` (`rep_idx`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pictures`
--

LOCK TABLES `pictures` WRITE;
/*!40000 ALTER TABLE `pictures` DISABLE KEYS */;
INSERT INTO `pictures` VALUES (1,'1_1_com.oculus.shellenv-20221107-102514.jpg',460915,'https://k7d101.p.ssafy.io/api/static/img/1_1_com.oculus.shellenv-20221107-102514.jpg',1),(2,'1_1_com.oculus.shellenv-20221107-102507.jpg',183709,'https://k7d101.p.ssafy.io/api/static/img/1_1_com.oculus.shellenv-20221107-102507.jpg',1),(3,'1_1_com.oculus.shellenv-20221107-102401.jpg',188434,'https://k7d101.p.ssafy.io/api/static/img/1_1_com.oculus.shellenv-20221107-102401.jpg',1),(4,'1_1_com.oculus.shellenv-20221107-102349.jpg',186724,'https://k7d101.p.ssafy.io/api/static/img/1_1_com.oculus.shellenv-20221107-102349.jpg',1),(5,'1_3_com.oculus.shellenv-20221107-102349.jpg',186724,'https://k7d101.p.ssafy.io/api/static/img/1_3_com.oculus.shellenv-20221107-102349.jpg',3),(9,'1_1.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_1.jpg',56),(10,'1_3.jpg',84476,'https://k7d101.p.ssafy.io/api/static/img/1_3.jpg',56),(11,'1_1.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_1.jpg',120),(12,'1_2.jpg',109925,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',121),(13,'1_3.jpg',84476,'https://k7d101.p.ssafy.io/api/static/img/1_3.jpg',121),(14,'1_2.jpg',109925,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',122),(15,'1_2.jpg',109925,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',123),(16,'1_2.jpg',109925,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',124),(17,'1_1.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_1.jpg',124),(18,'1_1.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_1.jpg',125),(19,'1_3.jpg',84476,'https://k7d101.p.ssafy.io/api/static/img/1_3.jpg',125),(20,'1_2.jpg',109925,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',125),(21,'1_1.jpg',141740,'https://k7d101.p.ssafy.io/api/static/img/1_1.jpg',NULL),(22,'1_2.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',NULL),(23,'1_2_2.jpg',65054,'https://k7d101.p.ssafy.io/api/static/img/1_2_2.jpg',NULL),(24,'1_3.jpg',132415,'https://k7d101.p.ssafy.io/api/static/img/1_3.jpg',NULL),(25,'1_4_1.jpg',112723,'https://k7d101.p.ssafy.io/api/static/img/1_4_1.jpg',NULL),(26,'1_4_2.jpg',63467,'https://k7d101.p.ssafy.io/api/static/img/1_4_2.jpg',NULL),(27,'1_5.jpg',148773,'https://k7d101.p.ssafy.io/api/static/img/1_5.jpg',NULL),(28,'1_6_1.jpg',103778,'https://k7d101.p.ssafy.io/api/static/img/1_6_1.jpg',NULL),(29,'1_7_1.jpg',84476,'https://k7d101.p.ssafy.io/api/static/img/1_7_1.jpg',NULL),(30,'1_7_2.jpg',74815,'https://k7d101.p.ssafy.io/api/static/img/1_7_2.jpg',NULL),(31,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',NULL),(32,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',NULL),(33,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',NULL),(34,'2_4.jpg',56582,'https://k7d101.p.ssafy.io/api/static/img/2_4.jpg',NULL),(35,'2_5.jpg',69945,'https://k7d101.p.ssafy.io/api/static/img/2_5.jpg',NULL),(36,'2_6.jpg',80397,'https://k7d101.p.ssafy.io/api/static/img/2_6.jpg',NULL),(37,'3_1.jpg',97059,'https://k7d101.p.ssafy.io/api/static/img/3_1.jpg',NULL),(38,'3_2.jpg',71302,'https://k7d101.p.ssafy.io/api/static/img/3_2.jpg',NULL),(39,'3_2_1.jpg',108151,'https://k7d101.p.ssafy.io/api/static/img/3_2_1.jpg',NULL),(40,'3_2_2.jpg',62152,'https://k7d101.p.ssafy.io/api/static/img/3_2_2.jpg',NULL),(41,'3_3.jpg',81715,'https://k7d101.p.ssafy.io/api/static/img/3_3.jpg',NULL),(42,'3_3_1.jpg',42266,'https://k7d101.p.ssafy.io/api/static/img/3_3_1.jpg',NULL),(43,'3_3_2.jpg',50305,'https://k7d101.p.ssafy.io/api/static/img/3_3_2.jpg',NULL),(44,'3_3_3.jpg',37957,'https://k7d101.p.ssafy.io/api/static/img/3_3_3.jpg',NULL),(45,'3_3_4.jpg',36517,'https://k7d101.p.ssafy.io/api/static/img/3_3_4.jpg',NULL),(46,'3_3_5.jpg',40077,'https://k7d101.p.ssafy.io/api/static/img/3_3_5.jpg',NULL),(47,'4_1.jpg',45077,'https://k7d101.p.ssafy.io/api/static/img/4_1.jpg',NULL),(48,'4_2.jpg',43158,'https://k7d101.p.ssafy.io/api/static/img/4_2.jpg',NULL),(49,'4_3.jpg',72596,'https://k7d101.p.ssafy.io/api/static/img/4_3.jpg',NULL),(50,'4_4.jpg',31956,'https://k7d101.p.ssafy.io/api/static/img/4_4.jpg',NULL),(51,'4_5.jpg',79126,'https://k7d101.p.ssafy.io/api/static/img/4_5.jpg',NULL),(52,'4_6.jpg',48073,'https://k7d101.p.ssafy.io/api/static/img/4_6.jpg',NULL),(53,'6_1.jpg',124568,'https://k7d101.p.ssafy.io/api/static/img/6_1.jpg',NULL),(54,'8_1.jpg',74165,'https://k7d101.p.ssafy.io/api/static/img/8_1.jpg',NULL),(55,'8_2.jpg',78614,'https://k7d101.p.ssafy.io/api/static/img/8_2.jpg',NULL),(56,'8_3.jpg',75932,'https://k7d101.p.ssafy.io/api/static/img/8_3.jpg',NULL),(57,'8_4.jpg',79533,'https://k7d101.p.ssafy.io/api/static/img/8_4.jpg',NULL),(58,'8_5.jpg',71736,'https://k7d101.p.ssafy.io/api/static/img/8_5.jpg',NULL),(59,'10_1.jpg',141676,'https://k7d101.p.ssafy.io/api/static/img/10_1.jpg',NULL),(60,'10_2.jpg',143466,'https://k7d101.p.ssafy.io/api/static/img/10_2.jpg',NULL),(61,'10_3.jpg',46234,'https://k7d101.p.ssafy.io/api/static/img/10_3.jpg',NULL),(62,'1_2.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',127),(63,'1_4_2.jpg',63467,'https://k7d101.p.ssafy.io/api/static/img/1_4_2.jpg',127),(64,'1_4_1.jpg',112723,'https://k7d101.p.ssafy.io/api/static/img/1_4_1.jpg',136),(65,'1_2.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',136),(66,'1_4_2.jpg',63467,'https://k7d101.p.ssafy.io/api/static/img/1_4_2.jpg',136),(67,'1_5.jpg',148773,'https://k7d101.p.ssafy.io/api/static/img/1_5.jpg',136),(68,'1_3.jpg',132415,'https://k7d101.p.ssafy.io/api/static/img/1_3.jpg',136),(69,'1_2_2.jpg',65054,'https://k7d101.p.ssafy.io/api/static/img/1_2_2.jpg',141),(70,'1_2.jpg',106209,'https://k7d101.p.ssafy.io/api/static/img/1_2.jpg',141),(71,'4_1.jpg',45077,'https://k7d101.p.ssafy.io/api/static/img/4_1.jpg',145),(72,'4_2.jpg',43158,'https://k7d101.p.ssafy.io/api/static/img/4_2.jpg',145),(73,'4_3.jpg',72596,'https://k7d101.p.ssafy.io/api/static/img/4_3.jpg',145),(74,'4_4.jpg',31956,'https://k7d101.p.ssafy.io/api/static/img/4_4.jpg',145),(75,'4_6.jpg',48073,'https://k7d101.p.ssafy.io/api/static/img/4_6.jpg',145),(76,'6_1.jpg',124568,'https://k7d101.p.ssafy.io/api/static/img/6_1.jpg',146),(77,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',147),(78,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',147),(79,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',147),(80,'2_4.jpg',56582,'https://k7d101.p.ssafy.io/api/static/img/2_4.jpg',147),(81,'2_6.jpg',80397,'https://k7d101.p.ssafy.io/api/static/img/2_6.jpg',147),(82,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',151),(83,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',151),(84,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',151),(85,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',154),(86,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',154),(87,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',154),(88,'2_4.jpg',56582,'https://k7d101.p.ssafy.io/api/static/img/2_4.jpg',154),(89,'2_5.jpg',69945,'https://k7d101.p.ssafy.io/api/static/img/2_5.jpg',154),(90,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',156),(91,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',156),(92,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',157),(93,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',157),(94,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',158),(95,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',158),(96,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',160),(97,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',160),(98,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',161),(99,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',161),(100,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',161),(101,'8_1.jpg',74165,'https://k7d101.p.ssafy.io/api/static/img/8_1.jpg',162),(102,'8_5.jpg',71736,'https://k7d101.p.ssafy.io/api/static/img/8_5.jpg',162),(103,'8_2.jpg',78614,'https://k7d101.p.ssafy.io/api/static/img/8_2.jpg',162),(104,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',163),(105,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',163),(106,'2_6.jpg',80397,'https://k7d101.p.ssafy.io/api/static/img/2_6.jpg',163),(107,'2_3.jpg',38531,'https://k7d101.p.ssafy.io/api/static/img/2_3.jpg',164),(108,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',164),(109,'2_1.jpg',119433,'https://k7d101.p.ssafy.io/api/static/img/2_1.jpg',165),(110,'2_2.jpg',78251,'https://k7d101.p.ssafy.io/api/static/img/2_2.jpg',165),(111,'2_6.jpg',80397,'https://k7d101.p.ssafy.io/api/static/img/2_6.jpg',165);
/*!40000 ALTER TABLE `pictures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refresh`
--

DROP TABLE IF EXISTS `refresh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refresh` (
  `ref_idx` bigint NOT NULL AUTO_INCREMENT,
  `ref_token` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ref_idx`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refresh`
--

LOCK TABLES `refresh` WRITE;
/*!40000 ALTER TABLE `refresh` DISABLE KEYS */;
INSERT INTO `refresh` VALUES (8,'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiLtlZjsnbQiLCJyb2xlcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjY4NTcyOTI5LCJleHAiOjE2Njg1NzM1Mjl9.ryMvUMa6Ag4xxsIiyAFdJRZLGiZ7Ng2o0tM8bfAgMXo'),(31,'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJoZWV3b24iLCJyb2xlcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjY4ODY3NDY3LCJleHAiOjE2Njg4NjgwNjd9.AUb_c--iCRIPf6aq4oiZQbaUgwJaReWRlZW1w9HyJgY'),(44,'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJoc21rMDA3NiIsInJvbGVzIjpbIlJPTEVfVVNFUiJdLCJpYXQiOjE2Njg5Mjk5MTYsImV4cCI6MTY2ODkzMDUxNn0.d6NUVq0Goza-_m6tENYPQ0X4A5F96Bwt1irrJgEg6WA'),(49,'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiLtmLgiLCJyb2xlcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjY4OTgxMDc2LCJleHAiOjE2NzAyNzcwNzZ9.Oza-3JmE0ccWUxvwXafJKUU9v2UZ4iACFVrCTigc2AM'),(50,'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiLtlZgiLCJyb2xlcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjY4OTg0NjE1LCJleHAiOjE2NzAyODA2MTV9.c9F9GjiuPrfJbmJ7iLlBv9PMFsAM8J5h3THPu1RJAtg'),(51,'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiLsnbTsoJXsnqwiLCJyb2xlcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjY4OTg1ODEwLCJleHAiOjE2NzAyODE4MTB9.VgC-yXWEKaPCXRDe-k8SJOqKLF5YDtzQB2Cjfce4U5A');
/*!40000 ALTER TABLE `refresh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reports`
--

DROP TABLE IF EXISTS `reports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reports` (
  `rep_idx` int NOT NULL AUTO_INCREMENT,
  `rep_answer_1` varchar(255) DEFAULT NULL,
  `rep_answer_2` varchar(255) DEFAULT NULL,
  `rep_answer_3` varchar(255) DEFAULT NULL,
  `rep_answer_4` varchar(255) DEFAULT NULL,
  `rep_answer_5` varchar(255) DEFAULT NULL,
  `rep_date` datetime(6) DEFAULT NULL,
  `rep_score` int DEFAULT NULL,
  `exp_idx` bigint DEFAULT NULL,
  `user_idx` bigint DEFAULT NULL,
  PRIMARY KEY (`rep_idx`),
  KEY `FKeu1hhyrlo7en70w9749vnbms2` (`exp_idx`),
  KEY `FKqcnugnndarmk9k7pd6su8wyll` (`user_idx`),
  CONSTRAINT `FKeu1hhyrlo7en70w9749vnbms2` FOREIGN KEY (`exp_idx`) REFERENCES `experimentations` (`exp_idx`),
  CONSTRAINT `FKqcnugnndarmk9k7pd6su8wyll` FOREIGN KEY (`user_idx`) REFERENCES `users` (`user_idx`)
) ENGINE=InnoDB AUTO_INCREMENT=166 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reports`
--

LOCK TABLES `reports` WRITE;
/*!40000 ALTER TABLE `reports` DISABLE KEYS */;
INSERT INTO `reports` VALUES (1,'-','정전기 유도','절연체','털 뭉치','+','2022-11-14 04:25:01.557000',100,1,1),(2,'염화 마그네슘','질산 구리','빨간색','보라색','','2022-11-14 10:11:43.144000',20,3,1),(3,'증발','열 팽창률','구리','열 전도율','팽창','2022-11-15 05:09:09.417000',20,2,1),(4,'파란색','염화 칼슘','','','','2022-11-15 05:11:09.059000',0,3,1),(5,'','','','','','2022-11-15 05:15:19.838000',0,3,1),(6,'','','','','','2022-11-15 05:17:36.268000',0,3,1),(7,'','','','','','2022-11-15 05:17:36.867000',0,3,1),(8,'','','','','','2022-11-15 05:17:37.384000',0,3,1),(9,'','','','','','2022-11-15 05:17:37.855000',0,3,1),(10,'','','','','','2022-11-15 05:17:38.347000',0,3,1),(11,'','','','','','2022-11-15 05:17:38.829000',0,3,1),(12,'','','','','','2022-11-15 05:17:39.318000',0,3,1),(13,'','','','','','2022-11-15 05:17:39.831000',0,3,1),(14,'','','','','','2022-11-15 05:17:40.329000',0,3,1),(15,'','','','','','2022-11-15 05:17:40.839000',0,3,1),(16,'-','정전기 유도','절연체','털 뭉치','+','2022-11-16 15:56:46.646000',100,1,2),(17,'-','정전기 유도','절연체','털 뭉치','+','2022-11-16 15:56:47.983000',100,1,2),(18,'-','정전기 유도','절연체','털 뭉치','+','2022-11-16 15:56:48.927000',100,1,2),(19,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:07:56.390000',20,1,2),(20,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:02.441000',20,1,2),(21,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:03.512000',20,1,2),(22,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:04.179000',20,1,2),(23,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:04.373000',20,1,2),(24,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:04.521000',20,1,2),(25,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:04.664000',20,1,2),(26,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:04.761000',20,1,2),(27,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:04.938000',20,1,2),(28,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:05.043000',20,1,2),(29,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:05.182000',20,1,2),(30,'+','절연체','정전기 유도','털 뭉치','-','2022-11-17 03:08:14.332000',20,1,2),(31,'','','','','','2022-11-17 03:16:31.434000',0,1,2),(32,'-','정전기 유도','절연체','털 뭉치','집전체','2022-11-17 03:23:39.806000',80,1,2),(33,'','','','','','2022-11-17 03:25:21.521000',0,1,2),(34,'','검전기 유도','','','','2022-11-17 03:33:09.010000',0,1,2),(35,'','','','','','2022-11-17 03:36:36.681000',0,1,2),(36,'','','','','','2022-11-17 03:41:32.048000',0,1,2),(37,'','','','','','2022-11-17 03:47:53.950000',0,1,2),(38,'','','','','','2022-11-17 03:51:38.128000',0,1,2),(39,'','','','','','2022-11-17 03:57:51.499000',0,1,2),(40,'','','','','','2022-11-17 03:59:54.167000',0,1,2),(41,'','','','','','2022-11-17 04:08:50.536000',0,1,2),(42,'','','','','','2022-11-17 05:18:04.617000',0,3,1),(43,'','','','','','2022-11-17 05:20:10.089000',0,3,1),(44,'','','','','','2022-11-17 05:25:21.009000',0,3,1),(45,'','','','','','2022-11-17 05:25:23.528000',0,3,1),(46,'','','','','','2022-11-17 05:26:41.536000',0,3,1),(47,'','','','','','2022-11-17 05:26:43.657000',0,3,1),(48,'','','','','','2022-11-17 05:27:22.065000',0,3,1),(49,'','','','','','2022-11-17 05:28:23.201000',0,3,1),(50,'','','','','','2022-11-17 05:51:36.415000',0,3,1),(51,'','','','','','2022-11-17 05:55:36.933000',0,1,2),(52,'','마찰력','','검전기 유도','','2022-11-17 06:05:58.019000',0,1,2),(53,'수축','열화','열 전도율','전하량','팽창','2022-11-17 07:40:39.706000',0,2,2),(54,'','','','','','2022-11-17 12:10:48.707000',0,2,2),(55,'','','','','','2022-11-17 12:11:51.200000',0,2,2),(56,'마찰력','+','정전기 유도','실크','-','2022-11-17 12:31:32.105000',0,1,1),(57,'','','','','','2022-11-17 12:52:25.589000',0,1,2),(58,'','','','','','2022-11-17 13:03:43.609000',0,1,2),(59,'','','','','','2022-11-17 13:11:57.258000',0,8,2),(60,'수소','','','','','2022-11-17 13:27:32.302000',0,8,2),(61,'','','','','','2022-11-17 13:31:31.053000',0,8,2),(62,'','','가장자리','','','2022-11-17 13:35:51.560000',0,8,2),(63,'','','','','','2022-11-17 13:46:42.600000',0,8,2),(64,'','','','','','2022-11-17 13:54:02.963000',0,8,2),(65,'','팽창','','','','2022-11-17 13:56:17.746000',0,2,2),(66,'','','','','','2022-11-17 14:09:11.632000',0,2,2),(67,'','','','','','2022-11-17 14:14:46.682000',0,2,2),(68,'','','','','','2022-11-17 14:16:34.359000',0,2,2),(69,'','','','','','2022-11-17 14:19:08.861000',0,2,2),(70,'','','','','','2022-11-17 14:31:17.248000',0,2,2),(71,'','','','','','2022-11-17 15:08:15.873000',0,2,2),(72,'','','','','','2022-11-17 17:16:41.841000',0,2,2),(73,'','','','','','2022-11-17 17:20:37.409000',0,2,2),(74,'','','','','','2022-11-17 17:23:58.242000',0,2,2),(75,'','','','','','2022-11-17 17:26:12.349000',0,2,2),(76,'','','','','','2022-11-17 17:26:51.972000',0,2,2),(77,'','','','','','2022-11-17 17:30:15.454000',0,2,2),(78,'','','','','팽창','2022-11-17 17:31:18.065000',0,2,2),(79,'','','','','','2022-11-17 17:38:33.292000',0,2,2),(80,'','','','','','2022-11-17 17:40:12.231000',0,2,2),(81,'','','','','','2022-11-17 17:54:33.956000',0,2,2),(82,'','','','','','2022-11-17 17:58:47.388000',0,2,2),(83,'-','정전기 유도','절연체','털 뭉치','+','2022-11-17 18:30:52.679000',100,1,2),(84,'열화','열 팽창률','철','구리','수축','2022-11-17 18:36:18.804000',80,2,2),(85,'염화 나트륨','질산 구리','보라색','빨간색','황록색','2022-11-17 18:40:39.253000',100,3,2),(86,'','','','','','2022-11-17 18:43:50.478000',0,4,2),(87,'','','마찰력','','','2022-11-17 20:08:48.632000',0,1,2),(88,'','','','검전기 유도','','2022-11-17 20:11:02.595000',0,1,2),(89,'','','','증발','','2022-11-17 20:14:25.027000',0,2,2),(90,'','','','','구리','2022-11-17 20:33:56.651000',0,2,2),(91,'','','','털 뭉치','','2022-11-17 20:48:46.508000',20,1,2),(92,'','','','전하량','','2022-11-17 20:50:02.814000',0,2,2),(93,'','','','흰색','','2022-11-17 20:51:16.072000',0,3,2),(94,'','노랑','','','','2022-11-17 20:52:20.241000',0,4,2),(95,'','','서','','','2022-11-17 20:53:33.461000',0,6,2),(96,'','','0.2','','','2022-11-17 20:54:40.511000',0,8,2),(97,'','','','나트륨','','2022-11-17 20:57:23.974000',0,10,2),(98,'크로마토그래피','','','','','2022-11-17 21:12:58.729000',0,10,2),(99,'','','','','','2022-11-17 21:15:47.231000',0,10,2),(100,'','','','','','2022-11-17 21:18:11.790000',0,1,2),(101,'','','','','','2022-11-17 21:18:50.740000',0,2,2),(102,'','','','','','2022-11-17 21:19:36.794000',0,3,2),(103,'','','','','','2022-11-17 21:20:30.395000',0,4,2),(104,'','','','','','2022-11-17 21:21:09.293000',0,6,2),(105,'','','','','','2022-11-17 21:21:56.319000',0,8,2),(106,'','','','','','2022-11-17 21:22:33.101000',0,10,2),(107,'','','','','','2022-11-17 21:24:24.860000',0,10,2),(108,'','','','','','2022-11-18 05:21:27.273000',0,2,1),(109,'긴','넘치지 않도록','염화 나트륨','나프탈렌','거름','2022-11-18 05:27:38.684000',100,10,1),(110,'염화 나트륨','질산 구리','빨간색','황록색','검정색','2022-11-18 05:31:53.370000',40,3,1),(111,'','','','','','2022-11-18 05:42:07.697000',0,1,2),(112,'팽창','열 팽창률','구리','철','수축','2022-11-18 05:44:11.395000',60,2,1),(113,'-','대전','마찰력','검전기 유도','절연체','2022-11-18 05:44:33.244000',20,1,2),(114,'팽창','열 팽창률','바이메탈','열 전도율','수축','2022-11-18 05:52:55.984000',60,2,2),(115,'염화 나트륨','질산 구리','보라색','빨간색','황록색','2022-11-18 05:53:50.069000',100,3,1),(116,'','','','','','2022-11-18 05:56:39.749000',0,1,2),(117,'크로마토그래피','용해도','용매도','노랑','보라','2022-11-18 06:08:30.968000',40,4,1),(118,'','','','','','2022-11-18 06:10:29.155000',0,1,2),(119,'서','동','N','S','반대되는','2022-11-18 06:14:47.201000',40,6,1),(120,'','','','','','2022-11-18 17:18:21.236000',0,1,2),(121,'털 뭉치','+','마찰력','검전기 유도','집전체','2022-11-18 17:31:29.063000',0,1,2),(122,'','','정전기 유도','','','2022-11-18 17:43:12.374000',0,1,2),(123,'','','','','','2022-11-18 17:59:05.785000',0,1,2),(124,'검전기 유도','마찰력','','','','2022-11-18 18:15:00.648000',0,1,2),(125,'','','','','','2022-11-19 04:49:55.618000',0,1,2),(126,'','','','','','2022-11-19 10:36:29.869000',0,1,2),(127,'','','','','','2022-11-19 12:30:43.383000',0,1,2),(128,'','','','','','2022-11-19 13:10:41.894000',0,4,5),(129,'','','','','','2022-11-19 13:27:12.661000',0,4,5),(130,'','','','','','2022-11-19 13:30:16.209000',0,4,5),(131,'','','','','','2022-11-19 13:31:44.770000',0,4,5),(132,'','','','','','2022-11-19 13:52:34.150000',0,4,5),(133,'','','','','','2022-11-19 13:53:59.617000',0,4,5),(134,'','','','','','2022-11-19 13:57:39.732000',0,4,5),(135,'','','','','','2022-11-19 13:59:12.862000',0,4,5),(136,'-','정전기 유도','털 뭉치','검전기 유도','+','2022-11-19 15:08:24.771000',60,1,1),(137,'','','','','','2022-11-19 15:14:59.128000',0,4,1),(138,'','','','','','2022-11-19 15:19:57.190000',0,4,1),(139,'','','','','','2022-11-20 01:15:43.257000',0,4,1),(140,'','','','','','2022-11-20 01:33:56.989000',0,1,2),(141,'','','','','','2022-11-20 01:48:40.235000',0,1,2),(142,'','','','','','2022-11-20 01:48:40.280000',0,1,2),(143,'','','','','','2022-11-20 01:50:06.490000',0,2,2),(144,'','','','','','2022-11-20 02:20:09.562000',0,4,1),(145,'용해도','크로마토그래피','성분 물질','노랑','보라','2022-11-20 02:29:14.404000',100,4,1),(146,'북','남','N','S','동일한','2022-11-20 02:31:37.522000',100,6,1),(147,'팽창','열 팽창률','구리','철','수축','2022-11-20 02:34:20.058000',60,2,1),(148,'','','','','','2022-11-20 03:48:40.183000',0,2,2),(149,'','','','','','2022-11-20 15:46:30.553000',0,3,1),(150,'','','','','','2022-11-20 15:47:07.179000',0,1,2),(151,'','열 팽창률','','','','2022-11-20 15:49:30.262000',20,2,2),(152,'','','','','','2022-11-20 16:45:31.434000',0,3,1),(153,'','','','','','2022-11-20 16:47:21.041000',0,3,1),(154,'팽창','열 전도율','구리','철','수축','2022-11-20 17:20:03.137000',40,2,3),(155,'팽창','열 팽창률','철','구리','증발','2022-11-20 21:50:11.249000',80,2,3),(156,'팽창','열 팽창률','철','구리','증발','2022-11-20 22:16:44.110000',80,2,3),(157,'팽창','열 팽창률','','','','2022-11-20 22:41:09.666000',40,2,3),(158,'팽창','열 팽창률','','','','2022-11-20 22:45:50.986000',40,2,3),(159,'팽창','열 팽창률','','','','2022-11-20 23:41:18.684000',40,2,2),(160,'팽창','열 팽창률','철','','','2022-11-21 01:05:26.910000',60,2,3),(161,'열 팽창률','','','','','2022-11-21 06:53:06.072000',0,2,2),(162,'','일정 성분비','','','','2022-11-21 06:57:57.763000',0,8,2),(163,'','바이메탈','','','','2022-11-21 06:59:39.716000',0,2,2),(164,'','','','팽창','','2022-11-21 07:33:21.563000',0,2,2),(165,'','','','증발','','2022-11-21 07:51:26.969000',0,2,6);
/*!40000 ALTER TABLE `reports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_idx` bigint NOT NULL AUTO_INCREMENT,
  `user_gender` varchar(255) DEFAULT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `user_pwd` varchar(255) DEFAULT NULL,
  `user_tutorial` bit(1) DEFAULT NULL,
  `ref_idx` bigint DEFAULT NULL,
  PRIMARY KEY (`user_idx`),
  KEY `FKkc8612kp90ejhxiptgma7q9aa` (`ref_idx`),
  CONSTRAINT `FKkc8612kp90ejhxiptgma7q9aa` FOREIGN KEY (`ref_idx`) REFERENCES `refresh` (`ref_idx`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'MAN','hsmk0076','$2a$10$5QL5Rdp8032x1oHKsANlJ.4Q5AoTVsxHrnQJlfBeCKpXQtBBBgsai',_binary '\0',44),(2,'MAN','호','$2a$10$4BRczGX29Xza5zUe6my65em8Djgohaa2e7DpdUm1m9WvTqzneu8v.',_binary '\0',49),(3,'MAN','이정재','$2a$10$O8lJxVxaNXNSY23ozyFuT.5I1gRmqBCm6JrHd8/K/Z2deOyJX0LEO',_binary '\0',51),(4,'MAN','하이','$2a$10$y2oKCPLpJgmnlqS9DWtWL.VgmYbMyFITwF6tnRHioOnnR4LG6TaGu',_binary '\0',8),(5,'WOMAN','heewon','$2a$10$LdiLWpbaiTixJZ6DAKvbHOp6/gtd6Qf7mnHBF1.YQJ4n55pB8VTAy',_binary '\0',31),(6,'MAN','하','$2a$10$VLIi9/Lk52IAy6jUg.bFZuOaMVJ97SXU1Feuv8jDiFNQOPxtVjpn6',_binary '\0',50);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users_roles`
--

DROP TABLE IF EXISTS `Users_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users_roles` (
  `Users_user_idx` bigint NOT NULL,
  `roles` varchar(255) DEFAULT NULL,
  KEY `FKpd7hr5f8nji5jniwn90k22crq` (`Users_user_idx`),
  CONSTRAINT `FKpd7hr5f8nji5jniwn90k22crq` FOREIGN KEY (`Users_user_idx`) REFERENCES `users` (`user_idx`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users_roles`
--

LOCK TABLES `Users_roles` WRITE;
/*!40000 ALTER TABLE `Users_roles` DISABLE KEYS */;
INSERT INTO `Users_roles` VALUES (1,'ROLE_USER'),(2,'ROLE_USER'),(3,'ROLE_USER'),(4,'ROLE_USER'),(5,'ROLE_USER'),(6,'ROLE_USER');
/*!40000 ALTER TABLE `Users_roles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-21  8:57:23
