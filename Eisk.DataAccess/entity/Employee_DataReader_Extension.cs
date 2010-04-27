using System.Collections.Generic;
using System;
using System.Data;
namespace Eisk.DataAccess
{
    public static class EmployeeExtension
    {
        public static List<Employee> GetEmployeeCollectionFromReader(this IDataReader returnData)
        {
            List<Employee> colEmployee = new List<Employee>();

            while (returnData.Read())
            {
                Employee newEmployee = new Employee
                {
                    //required
                    EmployeeId = returnData["EmployeeId"] == System.DBNull.Value ? Employee.EmployeeIdMinValue : (Int32)returnData["EmployeeId"],
                    //required
                    LastName = returnData["LastName"] == System.DBNull.Value ? null : (String)returnData["LastName"],
                    //required
                    FirstName = returnData["FirstName"] == System.DBNull.Value ? null : (String)returnData["FirstName"],
                    //optional
                    Title = returnData["Title"] == System.DBNull.Value ? null : (String)returnData["Title"],
                    //optional
                    TitleOfCourtesy = returnData["TitleOfCourtesy"] == System.DBNull.Value ? null : (String)returnData["TitleOfCourtesy"],
                    //optional
                    BirthDate = returnData["BirthDate"] == System.DBNull.Value ? (DateTime?)null : (DateTime)returnData["BirthDate"],
                    //required
                    HireDate = returnData["HireDate"] == System.DBNull.Value ? DateTime.MinValue : (DateTime)returnData["HireDate"],
                    //required
                    Address = returnData["Address"] == System.DBNull.Value ? null : (String)returnData["Address"],
                    //optional
                    City = returnData["City"] == System.DBNull.Value ? null : (String)returnData["City"],
                    //optional
                    Region = returnData["Region"] == System.DBNull.Value ? null : (String)returnData["Region"],
                    //optional
                    PostalCode = returnData["PostalCode"] == System.DBNull.Value ? null : (String)returnData["PostalCode"],
                    //required
                    Country = returnData["Country"] == System.DBNull.Value ? null : (String)returnData["Country"],
                    //required
                    HomePhone = returnData["HomePhone"] == System.DBNull.Value ? null : (String)returnData["HomePhone"],
                    //optional
                    Extension = returnData["Extension"] == System.DBNull.Value ? null : (String)returnData["Extension"],
                    //optional
                    Photo = returnData["Photo"] == System.DBNull.Value ? null : (Byte[])returnData["Photo"],
                    //optional
                    Notes = returnData["Notes"] == System.DBNull.Value ? null : (String)returnData["Notes"],
                    //optional
                    ReportsTo = returnData["ReportsTo"] == System.DBNull.Value ? (Int32?)null : (Int32)returnData["ReportsTo"],
                    //optional
                    PhotoPath = returnData["PhotoPath"] == System.DBNull.Value ? null : (String)returnData["PhotoPath"],
                };

                //adding the Employee to the collection
                colEmployee.Add(newEmployee);
            }

            //returns the collection of Employee objects
            return (colEmployee);
        }

        public static List<EmployeeWithSupervisorName> GetEmployeeWithSupervisorNameCollectionFromReader(this IDataReader returnData)
        {
            List<EmployeeWithSupervisorName> colEmployee = new List<EmployeeWithSupervisorName>();

            while (returnData.Read())
            {
                EmployeeWithSupervisorName newEmployee = new EmployeeWithSupervisorName
                {
                    EmployeeID = returnData["EmployeeId"] == System.DBNull.Value ? 0 : (Int32)returnData["EmployeeId"],
                    FirstName = returnData["FirstName"] == System.DBNull.Value ? null : (String)returnData["FirstName"],
                    LastName = returnData["LastName"] == System.DBNull.Value ? null : (String)returnData["LastName"],
                    SupervisorFirstName = returnData["SupervisorFirstName"] == System.DBNull.Value ? null : (String)returnData["SupervisorFirstName"],
                    SupervisorLastName = returnData["SupervisorLastName"] == System.DBNull.Value ? null : (String)returnData["SupervisorLastName"],
                };

                //adding to the collection
                colEmployee.Add(newEmployee);
            }

            //returns the collection of objects
            return (colEmployee);
        }

    }//end of Employee class
}
