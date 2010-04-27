using System.Text;
using System.Collections.ObjectModel;

namespace Eisk.DataAccessHelpers
{
    public sealed class PrimaryKeyXMLFormatter
    {
        public static string FormatXmlForIdArray<T>(Collection<T> idsToList)
        {
            StringBuilder xmlString = new StringBuilder();

            for (int i = 0; i < idsToList.Count; i++)
            {
                xmlString.AppendFormat("<Id>{0}</Id>", idsToList[i]);
            }

            return xmlString.ToString();
        }
    }

}
