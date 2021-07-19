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