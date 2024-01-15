USE company;

DELIMITER &&

-- Problem 1
CREATE PROCEDURE usp_get_employees_salary_above_35000()
BEGIN    
	SELECT first_name, last_name FROM employees
    WHERE salary > 35000
    ORDER BY first_name, last_name;
END&&

CALL usp_get_employees_salary_above_35000()&&

-- Problem 2
CREATE PROCEDURE usp_get_employees_salary_above(min_salary DECIMAL)
BEGIN
	SELECT first_name, last_name FROM employees
    WHERE salary > min_salary
    ORDER BY first_name, last_name;
END&&

CALL usp_get_employees_salary_above(10000)&&

-- Problem 3
CREATE PROCEDURE usp_get_towns_starting_with(town_starts_with VARCHAR(50))
BEGIN
	SELECT name AS town_name FROM towns
    WHERE name LIKE CONCAT(town_starts_with, '%');
END&&

CALL usp_get_towns_starting_with('ca')&&

-- Problem 4
CREATE PROCEDURE usp_get_employees_from_town(town_name VARCHAR(50))
BEGIN
	SELECT first_name, last_name FROM employees AS e
	JOIN addresses AS a
	ON a.address_id = e.address_id
	JOIN towns AS t
	ON t.town_id = a.town_id
	WHERE t.name = 'Everett'
	ORDER BY first_name, last_name;
END&&

CALL usp_get_employees_from_town('Everett')&&

-- Problem 5
 CREATE FUNCTION ufn_get_salary_level(salary DECIMAL)
 RETURNS VARCHAR(7)
 BEGIN
	IF (salary < 30000) THEN
		RETURN 'Low';
	END IF;
    
    IF (salary < 50000) THEN
		RETURN 'Average';
	END IF;
    
	RETURN 'High';
 END&&
 
 SELECT ufn_get_salary_level(40000)&&
 
 -- Problem 6 
 CREATE FUNCTION ufn_is_word_comprised(
	set_of_letters VARCHAR(50), 
    word VARCHAR(50))
RETURNS BOOL
BEGIN
	DECLARE regex VARCHAR(55);
    SET regex := CONCAT('^[', set_of_letters, ']+$');
    
	RETURN word REGEXP regex;
END&&

SELECT ufn_is_word_comprised('Oistmiahf', 'Sofia')&&
SELECT ufn_is_word_comprised('Oistmiahf', 'halves')&&
SELECT ufn_is_word_comprised('Bobr', 'Rob')&&
SELECT ufn_is_word_comprised('Pppp', 'Guy')&&