using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Winform_4
{
    public interface IDbService
    {
        int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null);
        Task<int> ExecuteNonQueryAsync(string sql, Dictionary<string, object> parameters = null);
        Task<int> InitializeFileAsync(string fileName, long _totalBytes);
        Task ExecuteProcedureAsync(string procedureName, Dictionary<string, object> parameters = null);
    }
}
