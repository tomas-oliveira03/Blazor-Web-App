USE MatchWornItems;


-- Insert additional data into Categoria table
INSERT INTO Categoria (Nome)
VALUES
	('Shirts'),
	('Utensils'),
	('Balls'),
	('Others');


INSERT INTO Utilizador (NIB, PrimeiroNome, UltimoNome, Email, NumeroTelemovel, PalavraPasse, Morada, Status)
VALUES 
    (584720193218, 'Francisco', 'Silva', 'francisco.silva@gmail.com', 912345678, 'franciscoSilva', 'Rua das Flores, 123',1),
    (109834562890, 'Gabriela', 'Pereira', 'gabriela.pereira@gmail.com', 922345678, '1234fdsa', 'Avenida dos Anjos, 456',1),
    (726541809372, 'Henrique', 'Ribeiro', 'henrique.ribeiro@gmail.com', 932456789, 'henriqRib', 'Travessa da Esperan a, 789',1),
    (890345617234, 'Ines', 'Santos', 'ines.santos@gmail.com', 913456789, 'SantosInes1234', 'Rua do Castelo, 101',1),
    (453287019476, 'Joao', 'Fernandes', 'joao.fernandes@gmail.com', 923567890, 'Palavra4324', 'Largo da Liberdade, 202',1),
    (657890341278, 'Katia', 'Martins', 'katia.martins@gmail.com', 933678901, 'SenhaSegura6', 'Pra a da Amizade, 303',1),
    (122455789012, 'Luis', 'Oliveira', 'luis.oliveira@gmail.com', 914567890, 'Umapalvrapasse', 'Avenida da Rep blica, 404',1),
    (876543210987, 'Miguel', 'Costa', 'miguel.costa@gmail.com', 924678901, 'jose1342', 'Rua do Com rcio, 505',1),
    (345678901234, 'Natalia', 'Pinto', 'natalia.pinto@gmail.com', 934789012, 'flores.casa', 'Travessa das Flores, 606',1),
    (987654321098, 'Olga', 'Mendes', 'olga.mendes@gmail.com', 915678901, 'olgaMenDes', 'Avenida dos Namorados, 707',1),
    (210967654321, 'Ricardo', 'Almeida', 'ricardo.almeida@gmail.com', 925789012, 'teixeiraMota', 'Rua da Esperan a, 808',1),
    (876543210947, 'Lara', 'Teixeira', 'lara.teixeira@gmail.com', 926890123, 'luz42', 'Avenida das Estrelas, 909',1),
    (543210987654, 'Manuel', 'Cardoso', 'manuel.cardoso@gmail.com', 936901234, 'outracessna', 'Travessa dos Amigos, 1010',1),
    (345678901334, 'Noria', 'Goncalves', 'nuria.goncalves@gmail.com', 917012345, 'quemele', 'Largo da Liberdade, 1111',1),
    (890123256789, 'Orlando', 'Mota', 'orlando.mota@gmail.com', 927123456, 'ocasoes', 'Pra a da Felicidade, 1212',1),
    (567890123451, 'Pedro', 'Rocha', 'pedro.rocha@gmail.com', 937234567, 'quemsoueu', 'Avenida dos Sonhos, 1313',1),
    (432109876543, 'Querubim', 'Ferreira', 'querubim.ferreira@gmail.com', 918345678, 'palavrapassesmuitoseguira', 'Rua das Maravilhas, 1414',1),
    (987012345678, 'Rafaela', 'Gouveia', 'rafaela.gouveia@gmail.com', 928456789, 'avenidaalegria', 'Avenida da Alegria, 1515',1),
    (654321098765, 'Sergio', 'Vieira', 'sergio.vieira@gmail.com', 938567890, 'poetasCamoes', 'Travessa dos Poetas, 1616',1),
    (321098765432, 'Tania', 'Baptista', 'tania.baptista@gmail.com', 919678901, 'liverada', 'Pra a da Liberdade, 1717',1),
    (890143456789, 'Vitor', 'Lopes', 'vitor.lopes@gmail.com', 929789012, 'artistasLopes', 'Rua dos Artistas, 1818',1),
    (567890123456, 'Walter', 'Zagalo', 'walter.zagalo@gmail.com', 939890123, 'WalterEle', 'Avenida das Mar s, 1919',1),
    (234567890123, 'Xania', 'Coelho', 'xenia.coelho@gmail.com', 910001122, 'Outrapasse', 'Travessa das Ondas, 2020',1),
    (789012545678, 'Yasmin', 'Wu', 'yasmin.wu@gmail.com', 920112233, 'SenhaSegura24', 'Rua do Sol, 2121',1),
    (456789012245, 'Zelio', 'Fonseca', 'zelio.fonseca@gmail.com', 930223344, 'NaoDescobremEsta', 'Largo dos Cisnes, 2222',1),
    (113456789012, 'Alice', 'Lima', 'alice.lima@gmail.com', 941334455, 'arvoresnaAvenida', 'Avenida das  rvores, 2323',1),
    (891122456789, 'Bernardo', 'Z ', 'bernardo.ze@gmail.com', 952445566, 'bernardoZEEEE', 'Travessa dos Rios, 2424',1),
    (567890133456, 'Clara', 'Xavier', 'clara.xavier@gmail.com', 963556677, 'clxabier', 'Pra a da Lua, 2525',1),
    (214567890123, 'Duarte', 'Vargas', 'duarte.vargas@gmail.com', 974667788, 'vargasdaniel', 'Rua do Mar, 2626',1),
    (789012245678, 'Eva', 'Teles', 'eva.teles@gmail.com', 985778899, 'evaTekte', 'Avenida das Estrelas, 2727',1);


		
INSERT INTO ArtigoLeilao (
    TamanhoArtigo, DataUsoArtigo, NomeEquipaEventoArtigo, NomeArtigo, DescricaoArtigo,
    NumeroAutenticacaoArtigo, EstadoArtigo, ImagemArtigo,
    NomeLeilao, TaxaMinimaIncrementoLeilao, DataFinalizacaoLeilao,
    PrecoCompraAutomaticoLeilao, PrecoBaseLeilao, IdCategoria, IdVendedor, EstadoLeilao
) VALUES
    ('M', '2022-12-15', 'AC Milan', 'Football Kit', 'Match-worn Balotelli shirt',
     648203, 'Usado', 'Auction1.jpg', 'Balotelli ACMilan', 3.00, '2024-01-31',
     400.00, 40.00, 1, '567890123451', 'A decorrer'),
    ('S', '2022-11-20', 'New England Patriots', 'Shirt', 'Brady-used shirt',
     783451, 'Excellent', 'Auction2.webp', 'Brady shirt from Patriots', 2.00, '2024-01-31',
     600.00, 30.00, 1, '234567890123', 'A decorrer'),
    ('L', '2023-02-28', 'Manchester United', 'Shirt', 'Captain Fernandes used shirt',
     564892, 'New', 'Auction3.webp', 'Bruno Fernandes used shirt from United', 1.50, '2024-01-31',
     330.00, 15.00, 1, '214567890123', 'A decorrer'),
    ('XL', '2023-01-10', 'PSG', 'Jersey', 'Icardi used shirt from PSG',
     109876, 'Good', 'Auction4.jpg', 'Mauro Icardi used shirt', 4.00, '2024-01-31',
     100.00, 20.00, 1, '987654321098', 'A decorrer'),
    ('M', '2023-03-05', 'SportingCP', 'Jersey', 'Vintage shirt from Cristiano Ronaldo',
     258731, 'Used', 'Auction5.webp', 'Vintage Ronaldo shirt from former club', 35.50, '2024-01-31',
     9000.00, 100.00, 1, '567890123456', 'A decorrer'),
    ('S', '2023-02-15', 'LA Lakers', 'Shirt', 'Vintage shirt',
     506371, 'Fair', 'Auction6.jpg', 'LA Lakers jersey from the GOAT', 25.00, '2024-01-31',
     7000.00, 300.00, 1, '567890123451', 'A decorrer'),
    ('L', '2023-04-20', 'NFL', 'Ball', 'Official game ball',
     372619, 'New', 'Auction7.jpg', 'Ball used in NFL', 1.75, '2024-01-30',
     40.00, 10.00, 3, '345678901234', 'A decorrer'),
    ('XL', '2023-05-25', 'Manchester United', 'Jersey', 'Pogba used jersey for Man United',
     918273, 'Excellent', 'Auction8.jpg', 'Paul Pogba black jersey used', 4.50, '2024-01-31',
     1100.00, 55.00, 1, '214567890123', 'A decorrer'),
    ('S', '2023-06-30', 'Nadal', 'Racket Nadal', 'Racket that was used by Nadal',
     574302, 'Like New', 'Auction9.webp', 'Nadal used racket', 45.00, '2024-01-31',
     9500.00, 47.50, 2, '345678901234', 'A decorrer'),
    ('L', '2023-08-05', 'AC Milan', 'Ronaldinho shirt', 'Game-used shirt',
     439812, 'Good', 'Auction10.jpg', 'Ronaldinho Milan jersey', 20.25, '2024-01-30',
     7500.00, 300.00, 1, '214567890123', 'A decorrer'),
    ('XL', '2023-09-10', 'Al Nassr', 'Ronaldo used match jersey', 'Match used jersey',
     284750, 'New', 'Auction11.jpg', 'CR7 Al Nassr jersey 2023', 20.00, '2024-01-30',
     5000.00, 25.00, 1, '890143456789', 'A decorrer'),
    ('S', '2023-10-15', 'RB Leipzig', 'Jersey Timo Werner', 'Match used jersey',
     725039, 'Excellent', 'Auction12.jpg', 'Timo Werner shirt Leipzig', 5.00, '2024-01-30',
     200.00, 10.00, 1, '890143456789', 'A decorrer'),
    ('M', '2023-11-20', 'LA Lakers', 'Lebron James shirt', 'Match-used shirt',
     890342, 'Used', 'Auction13.jpg', 'LJames used jersey LA', 4.25, '2024-01-30',
    10000.00, 60.00, 1, '567890123451', 'A decorrer'),
    ('S', '2023-11-21', 'Manchester City', 'Shirt', 'Autographed shirt',
    612094, 'Good', 'Auction14.webp', 'Manchester City Rodri shirt', 22.75, '2024-01-30',
    1000.00, 32.50, 1, '109834562890', 'A decorrer'),
    ('L', '2018-11-21', 'Arsenal', 'Cap', 'Players cap',
    497528, 'Used', 'Auction15.webp', 'Unai Emery used hat', 1.90, '2024-01-30',
    35.00, 17.50, 4, '109834562890', 'A decorrer'),
    ('M', '2020-11-21', 'Real Betis', 'Jersey', 'Team-signed jersey',
    345780, 'Excellent', 'Auction16.jpeg', 'Betis legend jersey', 4.75, '2024-01-30',
    1150.00, 57.50, 1, '987012345678', 'A decorrer'),
    ('XL', '2023-11-22', 'AS Roma', 'Football', 'Limited edition football',
    876512, 'Like New', 'Auction17.jpg', 'Roma showmatch ball', 3.25, '2024-01-30',
    85.00, 20.00, 3, '987012345678', 'A decorrer'),
    ('S', '2023-11-22', 'Napoli', 'Shirt', 'Game-worn shirt',
    239167, 'Fair', 'Auction18.webp', 'Napoli nice shirt', 2.00, '2024-01-30',
    550.00, 27.50, 1, '987012345678', 'A decorrer'),
    ('L', '2023-08-22', 'Sevilla', 'Cap', 'Vintage cap',
    951327, 'New', 'Auction19.webp', 'Sergio Ramos used hat', 2.15, '2024-01-30',
    45.00, 10.50, 4, '891122456789', 'A decorrer'),
    ('M', '2006-04-02', 'Valencia', 'Jersey', 'Player-autographed jersey',
    768093, 'Excellent', 'Auction20.webp', 'Aimar legendary shirt', 5.25, '2024-01-30',
    12500.00, 62.50, 1, '567890123451', 'A decorrer'),
    ('XL', '2023-11-24', 'Villarreal', 'Football', 'Replica football',
    185742, 'Good', 'Auction21.jpg', 'Villareal presentation ball', 3.50, '2024-01-13',
    95.00, 20.00, 3, '584720193218', 'Expirado'),
    ('S', '2023-11-25', 'Celta Vigo', 'Shirt', 'Team-logo shirt',
    630198, 'New', 'Auction22.jpg', 'Aspas used shirt', 2.25, '2024-01-14',
    700.00, 35.00, 1, '891122456789', 'Vendido'),
    ('L', '2023-11-26', 'Espanyol', 'Cap', 'Autographed team cap',
    572490, 'Excellent', 'Auction23.webp', 'Used hat by Braithwaite', 2.10, '2024-01-15',
    50.00, 25.00, 4, '584720193218', 'Vendido');






-- Insert additional data into Licitacao table
INSERT INTO Licitacao (ValorLicitacao, NIBComprador, IdLeilao, DataLicitacao)
VALUES 
	(400.00, 987654321098, 6, '2024-01-12 08:20:00'),
	(500.00, 584720193218, 6, '2024-01-12 20:42:32'),
	(65.00, 584720193218, 5, '2024-01-12 22:40:45'),
	(25.00, 987654321098, 3, '2024-01-13 08:40:45'),
	(45.00, 891122456789, 2, '2024-01-13 08:30:45'),
	(100.00, 987654321098, 3, '2024-01-13 08:40:45'),
	(70.00, 584720193218, 1, '2024-01-13 09:00:45'),
	(350.00, 891122456789, 22, '2024-01-14 12:40:45'),
	(500.00, 891122456789, 22, '2024-01-14 12:45:40'),
	(50.00, 891122456789, 23, '2024-01-14 12:55:45');
  

  -- Insert additional data into Licitacao table
INSERT INTO NumeroAutenticacaoValido (NumeroAutenticacaoValido)
VALUES 
	(783451),
	(564892),
	(109876),
	(258731),
	(648203),
	(920384),
	(372619),
	(506371),
	(137485),
	(894205),
	(653918),
	(432198),
	(745209),
	(160594),
	(918273),
	(574302),
	(439812),
	(284750),
	(725039),
	(503198),
	(890342),
	(612094),
	(497528),
	(345780),
	(876512),
	(239167),
	(951327),
	(768093),
	(185742),
	(630198),
	(572490),


	(906874),
	(341257),
	(489205),
	(294058),
	(716382),
	(830149),
	(687345),
	(124398),
	(501238),
	(967120),
	(238495),
	(814096),
	(756902),
	(682573),
	(395678),
	(274501),
	(830149),
	(461593),
	(507836);
  
  
  