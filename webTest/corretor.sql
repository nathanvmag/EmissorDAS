-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 06-Maio-2018 às 06:33
-- Versão do servidor: 10.1.30-MariaDB
-- PHP Version: 5.6.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `corretor`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `emissoes`
--

CREATE TABLE `emissoes` (
  `id` int(11) NOT NULL,
  `cnpj` varchar(255) NOT NULL,
  `mes` varchar(255) NOT NULL,
  `pserv` varchar(255) NOT NULL,
  `rprod` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `boleto` longtext,
  `pago` varchar(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `emissoes`
--

INSERT INTO `emissoes` (`id`, `cnpj`, `mes`, `pserv`, `rprod`, `status`, `boleto`, `pago`) VALUES
(54, '27124625000111', '4', '00', '00', 'Pago', '/Site/das/27124625000111/04/boleto.pdf', '1');

-- --------------------------------------------------------

--
-- Estrutura da tabela `regusuarios`
--

CREATE TABLE `regusuarios` (
  `id` int(255) NOT NULL,
  `cnpj` varchar(255) NOT NULL,
  `infemp` longtext NOT NULL,
  `nome` varchar(255) NOT NULL,
  `cpf` varchar(255) NOT NULL,
  `eletit` varchar(255) NOT NULL,
  `cep` varchar(255) NOT NULL,
  `end` varchar(255) NOT NULL,
  `bairro` varchar(255) NOT NULL,
  `cid` varchar(255) NOT NULL,
  `cap` varchar(255) NOT NULL,
  `tel` varchar(255) NOT NULL,
  `cel` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `reg` varchar(8) NOT NULL,
  `tabs` varchar(255) NOT NULL,
  `ready` varchar(8) NOT NULL,
  `pass` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `regusuarios`
--

INSERT INTO `regusuarios` (`id`, `cnpj`, `infemp`, `nome`, `cpf`, `eletit`, `cep`, `end`, `bairro`, `cid`, `cap`, `tel`, `cel`, `email`, `reg`, `tabs`, `ready`, `pass`) VALUES
(25, '20410183000120', 'MATRIZ¬09/06/2014¬RK DISTRIBUICAO & PROMOCAO DE EVENTOS EIRELI - ME¬RK DISTRIBUICAO & PROMOCAO¬230-5 - Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)¬R EVARISTO PEREIRA ESCORSA¬60¬---¬03.475-070¬VILA ANTONIETA¬SAO PAULO¬SP¬rsaconsutoria@hotmail.com¬(11) 5165-3937¬---¬ATIVA¬09/06/2014¬---¬---¬---¬73.19-0-02 - Promoção de vendas¬00.00-0-00 - Não informada\n', 'RK', '101010203', '300303003', '383883833', '---', '---', '---', '---', '---', '---', '32323', '1', '13,', '1', '1234'),
(26, '27124625000111', 'MATRIZ¬16/02/2017¬ALMEIDA - NEGOCIOS, EMPRESAS & SOLUCOES FISCAIS E TRIBUTARIAS EIRELI¬NEGOCIOS, EMPRESAS & SOLUCOES¬230-5 - Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)¬AL SANTOS¬200¬---¬01.418-000¬CERQUEIRA CESAR¬SAO PAULO¬SP¬contato@nesconsultoria.com.br¬(11) 2059-2875¬---¬ATIVA¬16/02/2017¬---¬---¬---¬82.11-3-00 - Serviços combinados de escritório e apoio administrativo¬63.11-9-00 - Tratamento de dados, provedores de serviços de aplicação e serviços de hospedagem na internet\n69.20-6-02 - Atividades de consultoria e auditoria contábil e tributária\n', 'Almeida', '39300021039', '3992390139', '249499990', 'Rua das flores', 'recreio', 'migel', 'todas', '2498139492839', '249183923898', 'nathanzin@gmail.com', '1', '0,23,', '1', '12345');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `emissoes`
--
ALTER TABLE `emissoes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `regusuarios`
--
ALTER TABLE `regusuarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `emissoes`
--
ALTER TABLE `emissoes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT for table `regusuarios`
--
ALTER TABLE `regusuarios`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
