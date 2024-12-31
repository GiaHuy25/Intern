use master
CREATE DATABASE RunningEvents;
go
-- Use the newly created database
USE RunningEvents;
go
-- Create the runner table
CREATE TABLE runner (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    main_distance INT,
    age INT,
    is_female BIT
);

-- Create the event table
CREATE TABLE event (
    id INT PRIMARY KEY,
    name VARCHAR(100),
    start_date DATE,
    city VARCHAR(100)
);

-- Create the runner_event table
CREATE TABLE runner_event (
    runner_id INT,
    event_id INT,
    PRIMARY KEY (runner_id, event_id),
    FOREIGN KEY (runner_id) REFERENCES runner(id),
    FOREIGN KEY (event_id) REFERENCES event(id)
);
INSERT INTO runner (id, name, main_distance, age, is_female)
VALUES
    (1, 'Alice Johnson', 5000, 28, 1),
    (2, 'Bob Smith', 10000, 35, 0),
    (3, 'Charlie Brown', 8000, 42, 0),
    (4, 'Diana Lee', 6000, 24, 1),
    (5, 'Eva Garcia', 7500, 31, 1);
go
INSERT INTO event (id, name, start_date, city)
VALUES
    (101, 'London Marathon', '2024-09-15', 'London'),
    (102, 'Warsaw Runs', '2024-08-20', 'Warsaw'),
    (103, 'New Year Run', '2024-01-01', 'New York'),
    (104, 'Spring Fun Run', '2024-04-10', 'Chicago'),
    (105, 'Summer Sunset Race', '2024-07-30', 'Los Angeles');
go
INSERT INTO runner_event (runner_id, event_id)
VALUES
    (1, 101),
    (2, 102),
    (3, 103),
    (4, 104),
    (5, 105);
go
----2----
select count(*) as runner_number
from runner
where main_distance >= 3000
----3----
SELECT
    e.name AS event_name,
    ISNULL(COUNT(re.runner_id), 0) AS runner_count
FROM
    event e
LEFT JOIN
    runner_event re ON e.id = re.event_id
GROUP BY
    e.name;
----4----
select main_distance,
	   sum(case when age < 20 then 1 else 0 end) as under_20,
	   sum(case when age between 20 and 29 then 1 else 0 end) as age_20_29,
	   sum(case when age between 30 and 39 then 1 else 0 end) as age_30_39,
	   sum(case when age between 40 and 49  then 1 else 0 end) as age_40_49,
	   sum(case when age > 50 then 1 else 0 end) as over_50
from runner
group by main_distance