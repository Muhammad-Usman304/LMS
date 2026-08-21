using Dapper;

namespace Edumin.Data
{
    public interface IDapperRepository
    {
        Task<int> ExecuteAsync(string sp, DynamicParameters parameters);
        Task<T> QueryFirstOrDefaultAsync<T>(string sp, DynamicParameters parameters);
        Task<IEnumerable<T>> QueryAsync<T>(string sp, DynamicParameters parameters = null);
    }
}
