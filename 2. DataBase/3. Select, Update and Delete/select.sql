USE softuni;

-- Problem 1
SELECT * FROM departments;

-- Problem 2
SELECT name FROM departments;

-- Problem 3
SELECT first_name, last_name, salary FROM employees;

-- Problem 4
SELECT first_name, middle_name, last_name FROM employees;

-- Problem 5
SELECT CONCAT(first_name, '.', last_name, '@softuni.bg') AS full_email_address FROM employees;

-- Problem 6
SELECT DISTINCT salary FROM employees;

-- Problem 7
SELECT * FROM employees 
WHERE job_title = 'Sales Representative';

-- Problem 8
SELECT first_name, last_name, job_title AS JobTitle FROM employees
WHERE salary BETWEEN 20000 AND 30000;

-- Problem 9
SELECT CONCAT(first_name, ' ', middle_name, ' ', last_name) AS 'Full Name' FROM employees
WHERE salary IN (25000, 14000, 12500, 23600);

-- Problem 10
SELECT first_name, last_name FROM employees
WHERE manager_id IS NULL;

-- Problem 11
SELECT first_name, last_name, salary FROM employees
WHERE salary > 50000
ORDER BY salary DESC;

-- Problem 12
SELECT first_name, last_name FROM employees
ORDER BY salary DESC
LIMIT 5;

-- Problem 13
SELECT first_name, last_name FROM employees
WHERE department_id = 4;
-- it's better to be done with a join with departments table

-- Problem 14
SELECT DISTINCT job_title FROM employees;

-- Problem 15
SELECT * FROM projects
ORDER BY start_date, name
LIMIT 10;

-- Problem 16
SELECT first_name, last_name, hire_date FROM employees
ORDER BY hire_date DESC
LIMIT 7;

-- Problem 17
SELECT department_id from departments
WHERE name IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services');

UPDATE employees
SET salary = salary * 1.12
WHERE department_id IN (1, 2, 4, 11);

SELECT salary FROM employees
WHERE department_id IN (1, 2, 4, 11);