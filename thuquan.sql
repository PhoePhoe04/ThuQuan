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


-- Dumping database structure for thuquan
DROP DATABASE IF EXISTS `thuquan`;
CREATE DATABASE IF NOT EXISTS `thuquan` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */;
USE `thuquan`;

-- Dumping structure for table thuquan.aspnetroleclaims
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetroleclaims: ~0 rows (approximately)

-- Dumping structure for table thuquan.aspnetroles
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetroles: ~0 rows (approximately)

-- Dumping structure for table thuquan.aspnetuserclaims
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetuserclaims: ~0 rows (approximately)

-- Dumping structure for table thuquan.aspnetuserlogins
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetuserlogins: ~0 rows (approximately)

-- Dumping structure for table thuquan.aspnetuserroles
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetuserroles: ~0 rows (approximately)

-- Dumping structure for table thuquan.aspnetusers
DROP TABLE IF EXISTS `aspnetusers`;
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
  `FullName` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetusers: ~0 rows (approximately)
INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `FullName`) VALUES
	('0770c540-7258-4d4c-a577-9452aec5bc29', 'usertest@gmail.com', 'USERTEST@GMAIL.COM', 'usertest@gmail.com', 'USERTEST@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEKbEkTdSiX9jsFRw3ei80PQsGjiNEfQN3JV7vkl3f09laeOHEQhhH/2tKEx5EEJM5A==', 'EYA6IPQFCHRAPKSSHKVNT6NUYVKBQ5JG', '91fd877b-0e30-4c26-8e76-0d94abe7f069', NULL, 0, 0, NULL, 1, 0, 'UserToTest'),
	('7131c5a9-8326-4da2-82e6-0f734f2fdd9c', 'phucduy@gmail.com', 'PHUCDUY@GMAIL.COM', 'phucduy@gmail.com', 'PHUCDUY@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEIX4vc9pPUizbta3jx4UGv/tENAwkxwvWVYG1Ee8SEhM0cXf3X5xq7LZwB8IfkDx8Q==', 'O6UVCGPI7MKAHODYUC4IVMCWT3AWFFMB', 'c08b4343-642d-4801-8a4d-106259156576', NULL, 0, 0, NULL, 1, 0, 'Phúc Duy Huỳnh');

-- Dumping structure for table thuquan.aspnetusertokens
DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.aspnetusertokens: ~0 rows (approximately)

-- Dumping structure for table thuquan.categories
DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.categories: ~0 rows (approximately)

-- Dumping structure for table thuquan.devices
DROP TABLE IF EXISTS `devices`;
CREATE TABLE IF NOT EXISTS `devices` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `ImageUrl` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `Status` longtext DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Devices_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_Devices_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.devices: ~0 rows (approximately)

-- Dumping structure for table thuquan.__efmigrationshistory
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Dumping data for table thuquan.__efmigrationshistory: ~0 rows (approximately)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250417175849_AddIdentitySupport', '9.0.0'),
	('20250418194159_UsersFullName', '9.0.0');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
