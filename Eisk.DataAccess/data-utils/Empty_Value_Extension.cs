using System;
namespace Eisk.DataAccessHelpers
{
    public static class Empty_Value_Extension
    {
        public static bool IsEmpty(this DateTime dateTimeData)
        {
            return dateTimeData == DateTime.MinValue;
        }

        public static bool IsEmpty(this DateTime? dateTimeData)
        {
            return dateTimeData == DateTime.MinValue;
        }

        public static bool IsEmpty(this string stringData)
        {
            return stringData == string.Empty;
        }

        public static bool IsNull(this string stringData)
        {
            return stringData == null;
        }

        public static bool IsEmpty(this byte[] byteData)
        {
            if (byteData != null)
                return byteData.Length == 0;
            return false;
        }

        public static bool IsEmpty(this int? intData)
        {
            return intData == 0;
        }

    }//end of Employee class
}
