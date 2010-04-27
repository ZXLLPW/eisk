using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;
using System.Data.EntityClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Eisk.DataAccessHelpers;
namespace Eisk.DataAccess
{
    public partial class Employee
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static List<Employee> GetEmployeesByFilterParams(string lastName = "", 
            string firstName = "",string country = "", 
            string city = "", string region = "")
        {
            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from e in employeeDB.Custom_Employees_GetEmployeesByFilterParams
                        (city: city, firstName: firstName, lastName: lastName, country: country, region: region)
                        select e).ToList();
            }
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static List<EmployeeWithSupervisorName> GetAllEmployeesWithSupervisors()
        {
            using (EmployeeDB employeeDB = new EmployeeDB())
            {
                return (from e in employeeDB.Custom_Employees_GetAllEmployeesWithSupervisors() select e).ToList();
            }
        }

        public static Tuple<List<Employee>, List<EmployeeWithSupervisorName>> GetAllTopAndGeneralEmployees()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringManager.DefaultDBConnectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Custom_Employees_GetAllTopAndGeneralEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                IDataReader dataReader = cmd.ExecuteReader();

                List<Employee> topEmployees = dataReader.GetEmployeeCollectionFromReader();
                dataReader.NextResult();
                List<EmployeeWithSupervisorName> generalEmployees = dataReader.GetEmployeeWithSupervisorNameCollectionFromReader();

                return new Tuple<List<Employee>, List<EmployeeWithSupervisorName>>(topEmployees, generalEmployees);
            }
        }

    }//end of Employee class
}
