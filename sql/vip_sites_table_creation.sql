-- phpMyAdmin SQL Dump
-- version 4.6.5.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 27, 2017 at 02:13 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `phishingFisher`
--

-- --------------------------------------------------------

--
-- Table structure for table `vip_sites`
--

CREATE TABLE `vip_sites` (
  `ID` int(11) NOT NULL COMMENT 'ID FROM ALL_SITES TABLE',
  `URL` text NOT NULL,
  `HTML_BODY` text NOT NULL COMMENT 'HTML CONTENT',
  `LAST_HTML_CHECK` date NOT NULL COMMENT 'LAST TIME HTML CONTENT WAS CHECKED',
  `SSL_KEY` text NOT NULL COMMENT 'Public SSL Key',
  `SSL_EXPIRATION_DATE` date NOT NULL COMMENT 'SSL expiration date'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Table with the sites to be checked against. Good sites.';

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
