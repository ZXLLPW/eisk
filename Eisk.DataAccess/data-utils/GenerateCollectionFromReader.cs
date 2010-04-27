using System.Collections;
using System.Data;

namespace Eisk.DataAccessHelpers
{
    #region GenerateCollectionFromReader Delegate

    /// <summary>
    /// The GenerateCollectionFromReader delegate represents any method which returns a collection from a Data Reader.
    /// Generating data collections [corresponding to dtata table] makes it more usable.
    /// This will return the corresponding data collections, by transforming the passed data reader object
    /// </summary>
    public delegate IList GenerateCollectionFromReader(IDataReader returnData);

    #endregion
}
