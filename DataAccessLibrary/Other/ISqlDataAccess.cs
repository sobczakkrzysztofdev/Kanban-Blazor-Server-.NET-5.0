using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Other
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);

        int SaveDataAndReturnIdentity<T>(string sql, T parameters);
    }
}