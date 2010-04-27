==============================================================================
Employee Info Starter Kit (v4.0.0)

Design, Architecture and Implementation: Mohammad Ashraful Alam, Microsoft MVP, ASP.NET [ 2007-2010 ], Portfolio: http://www.ashraful.net, 
Feedback email: admin@ashraful.net

==============================================================================
This page contains a brief overview of this starter kit. 

For more information and quick start tutorials, please check: http://eisk.codeplex.com/documentation
==============================================================================

Employee Info Starter Kit is a ASP.NET based web application, which includes very simple user requirements, where we can create, read, update and delete (CRUD) the employee info of a company. Based on just a database table, it explores and solves most of the major problems in web development architectural space.

This open source starter kit extensively uses major features available in latest Visual Studio, ASP.NET and Sql Server to make robust, scalable, secured and maintainable web applications quickly and easily.

Minimum System Requirements

    * Visual Studio 2010 (RC or higher)
    * Sql Server 2005 (Express Edition) or higher

User End Functional Specification

The user end functionalities of this starter kit are pretty simple and straight forward that are focused in to perform CRUD operation on employee records as described below.

Creating a new employee record
The users should be able to create new employee record, one at a single time.
Read existing employee record
The users should be able to view the employee records in list style, where maximum 10 records can be visible per page and the list can be filtered out based on their supervisors. The user should also be able to view employee records with details, once at a single time and can print it in a printable format.
Update an existing employee record
The users should be able to update an existing employee record, one at a single time.
Delete existing employee records
The users should be able to delete single or multiple employees at a time while viewing employee records in list style.

Architectural Overview

    * Simple 2 layer architecture (user interface and data access layer) with 1 optional cache layer
    * ASP.NET Web Form based user interface
    * Custom Entity Data Container implemented (with primitive C# types for data fields)
    * Active Record Design Pattern based Data Access Layer, implemented in C# and Entity Framework 4.0
    * Sql Server Stored Procedure to perform actual CRUD operation
    * Standard infrastructure (architecture, helper utility) for automated integration (bottom up manner) and unit testing

Technology Utilized

Programming Languages/Scripts

    * Browser side: JavaScript
    * Web server side: C# 4.0
    * Database server side: T-SQL

.NET Framework Components

    * .NET 4.0 Entity Framework
    * .NET 4.0 Optional/Named Parameters
    * .NET 4.0 Tuple
    * .NET 3.0+ Extension Method
    * .NET 3.0+ Lambda Expressions
    * .NET 3.0+ Aanonymous Type
    * .NET 3.0+ Query Expressions
    * .NET 3.0+ Automatically Implemented Properties
    * .NET 3.0+ LINQ
    * .NET 2.0+ Partial Classes
    * .NET 2.0+ Generic Type
    * .NET 2.0+ Nullable Type
    * ASP.NET 3.5+ List View (TBD)
    * ASP.NET 3.5+ Data Pager (TBD)
    * ASP.NET 2.0+ Grid View
    * ASP.NET 2.0+ Form View
    * ASP.NET 2.0+ Skin
    * ASP.NET 2.0+ Theme
    * ASP.NET 2.0+ Master Page
    * ASP.NET 2.0+ Object Data Source
    * ASP.NET 1.0+ Role Based Security

Visual Studio Features

    * Visual Studio 2010 CodedUI Test
    * Visual Studio 2010 Layer Diagram
    * Visual Studio 2010 Sequence Diagram
    * Visual Studio 2010 Directed Graph
    * Visual Studio 2005+ Database Unit Test
    * Visual Studio 2005+ Unit Test
    * Visual Studio 2005+ Web Test
    * Visual Studio 2005+ Load Test

Sql Server Features

    * Sql Server 2005 Stored Procedure
    * Sql Server 2005 Xml type
    * Sql Server 2005 Paging support

Design and Implementation Tricks and Techniques

Design Patterns

	* Active Record Pattern
	* Proxy Pattern
	* Factory Method Pattern

==============================================================================