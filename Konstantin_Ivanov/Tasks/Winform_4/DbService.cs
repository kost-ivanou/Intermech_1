using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Winform_4
{

    public class DbService : IDbService
    {
        private readonly string _connectionString;
        private readonly AppDbContext _appDbContext;

        public DbService(string connectionString)
        {
            _connectionString = connectionString;
            _appDbContext = new AppDbContext(connectionString);
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> InitializeFileAsync(string fileName, long totalBytes)
        {
            var file = new FileEntity
            {
                FileName = fileName,
                TotalBytes = totalBytes,
                UploadedBytes = 0,
                Status = "Начато"
            };

            _appDbContext.Files.Add(file);
            await _appDbContext.SaveChangesAsync();

            return file.Id;
        }

        public async Task ExecuteProcedureAsync(string procedureName, Dictionary<string, object> parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var cmd = new MySqlCommand(procedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
