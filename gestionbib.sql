-- phpMyAdmin SQL Dump
-- version 6.0.0-dev+20230212.f19d22c671
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mar. 07 mars 2023 à 20:18
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.1.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestionbib`
--

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `prenom` varchar(250) NOT NULL,
  `nom` varchar(250) NOT NULL,
  `cin` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`id`, `prenom`, `nom`, `cin`) VALUES
(1, 'Aymane', 'guacamole', '3344333'),
(2, 'AEAE', 'AEAE', 'AEAEA'),
(3, 'Zineb', 'Naciri', 'EE1234'),
(4, 'AFFFFFFFF', 'AAAAAAAAA', 'EE3344334'),
(5, 'Amine', 'Gammoun', 'EE3455'),
(6, 'Taha', 'Elassri', 'EE4444'),
(7, 'YASSMINE', 'NACIRI', 'EE44466'),
(9, 'YASSMINE', 'NACIRI', 'EEE76754545');

-- --------------------------------------------------------

--
-- Structure de la table `emprunt`
--

CREATE TABLE `emprunt` (
  `id` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_ouvrage` int(11) NOT NULL,
  `date_demprunt` varchar(250) NOT NULL,
  `date_retour` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `emprunt`
--

INSERT INTO `emprunt` (`id`, `id_client`, `id_ouvrage`, `date_demprunt`, `date_retour`) VALUES
(0, 4, 1235, '02/11/2022 16:53:45', '18/11/2022 16:53:45'),
(3, 10, 1235, '18/11/2022 21:43:13', '04/12/2022 21:43:13'),
(4, 8, 111, '18/11/2022 22:00:54', '26/11/2022 22:00:54'),
(5, 4, 1456, '11/11/2022 22:39:10', '27/11/2022 22:39:10'),
(55, 4, 1456, '17/11/2022 22:49:59', '20/11/2022 22:49:59'),
(66, 2, 118, '22/11/2022 22:50:35', '22/11/2022 22:50:35'),
(77, 4, 1456, '10/11/2022 23:33:19', '27/11/2022 23:33:19');

-- --------------------------------------------------------

--
-- Structure de la table `ouvrage`
--

CREATE TABLE `ouvrage` (
  `code` int(11) NOT NULL,
  `titre` varchar(250) NOT NULL,
  `auteur` varchar(250) NOT NULL,
  `editeur` varchar(250) NOT NULL,
  `periodicite` varchar(250) NOT NULL,
  `type` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `ouvrage`
--

INSERT INTO `ouvrage` (`code`, `titre`, `auteur`, `editeur`, `periodicite`, `type`) VALUES
(111, 'NewYork Magazine', '', '', 'chaque semaine', 'PERIODIQUE'),
(118, 'TEST', '', '', 'TES', 'PERIODIQUE'),
(1234, 'Les miserables', 'Victor Hugo', '', '', 'LIVRE'),
(1235, '11 minutes', 'Paulo Cohelo', 'AMINE', '', 'LIVRE'),
(1456, 'Chansons', 'spacetoon', '', '', 'CD');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `user` varchar(250) NOT NULL,
  `password` varchar(250) NOT NULL,
  `prenom` varchar(250) NOT NULL,
  `nom` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`user`, `password`, `prenom`, `nom`) VALUES
('admin', 'admin', 'zineb', 'naciri'),
('admin', 'admin', 'amine', 'gammoun');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `cin` (`cin`);

--
-- Index pour la table `emprunt`
--
ALTER TABLE `emprunt`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_client` (`id_client`),
  ADD KEY `id_ouvrage` (`id_ouvrage`);

--
-- Index pour la table `ouvrage`
--
ALTER TABLE `ouvrage`
  ADD PRIMARY KEY (`code`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `emprunt`
--
ALTER TABLE `emprunt`
  ADD CONSTRAINT `id_ouvrage` FOREIGN KEY (`id_ouvrage`) REFERENCES `ouvrage` (`code`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
