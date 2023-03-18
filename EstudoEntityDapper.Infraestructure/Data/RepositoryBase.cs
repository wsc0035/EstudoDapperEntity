using Dapper;
using EstudoEntityDapper.Core.Interface;
using System.Data;

namespace EstudoEntityDapper.Infraestructure.Data;

public class RepositoryBase 
{
    protected readonly IApplicationDbContext context;
    public RepositoryBase(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    {
        return await context.Connection.ExecuteAsync(sql, param, transaction);
    }
    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    {
        return (await context.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }
    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    {
        return await context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }
    public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    {
        return await context.Connection.QuerySingleAsync<T>(sql, param, transaction);
    }    
}
