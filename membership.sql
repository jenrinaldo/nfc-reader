-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 26, 2019 at 04:41 AM
-- Server version: 10.3.16-MariaDB
-- PHP Version: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `membership`
--

-- --------------------------------------------------------

--
-- Table structure for table `membership`
--

CREATE TABLE `membership` (
  `id` varchar(16) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `ttl` date NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `no_hp` varchar(13) NOT NULL,
  `jenis_id` varchar(30) NOT NULL,
  `jenis_kelamin` char(1) NOT NULL,
  `jenis_anggota` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `membership`
--

INSERT INTO `membership` (`id`, `nama`, `ttl`, `alamat`, `no_hp`, `jenis_id`, `jenis_kelamin`, `jenis_anggota`) VALUES
('165150300111021', 'ERRICSON BERNEDY SETIAWAN', '2019-06-02', 'Jl. Sawojajar', '089', 'KARTU MAHASISWA', 'L', 'MAHASISWA'),
('165150301111014', 'AHMAD FAJRI RAHMAN', '1998-06-01', 'Jl. Sebuku XII / 4', '08977907884', 'KARTU MAHASISWA', 'L', 'MAHASISWA'),
('165150301111033', 'JENRINALDO TAMPUBOLON', '1998-01-01', 'Kosan Pakdhe', '081', 'KARTU MAHASISWA', 'L', 'MAHASISWA');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `membership`
--
ALTER TABLE `membership`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
