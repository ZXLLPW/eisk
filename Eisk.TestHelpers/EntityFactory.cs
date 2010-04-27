using System;
using Eisk.DataAccess;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public enum EmployeeDataField
    {
        EmployeeId, FirstName, LastName, Title, TitleOfCourtesy, BirthDate,
        HireDate, Address, City, Region, PostalCode, Country, HomePhone,
        Extension, Photo, Notes, ReportsTo, PhotoPath
    }

    /// <summary>
    /// Having a Factory Method for data entity greatly helps of isolate the instance creation of entity classes that are required to be created in the test cases and thus managing the test cases becomes very easy. The TestHelperRoot.EntityFactory provides these helpful stuffs.
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class EntityFactory
    {
        EntityFactory() { }

        struct EmployeeSampleData
        {
            public static int EmployeeId = 0;
            public static string LastName = "Alam";
            public static string FirstName = "Ashraful";
            public static string Title = "Mohammad";
            public static string TitleOfCourtesy = "Mr. ";
            public static DateTime BirthDate = new DateTime(1980, 04, 23);
            public static DateTime HireDate = new DateTime(2007, 05, 16);
            public static string Address = "8/3 Kollyanpur Housing Estate";
            public static string City = "Dhaka";
            public static string Region = "Mirpur";
            public static string PostalCode = "1207";
            public static string Country = "Bangladesh";
            public static string HomePhone = "88-02-9010882";
            public static string Extension = "001";
            public static byte[] Photo = new byte[1] { 0 };
            public static string Notes = "Ashraf is a Microsoft MVP.";
            //public static int ReportsTo = 1;
            public static string PhotoPath = "/photo/";
        }

        public static Employee Factory_CreateFreshEmployeeObjectWithValidSampleData()
        {
            Employee employee = new Employee();

            //------------------------------------

            employee.EmployeeId = EmployeeSampleData.EmployeeId;
            employee.LastName = EmployeeSampleData.LastName;
            employee.FirstName = EmployeeSampleData.FirstName;
            employee.Title = EmployeeSampleData.Title;
            employee.TitleOfCourtesy = EmployeeSampleData.TitleOfCourtesy;
            employee.BirthDate = EmployeeSampleData.BirthDate;
            employee.HireDate = EmployeeSampleData.HireDate;
            employee.Address = EmployeeSampleData.Address;
            employee.City = EmployeeSampleData.City;
            employee.Region = EmployeeSampleData.Region;
            employee.PostalCode = EmployeeSampleData.PostalCode;
            employee.Country = EmployeeSampleData.Country;
            employee.HomePhone = EmployeeSampleData.HomePhone;
            employee.Extension = EmployeeSampleData.Extension;
            employee.Photo = EmployeeSampleData.Photo;
            employee.Notes = EmployeeSampleData.Notes;
            //employee.ReportsTo = EmployeeSampleData.ReportsTo;
            employee.PhotoPath = EmployeeSampleData.PhotoPath;

            //------------------------------------

            return employee;
        }

        public static object Factory_CreateFreshEntityWithValidSampleData(string entityName)
        {
            string methodName = "Factory_CreateFresh" + entityName + "WithValidSampleData";
            return
                ReflectorHelper.StaticCallMethod(typeof(EntityFactory), methodName);
        }

    }

}