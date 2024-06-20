-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 20 Jun 2024 pada 13.17
-- Versi server: 10.4.20-MariaDB
-- Versi PHP: 7.4.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `traveldb`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `mobil`
--

CREATE TABLE `mobil` (
  `Id` int(11) NOT NULL,
  `jenis_mobil` varchar(50) NOT NULL,
  `supir` varchar(50) NOT NULL,
  `jumlah_kursi` int(11) NOT NULL,
  `rute` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `mobil`
--

INSERT INTO `mobil` (`Id`, `jenis_mobil`, `supir`, `jumlah_kursi`, `rute`, `status`) VALUES
(1, 'Avanza', 'Ibnu', 7, 'Jambi-Kerinci', 'Penuh'),
(2, 'Hiace', 'Dadang', 10, 'Bangko-Jambi', '5/10'),
(5, 'Terios', 'Alex', 7, 'Tungkal-Kerinci', '6/7'),
(6, 'Hiace', 'Amrullah', 10, 'Jambi-Bangko', 'Penuh'),
(7, 'Hiace', 'Farhan', 10, 'Jambi-Bangko', '9/10');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pesanan`
--

CREATE TABLE `pesanan` (
  `Id` int(11) NOT NULL,
  `Nama` varchar(50) NOT NULL,
  `Penjemputan` varchar(50) NOT NULL,
  `Tujuan` varchar(50) NOT NULL,
  `Harga` decimal(18,2) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `Mobil` varchar(50) NOT NULL,
  `Telepon` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `pesanan`
--

INSERT INTO `pesanan` (`Id`, `Nama`, `Penjemputan`, `Tujuan`, `Harga`, `Status`, `Mobil`, `Telepon`) VALUES
(1, 'Fitri', 'Mayang, JBI', 'Kerinci', '200000.00', 'Belum Lunas', 'Avanza', '081234567890'),
(2, 'Farhan', 'Sungai Duren, Muaro Jambi', 'Kerinci', '200000.00', 'Belum Lunas', 'Innova', '085678901234'),
(9, 'Putra', 'Bagan Pete, JBI', 'Muaro Tebo', '160000.00', 'Sudah Lunas', 'Xenia', '081122334455');

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`) VALUES
(1, 'adminsawa', '123456');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `mobil`
--
ALTER TABLE `mobil`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks untuk tabel `pesanan`
--
ALTER TABLE `pesanan`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `mobil`
--
ALTER TABLE `mobil`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT untuk tabel `pesanan`
--
ALTER TABLE `pesanan`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
