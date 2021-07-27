/* Fallback code to check whether or not the database in question currently exists. 
 * If the condition below is true, then the database will be deleted. 
 * Of course, control will be given to the default database master, 
 * then the command to delete the database will be executed. 
 * sys.databases contains information related to all databases within the currently connected server. */
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Tallinja') -- Check whether the database named tallinja exists within the current server.
BEGIN
	USE master;-- Switch control to the default database.

	DROP DATABASE Tallinja; -- Delete the tallinja database.
END

CREATE DATABASE Tallinja; -- Create the database tallinja.
GO

USE Tallinja; -- Switch control to tallinja in order to create tables within this
GO 

CREATE TABLE Customers (
	customer_id INTEGER IDENTITY(1,1) PRIMARY KEY,
	customer_number INTEGER UNIQUE NOT NULL CHECK (LEN(customer_number) BETWEEN 6 AND 10), -- Check that the customer number is between 6 to 10 characters long.
	date DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE CustomersBalance (
	transaction_id INTEGER IDENTITY(1,1) PRIMARY KEY,
	customer_id INTEGER FOREIGN KEY REFERENCES Customers(customer_id),
	balance DECIMAL(6,2) NOT NULL CHECK (balance > 0), -- Check that the balance is greater than 0.
	date DATETIME NOT NULL DEFAULT GETDATE()
);	