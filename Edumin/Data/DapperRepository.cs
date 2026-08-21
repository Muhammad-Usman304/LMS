using Dapper;

namespace Edumin.Data
{
    public class DapperRepository : IDapperRepository
    {
        private readonly DapperContext _context;

        public DapperRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> ExecuteAsync(string sp, DynamicParameters parameters)
        {
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sp, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, DynamicParameters parameters = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<T>(sp, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sp, DynamicParameters parameters)
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sp, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
