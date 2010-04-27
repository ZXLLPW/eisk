using System;
using System.Collections.ObjectModel;
using Eisk.DataAccessHelpers;
using System.Collections.Generic;
using System.Linq;
namespace Eisk.DataAccess
{
    [System.ComponentModel.DataObject(true)]
    public partial class Employee
    {
        #region Entity Framework + LINQ Methods

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Employee GetEmployeeByEmployeeId(int employeeId)
        {
            //Validate Input
            if (employeeId <= EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeId"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (employeeDB.Employees.FirstOrDefault(empObj => empObj.EmployeeId == employeeId));
                //return employeeDB.Employees_GetEmployeeByEmployeeId(employeeId).ToList()[0];
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static List<Employee> GetEmployeesByReportsTo(int? reportsTo)
        {
            //Validate Input
            if (reportsTo == null)
                return GetAllEmployees();
            else if (reportsTo <= Employee.EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("reportsTo"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from employee in employeeDB.Employees 
                        where employee.ReportsTo == reportsTo
                            select employee).ToList();
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static List<Employee> GetEmployeesByReportsToPaged(int? reportsTo, string orderBy, int startRowIndex, int maximumRows)
        {
            //Validate Input
            if (reportsTo == null)
                return GetAllEmployeesPaged(orderBy, startRowIndex, maximumRows);
            else if (reportsTo <= Employee.EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("reportsTo"));

            //If there is no sorting parameter, then by default consider the primary key as the sorting field
            if (string.IsNullOrEmpty(orderBy))
                orderBy = "EmployeeId";

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from employee in employeeDB.Employees
                        where employee.ReportsTo == reportsTo
                        orderby employee.EmployeeId //need a string support
                        select employee).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }

        public static int GetEmployeesByReportsToPagedCount(int? reportsTo, string orderBy, int startRowIndex, int maximumRows)
        {
            //Validate Input
            if (reportsTo == null)
                return GetAllEmployeesPagedCount(orderBy, startRowIndex, maximumRows);
            else if (reportsTo <= Employee.EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("reportsTo"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from employee in employeeDB.Employees
                        where employee.ReportsTo == reportsTo
                        select employee).Count();
            }
        }

        #endregion

        #region Built-in CUD with Stored Procedure Supported Internally

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int CreateNewEmployee(Employee newEmployee)
        {
            // Validate Parameters
            if (newEmployee == null)
                throw (new ArgumentNullException("newEmployee"));


            // Validate Primary key value
            if (newEmployee.EmployeeId > EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("newEmployee"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                employeeDB.AddObject(
                   EntityFrameworkUtility.GetEntitySetFullName(employeeDB, newEmployee), newEmployee);
                employeeDB.SaveChanges();
                //employeeDB.AddToEmployees(newEmployee);
                return newEmployee.EmployeeId;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool UpdateEmployee(Employee updatedEmployee)
        {
            // Validate Parameters
            if (updatedEmployee == null)
                throw (new ArgumentNullException("updatedEmployee"));

            // Validate Primary key value
            if (updatedEmployee.EmployeeId <= EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("updatedEmployee"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                Employee employee = employeeDB.Employees.FirstOrDefault(empObj => empObj.EmployeeId == updatedEmployee.EmployeeId);

                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.HireDate = updatedEmployee.HireDate;
                employee.HomePhone = updatedEmployee.HomePhone;
                employee.Notes = updatedEmployee.Notes;
                employee.Photo = updatedEmployee.Photo;
                employee.PhotoPath = updatedEmployee.PhotoPath;
                employee.PostalCode = updatedEmployee.PostalCode;
                employee.Region = updatedEmployee.Region;
                employee.ReportsTo = updatedEmployee.ReportsTo;
                employee.Title = updatedEmployee.Title;
                employee.TitleOfCourtesy = updatedEmployee.TitleOfCourtesy;
                employee.Address = updatedEmployee.Address;
                employee.BirthDate = updatedEmployee.BirthDate;
                employee.City = updatedEmployee.City;
                employee.Country = updatedEmployee.Country;
                employee.Extension = updatedEmployee.Extension;

                int numberOfAffectedRows = employeeDB.SaveChanges();

                //returns the number of affected rows
                return (numberOfAffectedRows == 0 ? false : true);
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool DeleteEmployee(Employee employeeToBeDeleted)
        {
            //Validate Input
            if (employeeToBeDeleted == null)
                throw (new ArgumentNullException("employeeToBeDeleted"));

            // Validate Primary key value
            if (employeeToBeDeleted.EmployeeId <= EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeToBeDeleted"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                employeeDB.DeleteObject(employeeToBeDeleted);
                int numberOfAffectedRows = employeeDB.SaveChanges();
                return (numberOfAffectedRows == 0 ? false : true);
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public static bool DeleteEmployee(int employeeId)
        {
            //Validate Input
            if (employeeId <= EmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeId"));

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                Employee employee = employeeDB.Employees.FirstOrDefault(empObj => empObj.EmployeeId == employeeId);
                employeeDB.DeleteObject(employee);
                int numberOfAffectedRows = employeeDB.SaveChanges();
                return (numberOfAffectedRows == 0 ? false : true);
            }
        }

        #endregion

        #region Custom Stored Procedure (Function Import) Supported Methods

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public static bool DeleteEmployees(Collection<int> employeesIdsToDelete)
        {
            //Validate Input
            foreach (int employeeId in employeesIdsToDelete)
                if (employeeId <= EmployeeIdMinValue)
                    throw (new ArgumentOutOfRangeException("employeesIdsToDelete"));

            //performing deletion operation //

            string xmlString = PrimaryKeyXMLFormatter.FormatXmlForIdArray(employeesIdsToDelete);

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                int numberOfAffectedRows = (int)employeeDB.Employees_DeleteEmployees(xmlString).ToList()[0];
                return (numberOfAffectedRows == employeesIdsToDelete.Count ? true : false);
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static List<Employee> GetAllEmployees()
        {
            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from e in employeeDB.Employees_GetAllEmployees() select e).ToList();
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static List<Employee> GetAllEmployeesPaged(string orderBy, int startRowIndex, int maximumRows)
        {
            if (string.IsNullOrEmpty(orderBy))
                orderBy = "EmployeeId";

            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from e in employeeDB.Employees_GetAllEmployees_Paged(orderBy, startRowIndex, maximumRows) select e).ToList();
            }
        }

        public static int GetAllEmployeesPagedCount(string orderBy, int startRowIndex, int maximumRows)
        {
            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (int)employeeDB.Employees_GetAllEmployees_Paged_Count().ToList()[0];
            }
        }

        #endregion

        #region Constants and Default Values

        /// <summary>
        /// This property is being used by the crud methods, to validate EmployeeId parameter 
        /// </summary>
        public static int EmployeeIdMinValue
        {
            get { return 0; }
        }

        #endregion

    }//end of Employee class
}
