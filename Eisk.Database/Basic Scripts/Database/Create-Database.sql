-- =============================================
-- Script Template
-- =============================================
USE master
DECLARE @database_name nvarchar(100)
SET @database_name = 'test_EmployeeInfo_SK_4_0_00'
IF db_id(@database_name) IS NOT NULL
	BEGIN
		Print 'Database exists..no need to re-create!'
		--DROP DATABASE test_EmployeeInfo_SK_4_0
	END
ELSE
	BEGIN
		Print 'Database does not exists..creating the database..'
		CREATE DATABASE test_EmployeeInfo_SK_4_0_00
	END
--USE a0010


