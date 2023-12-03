CREATE DATABASE Relations;

USE Relations;

-- Problem 1: one-to-one
CREATE TABLE Passports(
	passport_id INT AUTO_INCREMENT PRIMARY KEY,
    passport_number CHAR(8) NOT NULL
);

CREATE TABLE People(
	person_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(30) NOT NULL,
    salary DECIMAL NOT NULL,
    passport_id INT NOT NULL UNIQUE,
    CONSTRAINT fk_people_passports
    FOREIGN KEY (passport_id) REFERENCES passports(passport_id)
);

INSERT INTO Passports
VALUES	(101, 'N34FG21B'),
		(102, 'K65LO4R7'),
        (103, 'ZE657QP2');
        
INSERT INTO People(first_name, salary, passport_id)
VALUES	('Roberto', 43300, 102),
		('Tom', 56100, 103),
        ('Yana', 60200, 101);
      
SELECT * FROM Passports;
SELECT * FROM People;

-- Problem 2: one-to-many
CREATE TABLE manufacturers(
	manufacturer_id INT AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(20) NOT NULL,
	established_on DATE NOT NULL
);

CREATE TABLE models(
	model_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    manufacturer_id INT NOT NULL,
    CONSTRAINT fk_models_manufacturers
    FOREIGN KEY (manufacturer_id) REFERENCES manufacturers(manufacturer_id)
);

INSERT INTO manufacturers(name, established_on)
VALUES	('BMW', '1916-03-01'),
		('Tesla', '2003-01-01'),
        ('Lada', '1966-05-01');
        
INSERT INTO models
VALUES	(101, 'X1', 1),
		(102, 'i6', 1),
		(103, 'Model S', 2),
		(104, 'Model X', 2),
		(105, 'Model 3', 2),
		(106, 'Nova', 3);
        
SELECT * FROM manufacturers;
SELECT * FROM models;

-- Problem 3: many-to-many
CREATE TABLE students(
	student_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL
);

CREATE TABLE exams(
	exam_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL
);

CREATE TABLE students_exams(
	student_id INT NOT NULL,
    exam_id INT NOT NULL,
    CONSTRAINT pk_students_exams
    PRIMARY KEY (student_id, exam_id),
    CONSTRAINT fk_students_exams_students
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    CONSTRAINT fk_students_exams_exams
    FOREIGN KEY (exam_id) REFERENCES exams(exam_id)
);

INSERT INTO students(name)
VALUES	('Mila'),
		('Tony'),
		('Ron');
        
INSERT INTO exams
VALUES	(101, 'Spring MVC'),
		(102, 'Neo4j'),
        (103, 'Oracle 11g');
        
INSERT INTO students_exams
VALUES	(1, 101),
		(1, 102),
        (2, 101),
        (3, 103),
        (2, 102),
        (2, 103);

-- Problem 4: self-reference
CREATE TABLE teachers(
	teacher_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    manager_id INT,
    CONSTRAINT fk_teacers_teachers
    FOREIGN KEY (manager_id) REFERENCES teachers(teacher_id)
);

INSERT INTO teachers
VALUES	(101, 'John', NULL),
        (105, 'Mark', 101),
        (106, 'Greta', 101),
		(102, 'Maya', 106),
        (103, 'Silvia', 106),
        (104, 'Ted', 105);
        
SELECT * FROM teachers;