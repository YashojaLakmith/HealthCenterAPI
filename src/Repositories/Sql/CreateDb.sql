DECLARE @dbName AS nvarchar(100) = 'Db_HealthCenterAPI';

IF NOT EXISTS(SELECT * FROM master.sys.databases WHERE name = @dbName)
BEGIN
	CREATE DATABASE Db_HealthCenterAPI;
END