-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               11.7.2-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for thuquan3
CREATE DATABASE IF NOT EXISTS `thuquan3` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */;
USE `thuquan3`;

-- Dumping structure for table thuquan3.aspnetroles
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan3.aspnetroles: ~0 rows (approximately)

-- Dumping structure for table thuquan3.aspnetusers
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan3.aspnetusers: ~0 rows (approximately)

-- Dumping structure for table thuquan3.categories
CREATE TABLE IF NOT EXISTS `categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan3.categories: ~4 rows (approximately)
INSERT INTO `categories` (`Id`, `Name`) VALUES
	(1, 'Điện thoại'),
	(2, 'Máy ảnh'),
	(3, 'Máy in'),
	(4, 'Laptop');

-- Dumping structure for table thuquan3.devices
CREATE TABLE IF NOT EXISTS `devices` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Description` longtext DEFAULT NULL,
  `Status` longtext DEFAULT NULL,
  `CategoryId` int(11) NOT NULL DEFAULT 0,
  `ImageUrl` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Devices_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_Devices_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan3.devices: ~4 rows (approximately)
INSERT INTO `devices` (`Id`, `Name`, `Description`, `Status`, `CategoryId`, `ImageUrl`) VALUES
	(1, 'Iphone 14', 'Điện thoại của tôi', 'Đang cho mượn', 1, 'https://cdn.phuckhangmobile.com/image/iphone-14-plus-128gb-xanh-quocte-phuckhangmobile-26961j.jpg?_gl=1*2zwwpe*_gcl_au*MTIwNjkzNjI0LjE3NDQ3OTA4Mjk.'),
	(4, 'Máy in vippro', 'Sản phẩm độc quyền', NULL, 3, 'https://shopmayvanphong.vn/wp-content/uploads/2021/02/canon-6030w.jpg'),
	(5, 'Máy tin thường dân', 'Dành cho người thường sử dụng', NULL, 3, 'https://shopmayvanphong.vn/wp-content/uploads/2021/02/canon-6030w.jpg'),
	(6, 'Máy ảnh chụp xuyên thấu', 'Hổ trợ chụp của X-Quang', NULL, 2, 'https://i1.adis.ws/i/canon/eos-r5_front_rf24-105mmf4lisusm_square_32c26ad194234d42b3cd9e582a21c99b?$prod-gallery-1by1-jpg$');

-- Dumping structure for table thuquan3.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Email` longtext NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Role` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan3.users: ~3 rows (approximately)
INSERT INTO `users` (`Id`, `Username`, `Email`, `Password`, `Role`) VALUES
	(1, 'admin', 'admin@gmail.com', 'admin', 'ADMIN'),
	(2, 'user1', 'user1@gmail.com', 'user1', NULL),
	(3, 'user2', 'user2@gmail.com', '123456', NULL);

-- Dumping structure for table thuquan3.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan3.__efmigrationshistory: ~4 rows (approximately)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250415163453_InitialCreate', '9.0.0'),
	('20250415164639_AddCategoryAndRelation', '9.0.0'),
	('20250416080616_AddDeviceImageUrl', '9.0.0'),
	('20250416090550_AddUserModel', '9.0.0');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
