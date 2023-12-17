USE softuni;

-- Problem 1
SELECT first_name, last_name, salary FROM employees
WHERE salary = 
	(
		SELECT salary FROM employees
		ORDER BY salary
		LIMIT 1
    );
    
-- Problem 2
SELECT first_name, last_name, salary FROM employees
WHERE salary <= 
	(
		SELECT salary FROM employees
		ORDER BY salary
		LIMIT 1
    ) * 1.1;
    
-- Problem 3
SELECT first_name, last_name, job_title FROM employees
WHERE employee_id IN (SELECT DISTINCT manager_id FROM employees)
ORDER BY first_name, last_name;

-- Problem 4
SELECT town_id FROM towns
WHERE name = 'San Francisco'
LIMIT 1;

SELECT address_id FROM addresses
WHERE town_id = 
	(
		SELECT town_id FROM towns
		WHERE name = 'San Francisco'
		LIMIT 1
	);
    
SELECT first_name, last_name FROM employees
WHERE address_id IN
	(
		SELECT address_id FROM addresses
		WHERE town_id = 
			(
				SELECT town_id FROM towns
				WHERE name = 'San Francisco'
				LIMIT 1
			)
	);