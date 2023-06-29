using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Data.Layer.DA
{
    public class SqlDA : ISqlDA
    {
        private readonly IConfiguration _config;

        public SqlDA(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> GetData<T, P> // read
            (string spName, P parameters,
            string connectionId = "constr") //T is the type of return data & P is the type of parameter
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>
                (spName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T> // create - update - delete
            (string spName, T parameters,
            string connectionId = "constr")
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync
                (spName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
