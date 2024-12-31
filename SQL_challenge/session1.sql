use master
create database session1
go
use session1
create table color(
	color_id int primary key,
	color_name varchar(40),
	extra_fee decimal
);
go
create table customer(
	customer_id int primary key,
	first_name varchar(40),
	last_name varchar(40),
	favorite_color_idstores int,
	constraint fk_customer_color foreign key (favorite_color_idstores) references color(color_id) 
);
go
create table category(
	category_id int primary key,
	category_name varchar(40),
	parent_id int
);
go
create table clothing(
	clothing_id int primary key,
	clothing_name varchar(40),
	size varchar(40) check (size in('S', 'M', 'L', 'XL', '2XL',  '3XL')),
	price int,
	color_id int,
	category_id int
	constraint fk_clothing_color foreign key (color_id) references color(color_id), 
	constraint fk_clothing_category foreign key (category_id) references category(category_id) 
);
go
create table clothing_orders(
	order_id int primary key,
	customer_id int,
	clothing_id int,
	quantity int,
	order_date datetime
	constraint fk_clothing_customer foreign key (customer_id) references customer(customer_id), 
	constraint fk_clothing_clothing foreign key (clothing_id) references clothing(clothing_id) 
);
go
INSERT INTO color (color_id, color_name, extra_fee)
VALUES
  (1, 'Red', 5.0),
  (2, 'Blue', 3.5),
  (3, 'Green', 2.0),
  (4, 'Yellow', 4.0),
  (5, 'Black', 0.0);
go
INSERT INTO customer (customer_id, first_name, last_name, favorite_color_idstores)
VALUES
  (101, 'John', 'Doe', 1),
  (102, 'Alice', 'Smith', 2),
  (103, 'Bob', 'Johnson', 3),
  (104, 'Emily', 'Brown', 4),
  (105, 'David', 'Lee', 5);
go
INSERT INTO category (category_id, category_name, parent_id)
VALUES
  (1, 'Men', NULL),
  (2, 'Women', NULL),
  (3, 'Accessories', 2),
  (4, 'Shoes', 1),
  (5, 'Kids', NULL);
go
INSERT INTO clothing (clothing_id, clothing_name, size, price, color_id, category_id)
VALUES
  (201, 'T-Shirt', 'M', 20, 1, 1),
  (202, 'Jeans', 'L', 50, 2, 1),
  (203, 'Dress', 'S', 80, 3, 2),
  (204, 'Sneakers', 'XL', 70, 4, 4),
  (205, 'Hat', 'L', 15, 5, 3);
go
INSERT INTO clothing_orders (order_id, customer_id, clothing_id, quantity, order_date)
VALUES
  (301, 101, 201, 2, '2024-07-09 10:30:00'),
  (302, 102, 203, 1, '2024-07-09 11:15:00'),
  (303, 103, 204, 3, '2024-07-09 12:00:00'),
  (304, 104, 202, 1, '2024-07-09 13:45:00'),
  (305, 105, 205, 2, '2024-07-09 14:30:00');
go
----1----
select clothing.clothing_name,
	   color.color_name,
	   customer.first_name,
	   customer.last_name
from clothing
join color on clothing.color_id = color.color_id
join clothing_orders on clothing_orders.clothing_id = clothing.clothing_id
join customer on clothing_orders.customer_id = customer.customer_id
where clothing.color_id = customer.favorite_color_idstores;
----2----
SELECT
  c.last_name,
  c.first_name,
  col.color_name AS favorite_color
FROM customer c
LEFT JOIN color col ON c.favorite_color_idstores = col.color_id
WHERE c.customer_id NOT IN (
  SELECT DISTINCT customer_id
  FROM clothing_orders
);
----3----
SELECT
    c1.category_name AS category,
    c2.category_name AS subcategory
FROM
    category c1
LEFT JOIN
    category c2 ON c1.category_id = c2.parent_id
WHERE
    c1.parent_id IS NULL;
