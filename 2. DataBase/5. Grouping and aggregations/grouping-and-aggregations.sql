USE gringotts;

-- Problem 1
SELECT COUNT(id) AS count FROM wizzard_deposits;

-- Problem 2
SELECT MAX(magic_wand_size) AS longest_magic_wand FROM wizzard_deposits;

-- Problem 3
SELECT 
	deposit_group,
	MAX(magic_wand_size) AS longest_magic_wand 
FROM wizzard_deposits
GROUP BY deposit_group;

-- Problem 4
SELECT deposit_group FROM wizzard_deposits
GROUP BY deposit_group
HAVING ROUND(AVG(magic_wand_size), 4) = ROUND(
	(
		SELECT MIN(avg_magic_wand_size) FROM (
			SELECT AVG(magic_wand_size) AS avg_magic_wand_size FROM wizzard_deposits
			GROUP BY deposit_group
		) AS wd
	),
    4
);

-- Problem 5
SELECT deposit_group, SUM(deposit_amount) AS total_sum FROM wizzard_deposits
GROUP BY deposit_group
ORDER BY total_sum;

-- Problem 6
SELECT deposit_group, SUM(deposit_amount) AS total_sum FROM wizzard_deposits
WHERE magic_wand_creator = 'Ollivander family'
GROUP BY deposit_group
ORDER BY deposit_group;

-- Problem 7
SELECT deposit_group, SUM(deposit_amount) AS total_sum FROM wizzard_deposits
WHERE magic_wand_creator = 'Ollivander family'
GROUP BY deposit_group
HAVING total_sum < 150000
ORDER BY total_sum DESC;

-- Problem 8
SELECT
	deposit_group,
    (
		SELECT magic_wand_creator FROM wizzard_deposits AS wd1
        WHERE wd1.deposit_charge = wd.deposit_charge AND wd1.deposit_group = wd.deposit_group
        LIMIT 1
	) AS magic_wand_creator,
    MIN(deposit_charge) AS min_deposit_charge
FROM wizzard_deposits AS wd
GROUP BY deposit_group
ORDER BY magic_wand_creator, deposit_group;

-- Problem 9
SELECT 
	(CASE
		WHEN age <= 10 THEN '[0-10]'
		WHEN age > 10 AND age <= 20 THEN '[11-20]'
		WHEN age > 20 AND age <= 30 THEN '[21-30]'
		WHEN age > 30 AND age <= 40 THEN '[31-40]'
		WHEN age > 40 AND age <= 50 THEN '[41-50]'
		WHEN age > 50 AND age <= 60 THEN '[51-60]'
		-- WHEN age > 60 THEN '[61+]'
        ELSE '[61+]'
	END) AS age_group,
    COUNT(*) AS wizard_count
FROM wizzard_deposits
GROUP BY age_group
ORDER BY age_group;

-- Problem 10
SELECT LEFT(first_name, 1) AS first_letter FROM wizzard_deposits
WHERE deposit_group = 'Troll Chest'
GROUP BY first_letter
ORDER BY first_letter;

SELECT DISTINCT LEFT(first_name, 1) AS first_letter FROM wizzard_deposits
WHERE deposit_group = 'Troll Chest'
ORDER BY first_letter;

-- Problem 11
SELECT 
	deposit_group, 
    is_deposit_expired, 
    AVG(deposit_interest) AS average_interest 
FROM wizzard_deposits
WHERE deposit_start_date > '1985-01-01'
GROUP BY deposit_group, is_deposit_expired
ORDER BY deposit_group DESC, is_deposit_expired;

-- Problem 12
SELECT
	w1.first_name AS host_wizzard,
	w1.deposit_amount AS host_wizzard_deposit,
	w2.first_name AS guest_wizzard,
	w2.deposit_amount AS guest_wizzard_deposit,
	w1.deposit_amount - w2.deposit_amount AS difference
FROM wizzard_deposits AS w1
JOIN wizzard_deposits AS w2
ON w2.id = w1.id + 1;

SELECT SUM(difference) AS sum_difference FROM (
	SELECT
		w1.deposit_amount - w2.deposit_amount AS difference
	FROM wizzard_deposits AS w1
	JOIN wizzard_deposits AS w2
	ON w2.id = w1.id + 1
) AS a;

-- Problem 13
USE softuni;

SELECT 
	department_id, 
    ROUND(MIN(salary), 2) AS minimum_salary 
FROM employees
WHERE department_id IN (2,5,7) AND hire_date > '2000-01-01'
GROUP BY department_id
ORDER BY department_id;

-- Problem 14
CREATE TABLE problem14_high_paid_employees
AS
SELECT * FROM employees
WHERE salary > 30000;

DELETE FROM problem14_high_paid_employees
WHERE manager_id = 42;

-- Approach 1 for creating problem14_high_paid_employees_increased
CREATE TABLE problem14_high_paid_employees_increased
AS
(
	SELECT 
		employee_id,
		first_name,
		last_name,
		middle_name,
		job_title,
		department_id,
		manager_id,
		hire_date,
		salary + 5000 AS salary,
		address_id
	FROM problem14_high_paid_employees
	WHERE department_id = 1
)
UNION
(
	SELECT * FROM problem14_high_paid_employees
	WHERE department_id != 1
);

-- Approach 2 for creating problem14_high_paid_employees_increased
CREATE TABLE problem14_high_paid_employees_increased
AS
SELECT 
	employee_id,
	first_name,
	last_name,
	middle_name,
	job_title,
	department_id,
	manager_id,
	hire_date,
	(CASE
		WHEN department_id = 1 THEN salary + 5000
        ELSE salary
	END) AS salary,
	address_id
FROM problem14_high_paid_employees;

SELECT department_id, AVG(salary) AS avg_salary FROM problem14_high_paid_employees_increased
GROUP BY department_id
ORDER BY department_id;

-- Problem 15
SELECT department_id, MAX(salary) AS max_salary FROM employees
GROUP BY department_id
HAVING max_salary < 30000 OR max_salary > 70000
ORDER BY department_id;

-- Problem 16
SELECT COUNT(*) FROM employees
WHERE manager_id IS NULL;

-- Problem 17
SELECT 
	department_id, 
    (
		SELECT e1.salary FROM employees AS e1
		WHERE e1.department_id = e.department_id
		ORDER BY salary DESC
		LIMIT 2, 1
	) third_highest_salary
FROM employees As e
GROUP BY department_id
ORDER BY department_id;

-- Problem 18
SELECT AVG(salary) FROM employees
WHERE department_id = 1;

SELECT first_name, last_name, department_id FROM employees AS e
WHERE salary > (
	SELECT AVG(salary) FROM employees AS e1
	WHERE e1.department_id = e.department_id
)
ORDER BY department_id
LIMIT 10;

-- Problem 19
SELECT department_id, SUM(salary) AS total_salary FROM employees
GROUP BY department_id
ORDER BY department_id;