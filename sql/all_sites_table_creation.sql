-- phpMyAdmin SQL Dump
-- version 4.6.5.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 27, 2017 at 12:16 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `phishingfisher`
--

-- --------------------------------------------------------

--
-- Table structure for table `all_sites`
--

CREATE TABLE `all_sites` (
  `ID` bigint(20) UNSIGNED NOT NULL COMMENT 'ID',
  `URL` text NOT NULL COMMENT 'url',
  `DANGER` int(11) NOT NULL COMMENT 'danger (1 = yes, 2 = no, 3 = new)',
  `CLONED` int(11) NOT NULL COMMENT 'ID web that this ones is supposed to be a clone of',
  `VOTES` int(11) NOT NULL COMMENT 'people who actually swa this as a danger'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='This table will collect all the data of the suspicious webs';

--
-- Indexes for dumped tables
--

--
-- Indexes for table `all_sites`
--
ALTER TABLE `all_sites`
  ADD UNIQUE KEY `ID` (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `all_sites`
--
ALTER TABLE `all_sites`
  MODIFY `ID` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'ID';
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
