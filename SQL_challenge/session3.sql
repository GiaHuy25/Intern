USE master
CREATE DATABASE OnlineShop;
GO
USE OnlineShop;
GO
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    email VARCHAR(100),
    full_name VARCHAR(200),
    address VARCHAR(200),
    city VARCHAR(100),
    region VARCHAR(100),
    postal_code VARCHAR(20),
    country VARCHAR(100),
    phone VARCHAR(20),
    registration_date DATE,
    channel_id INT,
    first_order_id INT,
    first_order_date DATE,
    last_order_id INT,
    last_order_date DATE
);
GO
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    total_amount DECIMAL(10, 2),
    ship_name VARCHAR(200),
    ship_address VARCHAR(200),
    ship_city VARCHAR(100),
    ship_region VARCHAR(100),
    ship_postalcode VARCHAR(20),
    ship_country VARCHAR(100),
    shipped_date DATE
	constraint fk_order_customer foreign key (customer_id) references customers(customer_id) 
);
GO

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100),
    description VARCHAR(500)
);
GO

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(200),
    category_id INT,
    unit_price DECIMAL(10, 2),
    discontinued BIT
	constraint fk_product_categories foreign key (category_id) references categories(category_id) 
);
GO

CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    unit_price DECIMAL(10, 2),
    quantity INT,
    discount DECIMAL(5, 2),
    PRIMARY KEY (order_id, product_id),
	constraint fk_orderitem_order foreign key (order_id) references orders(order_id), 
	constraint fk_orderitem_product foreign key (product_id) references products(product_id) 
);
GO

CREATE TABLE channels (
    id INT PRIMARY KEY,
    channel_name VARCHAR(100)
);
GO
INSERT INTO customers (customer_id, email, full_name, address, city, region, postal_code, country, phone, registration_date, channel_id, first_order_id, first_order_date, last_order_id, last_order_date)
VALUES
(1, 'john.doe@example.com', 'John Doe', '123 Main St', 'Anytown', 'CA', '12345', 'USA', '555-1234', '2022-01-01', 1, 1001, '2022-02-15', 1005, '2023-06-30'),
(2, 'jane.smith@example.com', 'Jane Smith', '456 Oak Rd', 'Somewhere', 'NY', '67890', 'USA', '555-5678', '2021-03-15', 2, 2001, '2021-04-20', 2010, '2023-12-31'),
(3, 'bob.johnson@example.com', 'Bob Johnson', '789 Elm St', 'Elsewhere', 'TX', '54321', 'USA', '555-9012', '2020-06-01', 3, 3001, '2020-07-10', 3015, '2023-11-20'),
(4, 'alice.williams@example.com', 'Alice Williams', '321 Oak Ave', 'Anywhere', 'FL', '09876', 'USA', '555-3456', '2019-09-01', 1, 4001, '2019-10-05', 4020, '2023-08-31'),
(5, 'tom.davis@example.com', 'Tom Davis', '159 Maple Rd', 'Everywere', 'WA', '24680', 'USA', '555-7890', '2018-12-01', 2, 5001, '2019-01-15', 5025, '2023-09-15');
GO
INSERT INTO orders (order_id, customer_id, order_date, total_amount, ship_name, ship_address, ship_city, ship_region, ship_postalcode, ship_country, shipped_date)
VALUES
(1001, 1, '2022-02-15', 125.99, 'John Doe', '123 Main St', 'Anytown', 'CA', '12345', 'USA', '2022-02-18'),
(2001, 2, '2021-04-20', 250.50, 'Jane Smith', '456 Oak Rd', 'Somewhere', 'NY', '67890', 'USA', '2021-04-22'),
(3001, 3, '2020-07-10', 75.75, 'Bob Johnson', '789 Elm St', 'Elsewhere', 'TX', '54321', 'USA', '2020-07-12'),
(4001, 4, '2019-10-05', 190.25, 'Alice Williams', '321 Oak Ave', 'Anywhere', 'FL', '09876', 'USA', '2019-10-08'),
(5001, 5, '2019-01-15', 300.00, 'Tom Davis', '159 Maple Rd', 'Everywere', 'WA', '24680', 'USA', '2019-01-17');
GO
INSERT INTO products (product_id, product_name, category_id, unit_price, discontinued)
VALUES
(1001, 'Product A', 1, 9.99, 0),
(1002, 'Product B', 2, 19.50, 0),
(1003, 'Product C', 3, 14.75, 0),
(1004, 'Product D', 1, 7.25, 0),
(1005, 'Product E', 2, 12.99, 0);
GO
INSERT INTO categories (category_id, category_name, description)
VALUES
(1, 'Category A', 'This is a description of Category A'),
(2, 'Category B', 'This is a description of Category B'),
(3, 'Category C', 'This is a description of Category C'),
(4, 'Category D', 'This is a description of Category D'),
(5, 'Category E', 'This is a description of Category E');
GO
INSERT INTO order_items (order_id, product_id, unit_price, quantity, discount)
VALUES
(1001, 1001, 9.99, 2, 0.00),
(2001, 1002, 19.50, 3, 0.10),
(3001, 1003, 14.75, 1, 0.05),
(4001, 1004, 7.25, 4, 0.00),
(5001, 1005, 12.99, 2, 0.15);
GO
INSERT INTO channels (id, channel_name)
VALUES
(1, 'Online'),
(2, 'Retail Store'),
(3, 'Telemarketing'),
(4, 'Direct Mail'),
(5, 'Trade Show');
GO
----2----
select top 3
			order_id,
			total_amount
from orders
order by total_amount desc
----3----
select customers.customer_id,
	   customers.full_name,
	   orders.order_id,
	   orders.order_date,
	   orders.total_amount
from orders
join customers on orders.customer_id = customers.customer_id
order by total_amount desc