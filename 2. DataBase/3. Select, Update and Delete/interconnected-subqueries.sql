USE softuni;

-- Problem 1
SELECT job_title, salary FROM employees AS e
WHERE salary = 
	(
		SELECT s.salary FROM employees AS s
        WHERE s.job_title = e.job_title
        ORDER BY s.salary DESC
        LIMIT 1
    )
ORDER BY salary DESC, job_title;

-- Problem 2
SELECT 
	first_name, 
    last_name, 
    salary, 
    (
		SELECT name FROM departments AS d 
        WHERE d.department_id = e.department_id
	) AS 'department'
FROM employees AS e
WHERE salary =
	(
		SELECT MIN(s.salary) FROM employees AS s
        WHERE s.department_id = e.department_id
    )
ORDER BY salary, first_name, last_name;

-- Problem 3
SELECT first_name, last_name FROM employees AS m
WHERE EXISTS
	(
		SELECT e.employee_id FROM employees AS e
        WHERE m.middle_name = e.middle_name AND m.employee_id = e.manager_id
    )
ORDER BY first_name, last_name;

-- Problem 4
SELECT first_name, last_name FROM employees AS m
WHERE EXISTS
	(
		SELECT e.employee_id FROM employees AS e
        WHERE e.manager_id = m.employee_id AND m.salary < e.salary
    );
    
-- Problem 5
SELECT first_name, last_name FROM employees AS m
WHERE 
	(
		SELECT COUNT(e.employee_id) FROM employees AS e
        WHERE e.manager_id = m.employee_id
    ) = 5
ORDER BY first_name, last_name;

-- Problem 6
USE geography;

SELECT 
	(
		SELECT m.mountain_range FROM mountains AS m
        WHERE m.id = p.mountain_id
	) AS mountain_range,
	p.peak_name,
    p.elevation
FROM peaks AS p
WHERE 
	elevation = (
		SELECT MAX(p2.elevation) FROM peaks AS p2
        WHERE p2.mountain_id = p.mountain_id
	)
    AND
    mountain_id IN (
		SELECT mountain_id FROM mountains_countries
        WHERE country_code = 'BG'
    )
ORDER BY elevation DESC;

-- Problem 7
SELECT mountain_range FROM mountains AS m
WHERE
	id IN (
		SELECT mountain_id FROM mountains_countries
        WHERE country_code = 'BG'
	)
    AND 
    NOT EXISTS (
		SELECT p.id FROM peaks AS p
        WHERE p.mountain_id = m.id
    );