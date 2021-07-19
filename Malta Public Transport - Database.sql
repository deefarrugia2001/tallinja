/* Fallback code to check whether or not the database in question currently exists. 
 * If the condition below is true, then the database will be deleted. 
 * Of course, control will be given to the default database master, 
 * then the command to delete the database will be executed. 
 * sys.databases contains information related to all databases within the currently connected server. */
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'tallinja') -- Check whether the database named tallinja exists within the current server.
BEGIN
	USE master; -- Switch control to the default database.
	DROP DATABASE tallinja; -- Delete the tallinja database.
END
ELSE
BEGIN
	CREATE DATABASE tallinja; -- Create the database tallinja.
	USE tallinja; -- Switch control to tallinja in order to create tables within this

	CREATE TABLE customers (
		customer_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
		customer_number INTEGER UNIQUE NOT NULL CHECK (LEN(customer_number) = 8) -- Check that the customer number is exactly eight characters long.
	);

	CREATE TABLE customers_balance (
		customer_id UNIQUEIDENTIFIER DEFAULT NEWID() FOREIGN KEY REFERENCES customers(customer_id),
		balance DECIMAL(6,2) NOT NULL CHECK (balance < 0), -- Check that the balance is greater than 0.
		date DATE NOT NULL
	);
END