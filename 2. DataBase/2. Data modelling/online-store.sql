CREATE DATABASE online_store;

USE online_store;

CREATE TABLE item_types(
	item_type_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE items(
	item_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    item_type_id INT NOT NULL,
    CONSTRAINT fk_items_item_types
    FOREIGN KEY (item_type_id) REFERENCES item_types (item_type_id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE cities(
	city_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE customers(
	customer_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    birthdate DATE NOT NULL,
    city_id INT NOT NULL,
    CONSTRAINT fk_customers_cities
    FOREIGN KEY (city_id) REFERENCES cities (city_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    CONSTRAINT chk_customer_birthdate
    CHECK (birthdate <= '2004-01-01')
);

CREATE TABLE orders(
	order_id INT PRIMARY KEY AUTO_INCREMENT,
    customer_id INT NOT NULL,
    CONSTRAINT fk_orders_customers
    FOREIGN KEY (customer_id) REFERENCES customers (customer_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE order_items(
	order_id INT NOT NULL,
    item_id INT NOT NULL,
    CONSTRAINT pk_order_items
    PRIMARY KEY (order_id, item_id),
    CONSTRAINT fk_order_items_orders
    FOREIGN KEY (order_id) REFERENCES orders (order_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    CONSTRAINT fk_order_items_items
    FOREIGN KEY (item_id) REFERENCES items (item_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

INSERT INTO item_types(name)
VALUES	('dairy'), 
		('detergents');

INSERT INTO items(name, item_type_id)
VALUES	('milk', 1), 
		('cheese', 1), 
        ('soap', 2);

INSERT INTO cities(name)
VALUES	('Sofia'), 
		('Plovdiv');
        
INSERT INTO customers(name, birthdate, city_id)
VALUES	('Ivan', '2000-05-06', 1),
		('Petar', '1997-01-04', 1),
        ('Maria', '2003-08-20', 2);
        
INSERT INTO orders(customer_id)
VALUES	(1),
		(1),
        (2);
        
INSERT INTO order_items(order_id, item_id)
VALUES	(1, 1),
		(1, 2),
        (2, 3),
        (3, 1),
        (3, 3);
        
SELECT * FROM item_types;
SELECT * FROM items;
        
UPDATE item_types
SET item_type_Id = 101
WHERE item_type_id = 1;
        
SELECT * FROM item_types;
SELECT * FROM items;

DELETE FROM item_types
WHERE item_type_id = 2;

SELECT * FROM item_types;
SELECT * FROM items;
SELECT * FROM order_items;