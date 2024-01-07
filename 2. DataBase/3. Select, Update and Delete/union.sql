USE softuni;

(SELECT 
	first_name,
    last_name,
	"employee"
FROM employees AS m
WHERE NOT EXISTS (
	SELECT employee_id FROM employees AS e 
    WHERE e.manager_id = m.employee_id
)
ORDER BY salary DESC
LIMIT 3)
UNION
(SELECT 
	first_name,
    last_name,
	"manager"
FROM employees AS m
WHERE EXISTS (
	SELECT employee_id FROM employees AS e 
    WHERE e.manager_id = m.employee_id
)
ORDER BY salary DESC
LIMIT 3)
ORDER BY first_name, last_name;

USE geography;

SELECT 
	mountain_range,
	IF (
		(
			SELECT peak_name FROM peaks AS p
			WHERE p.mountain_id = m.id
			ORDER BY elevation DESC
			LIMIT 1
		) IS NULL,
        'no info',
        (
			SELECT peak_name FROM peaks AS p
			WHERE p.mountain_id = m.id
			ORDER BY elevation DESC
			LIMIT 1
		)
	) AS peak_name,
	IF (
		(
			SELECT elevation FROM peaks AS p
			WHERE p.mountain_id = m.id
			ORDER BY elevation DESC
			LIMIT 1
		) IS NULL,
        'no info',
        (
			SELECT elevation FROM peaks AS p
			WHERE p.mountain_id = m.id
			ORDER BY elevation DESC
			LIMIT 1
		)
	) AS elevation
FROM mountains AS m
ORDER BY mountain_range;

(SELECT 
	m.mountain_range,
    (
		SELECT peak_name FROM peaks AS p
		WHERE p.mountain_id = m.id
		ORDER BY elevation DESC
		LIMIT 1
	) AS peak_name,
    (
		SELECT elevation FROM peaks AS p
		WHERE p.mountain_id = m.id
		ORDER BY elevation DESC
		LIMIT 1
	) AS elevation
FROM mountains AS m
WHERE EXISTS (
		SELECT id FROM peaks
        WHERE mountain_id = m.id
))
UNION
(SELECT mountain_range, 'no info', 'no info' FROM mountains AS m
WHERE NOT EXISTS (
		SELECT id FROM peaks
        WHERE mountain_id = m.id
))
ORDER BY mountain_range;