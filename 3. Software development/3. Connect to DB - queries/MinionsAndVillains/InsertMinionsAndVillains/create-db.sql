CREATE DATABASE MinionsDB;

USE MinionsDB;

CREATE TABLE Countries(
	Id VARCHAR(3) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE Towns(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL,
    CountryCode VARCHAR(3),
    CONSTRAINT FK_Towns_Countries
    FOREIGN KEY (CountryCode) REFERENCES Countries(Id)
);

CREATE TABLE Minions(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Name VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    TownId INT NOT NULL,
    CONSTRAINT FK_Minions_Towns
    FOREIGN KEY (TownId) REFERENCES Towns(Id)
);

CREATE TABLE EvilnessFactors(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Name VARCHAR(50) NOT NULL
);

CREATE TABLE Villains(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Name VARCHAR(50) NOT NULL,
    EvilnessFactorId INT NOT NULL,
    CONSTRAINT FK_Villains_EvilnessFactors
    FOREIGN KEY (EvilnessFactorId) REFERENCES EvilnessFactors(Id)
);

CREATE TABLE MinionsVillains(
	MinionId INT NOT NULL,
    VillainId INT NOT NULL,
    CONSTRAINT PK_MinionsVillains
    PRIMARY KEY (MinionId, VillainId),
    CONSTRAINT FK_MinionsVillains_Minions
    FOREIGN KEY (MinionId) REFERENCES Minions(Id),
    CONSTRAINT FK_MinionsVillains_Villains
    FOREIGN KEY (VillainId) REFERENCES Villains(Id)
);

INSERT INTO Countries
VALUES	('BG', 'Bulgaria'), 
		('USA', 'America'), 
		('GB', 'Great Britain');

INSERT INTO Towns(Name, CountryCode)
VALUES	('Sofia', 'BG'),
		('Varna', 'BG'),
        ('New York', 'USA');
        
INSERT INTO Minions(Name, Age, TownId)
VALUES	('Gru', 20, 1),
		('Viktor', 15, 1),
        ('Jilly', 17, 2),
        ('Mimi', 18, 2),
        ('Pepi', 17, 3),
        ('Zuzi', 16, 1);
        
INSERT INTO EvilnessFactors(Name)
VALUES ('Greedy'), ('Lying'), ('Abusive'), ('Evil');

INSERT INTO Villains(Name, EvilnessFactorId)
VALUES	('Vilain1', 1), 
		('Vilain2', 2), 
        ('Vilain3', 3);
    
INSERT INTO MinionsVillains
VALUES	(1, 1),
		(2, 1),
		(3, 1),
        (4, 1),
        (5, 1),
        (1, 2),
		(2, 2),
		(3, 2),
        (5, 3);