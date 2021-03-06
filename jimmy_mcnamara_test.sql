-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 05, 2018 at 12:05 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: jimmy_mcnamara_test
--
CREATE DATABASE IF NOT EXISTS jimmy_mcnamara_test DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE jimmy_mcnamara_test;

-- --------------------------------------------------------

--
-- Table structure for table clients
--

CREATE TABLE clients (
  id int(11) NOT NULL,
  name varchar(60) NOT NULL,
  phone_number varchar(12) NOT NULL,
  stylist_id int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table stylists
--

CREATE TABLE stylists (
  id int(11) NOT NULL,
  stylist_name varchar(50) NOT NULL,
  days_available varchar(60) NOT NULL,
  years_active int(2) NOT NULL,
  phone_number varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table clients
--
ALTER TABLE clients
  ADD PRIMARY KEY (id);

--
-- Indexes for table stylists
--
ALTER TABLE stylists
  ADD PRIMARY KEY (id);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table clients
--
ALTER TABLE clients
  MODIFY id int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table stylists
--
ALTER TABLE stylists
  MODIFY id int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
