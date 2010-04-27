/****** Object:  StoredProcedure [dbo].[Employees_GetEmployeesByReportsTo_Paged]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeesByReportsTo_Paged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]

Functional Comment:
This stored procedure returns an specific segment of records from the main 
employee table, with respect to a starting index and number of maximum rows to be returned, 
according to a specific order, according to the foreign key ''ReportsTo''. 

Desgin Notes:
This stored procedure is extremently useful when we display tabulater data in paged manner,
where on each time during the data binding returning of all records for a given page not necessary,
and thus saving proessing time (db and web), memory (db and web ) and network traffic.
We have considered ASP.NET 2.0 object data source and SQL Server 2005 new functionalities to implement this concept.
*/
CREATE PROCEDURE [dbo].[Employees_GetEmployeesByReportsTo_Paged]
(@reportsTo Int, @orderby varchar(50),@startrow int,@pagesize int)
As
SET NOCOUNT ON

/* from the object data source control, the start index is ''0'' and 
the ''ROW_NUMBER()'' sql server function starts with ''1''. 
So we are updating the start index to match with sql server row index
*/
set @startrow = @startrow + 1;

declare @sql nvarchar(4000);


/*
In the sql statement below, using the ''WITH'' statement we are first populating a temporary table,
where we considered the ROW_NUMBER() function to creating ROW_Index. Note that, this is just a declation of the table, no select statement is executed here.
The temprary table is then is used to be qieried according to the row index and recored size, based on which the appropriate segment of recored is being returned.
*/
	set @sql=''
			WITH Employees_PageSegment AS ( 
				SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath, 
				ROW_NUMBER() OVER ( ORDER BY '' + @orderby + '' ) as RowIndex
				FROM Employees
			)

			SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath 
			FROM Employees_PageSegment
			WHERE 
			reportsTo = '' 
			+  CONVERT(nvarchar(10),@reportsTo)
			+ ''  AND 
			RowIndex BETWEEN '' 
			+  CONVERT(nvarchar(10),@startrow)  
			+ '' AND ('' 
			+ CONVERT(nvarchar(10),@startrow) + '' + '' + CONVERT(nvarchar(10),@pagesize)  
			+ '') - 1  order by '' 
			+ CONVERT(nvarchar(20),@orderby);

exec sp_executesql @sql
' 
END
/**/
/****** Object:  Table [dbo].[Employees]    Script Date: 03/18/2010 14:51:41 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[TitleOfCourtesy] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NOT NULL,
	[Address] [nvarchar](60) NOT NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NOT NULL,
	[HomePhone] [nvarchar](24) NOT NULL,
	[Extension] [nvarchar](4) NULL,
	[Photo] [image] NULL,
	[Notes] [ntext] NULL,
	[ReportsTo] [int] NULL,
	[PhotoPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_GetAllEmployees_Paged]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetAllEmployees_Paged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]

Functional Comment:
This stoed procedure returns an specific segment of records from the main 
employee table, with respect to a starting index and number of maximum rows to be returned, 
according to a specific order. 

Desgin Notes:
This stored procedure is extremently useful when we display tabulater data in paged manner,
where on each time during the data binding returning of all records for a given page not necessary,
and thus saving proessing time (db and web), memory (db and web ) and network traffic.
We have considered ASP.NET 2.0 object data source and SQL Server 2005 new functionalities to implement this concept.
*/
CREATE proc [dbo].[Employees_GetAllEmployees_Paged]
(@orderby varchar(50),@startrow int,@pagesize int)
As
SET NOCOUNT ON

/* from the object data source control, the start index is ''0'' and 
the ''ROW_NUMBER()'' sql server function starts with ''1''. 
So we are updating the start index to match with sql server row index
*/
set @startrow = @startrow + 1;

declare @sql nvarchar(4000);

/*
In the sql statement below, using the ''WITH'' statement we are first populating a temporary table,
where we considered the ROW_NUMBER() function to creating ROW_Index. Note that, this is just a declation of the table, no select statement is executed here.
The temprary table is then is used to be qieried according to the row index and recored size, based on which the appropriate segment of recored is being returned.
*/
set @sql=''
		WITH Employees_PageSegment AS ( 
			SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath, 
			ROW_NUMBER() OVER ( ORDER BY '' + @orderby + '' ) as RowIndex
			FROM Employees
		)

		SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath 
		FROM Employees_PageSegment
		WHERE 
		RowIndex BETWEEN '' 
		+  CONVERT(nvarchar(10),@startrow)  
		+ '' AND ('' 
		+ CONVERT(nvarchar(10),@startrow) + '' + '' + CONVERT(nvarchar(10),@pagesize)  
		+ '') - 1  order by '' 
		+ CONVERT(nvarchar(20),@orderby);

exec sp_executesql @sql
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_GetAllEmployees_Paged_Count]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetAllEmployees_Paged_Count]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure returns the total number of records of Employee database table.

Desgin Notes:
This is a supporting stored procedure of Employees_GetAllEmployees_Paged stored procedure,
to faciliitate the paging operation in application end.
*/

CREATE proc [dbo].[Employees_GetAllEmployees_Paged_Count]
As
SET NOCOUNT ON
SELECT COUNT(*) as CountValue from Employees
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Custom_Employees_GetAllEmployeesWithSupervisors]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetAllEmployeesWithSupervisors]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Custom_Employees_GetAllEmployeesWithSupervisors] 
AS
	SET NOCOUNT ON
	SELECT     
	Emp.EmployeeID, 
	Emp.FirstName, 
	Emp.LastName, 
	Supervisors.FirstName as SupervisorFirstName,
	Supervisors.LastName as SupervisorLastName
	
	FROM Employees AS Supervisors INNER JOIN Employees AS Emp ON Supervisors.EmployeeId = Emp.ReportsTo
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Custom_Employees_GetAllTopAndGeneralEmployees]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetAllTopAndGeneralEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Custom_Employees_GetAllTopAndGeneralEmployees] 
AS
SET NOCOUNT ON

-- Get top level employees
SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath
FROM Employees
WHERE ReportsTo is NULL OR EmployeeID = ReportsTo

-- Get general employees
SELECT     
	Emp.EmployeeID, 
	Emp.FirstName, 
	Emp.LastName, 
	Supervisors.FirstName as SupervisorFirstName,
	Supervisors.LastName as SupervisorLastName
	FROM Employees AS Supervisors INNER JOIN Employees AS Emp ON Supervisors.EmployeeId = Emp.ReportsTo
	WHERE Emp.ReportsTo is NOT NULL AND Emp.EmployeeID <> Emp.ReportsTo

	' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Custom_Employees_GetEmployeesByFilterParams]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetEmployeesByFilterParams]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Custom_Employees_GetEmployeesByFilterParams] 
@lastName nvarchar(20), 
@firstName nvarchar(10), 
@city nvarchar(15), 
@region nvarchar(20), 
@country nvarchar(15) 
AS
SET NOCOUNT ON

SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath
FROM Employees
WHERE 
	/*LastName LIKE ''%'' + @lastName + ''%'' AND
	FirstName LIKE ''%'' + @firstName + ''%'' AND
	City LIKE ''%'' + @city + ''%'' AND
	Region LIKE ''%'' + @region + ''%'' AND
	Country LIKE ''%'' + @country + ''%''*/
	Region LIKE ''%'' + @region + ''%'' OR Region IS NULL
	

' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_UpdateEmployee]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_UpdateEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure updated on: 10-Mar-2010

Functional Comment:
This stored procedure updates a record from the Employees database table.

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_UpdateEmployee]
@EmployeeID Int,
@LastName NVarChar(20),
@FirstName NVarChar(10),
@Title NVarChar(30),
@TitleOfCourtesy NVarChar(25),
@BirthDate DateTime,
@HireDate DateTime,
@Address NVarChar(60),
@City NVarChar(15),
@Region NVarChar(15),
@PostalCode NVarChar(10),
@Country NVarChar(15),
@HomePhone NVarChar(24),
@Extension NVarChar(4),
@Photo Image,
@Notes NVarChar(1000),
@ReportsTo Int,
@PhotoPath NVarChar(255)
AS

UPDATE Employees
SET
	LastName	=	@LastName,
	FirstName	=	@FirstName,
	Title		=	@Title,
	TitleOfCourtesy	=	@TitleOfCourtesy,
	BirthDate	=	@BirthDate,
	HireDate	=	@HireDate,
	Address		=	@Address,
	City		=	@City,
	Region		=	@Region,
	PostalCode	=	@PostalCode,
	Country		=	@Country,
	HomePhone	=	@HomePhone,
	Extension=@Extension,
	Photo		=	@Photo,
	Notes		=	@Notes,
	ReportsTo	=	@ReportsTo,
	PhotoPath	=	@PhotoPath
WHERE 
	EmployeeID	=	@EmployeeID
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_GetAllEmployees]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetAllEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure returns all emplyee records from Employee database table.

Desgin Notes:
Since there is not built-in support for array in the SQL Server 2005, we have considered a 
special technique, where the list of Employee Id''s has been passed as XML, based on which the 
Employees are being deleted.
*/

CREATE PROCEDURE [dbo].[Employees_GetAllEmployees]
AS
SET NOCOUNT ON

SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath
FROM Employees
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_DeleteEmployees]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_DeleteEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure updated on: 10-Mar-2010

Functional Comment:
This stored procedure deletes a set of Employees from the Employees database table.

Desgin Notes:
Since there is not built-in support for array in the SQL Server 2005, we have considered a 
special technique, where the list of Employee Id''s has been passed as XML, based on which the 
Employees are being deleted.
*/

CREATE PROCEDURE [dbo].[Employees_DeleteEmployees]
@employeeIds xml 
AS
SET NOCOUNT ON;
delete Employees Where EmployeeID in
(
	SELECT ParamValues.ID.value(''.'',''int'') as Id
	FROM @employeeIds.nodes(''/Id'') as ParamValues(ID) 
)

--COMMIT TRAN -- the count doesn''t works if we set the BEGIN TRAN AND COMMIT TRAN
SELECT @@ROWCOUNT
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_DeleteEmployee]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_DeleteEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Functional Comment:
This stored procedure deletes an record from the Employees database table.

*/

CREATE PROCEDURE [dbo].[Employees_DeleteEmployee]
	@EmployeeID Int
AS
SET NOCOUNT ON
-- Deleting an employee from the database, based on primary key
DELETE Employees
WHERE EmployeeID=@EmployeeID
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_GetEmployeesByReportsTo_Paged_Count]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeesByReportsTo_Paged_Count]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure returns the total number of records of Employee database table, regarding the foreign key Reports to.

Desgin Notes:
This is a supporting stored procedure of Employees_GetAllEmployees_Paged stored procedure,
to faciliitate the paging operation in application end.
*/

CREATE PROC [dbo].[Employees_GetEmployeesByReportsTo_Paged_Count]
@reportsTo INT
As
SET NOCOUNT ON

	SELECT COUNT(*) FROM Employees
	WHERE reportsTo = @ReportsTo


' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_GetEmployeesByReportsTo]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeesByReportsTo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure written on: 08-05-2007

Functional Comment:
This stored procedure returns all employee records from Employee database table, regarding the foreign key ''ReportsTo''.
*/
CREATE PROCEDURE [dbo].[Employees_GetEmployeesByReportsTo]
@reportsTo Int
AS
SET NOCOUNT ON

SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath
	FROM Employees
	WHERE reportsTo = @ReportsTo
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_GetEmployeeByEmployeeId]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeeByEmployeeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure retunrns a record of employee table based on it''''s primary key
*/

CREATE PROCEDURE [dbo].[Employees_GetEmployeeByEmployeeId]
@EmployeeId Int
AS
SET NOCOUNT ON

	SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath
		FROM Employees
		WHERE EmployeeId	=	@EmployeeId
' 
END
/**/
/****** Object:  StoredProcedure [dbo].[Employees_CreateNewEmployee]    Script Date: 03/18/2010 14:51:39 ******/
SET ANSI_NULLS ON
/**/
SET QUOTED_IDENTIFIER ON
/**/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_CreateNewEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [http://www.ashraful.net]
Stored procedure updated on: 10-Mar-2010

Functional Comment:
This stored procedure inserts a new record in the Employees database table.
*/

CREATE PROCEDURE [dbo].[Employees_CreateNewEmployee]
@LastName NVarChar(20),
@FirstName NVarChar(10),
@Title NVarChar(30),
@TitleOfCourtesy NVarChar(25),
@BirthDate DateTime,
@HireDate DateTime,
@Address NVarChar(60),
@City NVarChar(15),
@Region NVarChar(15),
@PostalCode NVarChar(10),
@Country NVarChar(15),
@HomePhone NVarChar(24),
@Extension NVarChar(4),
@Photo Image,
@Notes NVarChar(1000),
@ReportsTo Int,
@PhotoPath NVarChar(255)

AS
SET NOCOUNT ON
-- Inserting a new employee record in the Employee database table
INSERT INTO Employees

(
	LastName,
	FirstName,
	Title,
	TitleOfCourtesy,
	BirthDate,
	HireDate,
	Address,
	City,
	Region,
	PostalCode,
	Country,
	HomePhone,
	Extension,
	Photo,
	Notes,
	ReportsTo,
	PhotoPath
)
VALUES(@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@Photo,@Notes,@ReportsTo,@PhotoPath)

-- returning the newly generated id of the Employee table as the return value
SELECT SCOPE_IDENTITY() AS EmployeeId

' 
END
/**/
/****** Object:  ForeignKey [FK_Employees_Employees]    Script Date: 03/18/2010 14:51:41 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employees_Employees]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employees]'))
ALTER TABLE [dbo].[Employees]  WITH NOCHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([ReportsTo])
REFERENCES [dbo].[Employees] ([EmployeeId])
/**/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employees_Employees]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employees]'))
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
/**/
