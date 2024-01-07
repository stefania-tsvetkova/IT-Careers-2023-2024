USE softuni;

-- Problem 1
SELECT employee_id, job_title, e.address_id, address_text FROM employees AS e
JOIN addresses AS a
ON a.address_id = e.address_id
ORDER BY e.address_id
LIMIT 5;

-- Problem 2
SELECT e.employee_id, e.first_name, e.last_name, d.name AS department_name
 FROM employees AS e
JOIN departments AS d
ON e.department_id = d.department_id AND d.name = 'Sales'
ORDER BY e.employee_id DESC;

-- Problem 3
SELECT e.employee_id, e.first_name, e.salary, d.name AS department_name
 FROM employees AS e
JOIN departments AS d
ON e.department_id = d.department_id
WHERE e.salary > 15000
ORDER BY e.department_id DESC
LIMIT 5;

-- Problem 4
SELECT e.employee_id, first_name FROM employees AS e
LEFT JOIN employees_projects AS ep
ON ep.employee_id = e.employee_id
WHERE ep.employee_id IS NULL
ORDER BY employee_id DESC
LIMIT 3;

-- Problem 5
SELECT e.employee_id, e.first_name, e.manager_id, m.first_name AS manager_name FROM employees AS e
JOIN employees AS m
ON e.manager_id = m.employee_id AND m.employee_id IN (3, 7)
ORDER BY e.first_name;

SELECT 
	e.employee_id, 
    e.first_name, 
    e.manager_id, 
    (
		SELECT m.first_name FROM employees AS m
        WHERE m.employee_id = e.manager_id 
    ) AS manager_name 
FROM employees AS e
WHERE manager_id IN (3, 7)
ORDER BY e.first_name;

-- Problem 6
SELECT MAX(e.salary), d.name FROM employees AS e
JOIN departments AS d
GROUP BY d.department_id;

-- Problem 7
USE geography;

SELECT c.country_name FROM countries AS c
LEFT JOIN mountains_countries AS mc
ON c.country_code = mc.country_code
WHERE mc.mountain_id IS NULL;

-- Problem 2
SELECT c1.continent_name AS 'FROM', c2.continent_name AS 'TO' FROM continents AS c1
CROSS JOIN continents AS c2
ORDER BY c1.continent_name, c2.continent_name;

-- Problem 3
SELECT 
	c1.capital AS 'Place',
    c1.country_name AS 'Player 1',
    '' AS 'Host',
    '' AS 'Guest',
    c2.country_name AS 'Player 2'
FROM countries AS c1
CROSS JOIN countries AS c2
WHERE c1.country_code != c2.country_code
ORDER BY RAND();

-- Problem 4
SELECT 
    c.country_name, 
    (
		SELECT MAX(p.elevation) FROM peaks AS p
		JOIN mountains_countries AS m
		ON p.mountain_id = m.mountain_id
		WHERE m.country_code = c.country_code
    ) AS highest_peak_elevation,
    (
		SELECT MAX(r.length) FROM rivers AS r
        JOIN countries_rivers AS cr
        ON cr.river_id = r.id
        WHERE cr.country_code = c.country_code
    ) AS longest_river_length
FROM countries AS c
ORDER BY highest_peak_elevation DESC, longest_river_length DESC, c.country_name
LIMIT 5;