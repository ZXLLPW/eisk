using System;
using Eisk.DataAccessHelpers;

namespace Eisk.DataAccess
{
    /*
     * ****************** Design Notes ***************************
     * Handling Special Values: Null, Empty, Un-assigned and Default Values
     * Architecture: Mohammad Ashraful Alam [admin@ashraful.net]
     * 
     * Assigned Null Value Check
     *  * Assigned Null Values are the values that are assigned from caller/UI layer with Null values.
     *  * Typically implemented on required fields, that are string types
     *  * Required data fields that are value type (such as int etc) don't require Null value check, as the fields are set non-nullable (without ? declaration)
     *  * Optional fields don't require Null value check, since Null values are allowed for these fields
     *  * Assuming the caller layer (UI layer) hasn't implemented the validation for required fields.
     * Assigned Empty Value (provided by caller/UI layer) Check
     *  * Assigned Empty Values are the values that are assigned from caller/UI layer, with system default values of data field types.
     *  * Typically implemented on required and optional fields that are string or value type (int etc)
     *  * For required fields, both null and empty values are not permitted in the system
     *  * For optional fields, null values are allowed to the system, but empty values are not permitted in the system
     *  * Assuming the caller layer (UI layer) hasn't implemented the validation for required fields.
     *  * Assuming the caller layer (UI layer) hasn't implemented "pass empty value as null" function for required and optional fields correctly.
     *  Un-assigned Value Check
     *   * Refers to the data fields, which hasn't been bound with any UI controls, thus remained un-assigned and having default system valus of data field types.
     *   * To perform the un-assigned value check, we need to perform the similar operation for property GETTERs as implemented below for propert SEETERs (or alternatively we can use a check method, instead of validation in getter and setter, in that case we have to call the validation method explicitly, before performing any data operation).
     *   * Assuming few data fields of a given data container has not been bound with UI.
     *   * NOT supported in current architecture.
     *  Default Values
     *   * Default values are typically implemented on optional fields (since for required fields we assume user needs to provide data for that)
     *   * Can be implemented for Assigned Empty Value or Un-assigned Values
     *   
     * Special Value Validation Notes:
     *   * Never assume the upper or lower layer is performing validation properly.
     *      * Currently the validation in data access layer protects from wrong data from UI layer
     *      * Currently the validation in data access layer protects from wrong data from data access layer
     *   * Performing validation on caller level (i.e. UI layer, data acess layer) is better, as it reduces network/database roundtrips.
     *   Default Value Notes:
     *    * Never assume the upper or lower layer is filling the default value.
     *    * Filling the default values on caller level (i.e. UI layer, data acess layer) is better, as you may not know which data will be considered as the 'default value'.
     */

    /* ****************** Design Notes ***************************
     * Validation Scopes
     * Architecture: Mohammad Ashraful Alam [admin@ashraful.net]
     * 
     * * Single Row Dependent Validation
     *      * Typically doesn't require database access
     *      (1) Independent Data Field
     *          * Example: required field
     *          * Example: format validation
     *      (2) Dependent Data Fields
     *          * Example: BirthDate can't be greater than HireDate
     * * Multiple Rows Dependent Validation
     *      * Typically requires database access
     *      * Example: An employee can't be supervisor of more than 5 employees.
     *      * Example: More than one employees can't reside under same Addressline
    */

    partial class Employee
    {
        const string nullValueErrorMessage = "Data field is not allowed to be null";
        const string emptyValueErrorMessage = "Data field is not allowed to be empty";

        //primary key, required field
        partial void OnEmployeeIdChanging(global::System.Int32 value)
        {
            if (value == EmployeeIdMinValue) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //required field
        partial void OnLastNameChanging(global::System.String value)
        {
            if (value.IsNull()) throw new InvalidOperationException(nullValueErrorMessage);
            else if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //required field
        partial void OnFirstNameChanging(global::System.String value)
        {
            if (value.IsNull()) throw new InvalidOperationException(nullValueErrorMessage);
            else if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnTitleChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnTitleOfCourtesyChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnBirthDateChanging(global::System.DateTime? value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //required field
        partial void OnHireDateChanging(global::System.DateTime value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //required field
        partial void OnAddressChanging(global::System.String value)
        {
            if (value.IsNull()) throw new InvalidOperationException(nullValueErrorMessage);
            else if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnCityChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnRegionChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnPostalCodeChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //required field
        partial void OnCountryChanging(global::System.String value)
        {
            if (value.IsNull()) throw new InvalidOperationException(nullValueErrorMessage);
            else if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //required field
        partial void OnHomePhoneChanging(global::System.String value)
        {
            if (value.IsNull()) throw new InvalidOperationException(nullValueErrorMessage);
            else if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnExtensionChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnPhotoChanging(global::System.Byte[] value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnNotesChanging(global::System.String value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }

        //optional field
        partial void OnReportsToChanging(global::System.Int32? value)
        {
            if (value.IsEmpty()) throw new InvalidOperationException(emptyValueErrorMessage);
        }
        
        //optional field, with default value
        partial void OnPhotoPathChanged()
        {
            if (PhotoPath.IsEmpty() || PhotoPath.IsNull())
            {
                PhotoPath = "c:\\photos\\";
            }
        }

        //optional field
        partial void OnBirthDateChanged()
        {
            ValidateBirthDateAndHireDate();
        }

        //required field
        partial void OnHireDateChanged()
        {
            ValidateBirthDateAndHireDate();
        }
        
        //validation method
        void ValidateBirthDateAndHireDate()
        {
            if ((BirthDate != null) && (!HireDate.IsEmpty()) && (DateTime.Compare((DateTime)BirthDate, HireDate) >= 0))
                throw new InvalidOperationException("Exception!!! BirthDate should be earlier than HireDate!");
        }
    }
}
