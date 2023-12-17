USE softuni;

-- Problem 1
INSERT INTO towns(name)
VALUES	('Sofia'), 
		('Plovdiv'), 
        ('Varna'), 
        ('Burgas');

INSERT INTO departments(name, manager_id)
VALUES	('Engineering', 1), 
		('Sales', 1), 
        ('Marketing', 1), 
        ('Software Development', 1), 
        ('Quality Assurance', 1);
        
INSERT INTO employees(first_name, middle_name, last_name, job_title, department_id, hire_date, salary)
VALUES	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 20, '2013-02-01', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 21, '2016-08-28', 525.25),
		('Georgi', 'Terziev', 'Ivanov', 'CEO', 3, '2007-12-09', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 4, '2016-08-28', 599.88);
      
-- Problem 2
SELECT * FROM towns;

SELECT * FROM departments;

SELECT * FROM employees;

-- Problem 3
SELECT name FROM towns;

SELECT name FROM departments;

SELECT first_name, last_name, job_title, salary FROM employees;

-- Problem 4
UPDATE employees
SET salary = salary * 1.10;