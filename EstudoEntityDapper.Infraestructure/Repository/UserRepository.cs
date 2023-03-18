using EstudoEntityDapper.Core.Interface;
using EstudoEntityDapper.Core.Interface.Repositories;
using EstudoEntityDapper.Infraestructure.Data;
using System.Data;

namespace EstudoEntityDapper.Infraestructure.Repository;

public class UserRepository : RepositoryBase, IUserRepository
{
    public IApplicationDbContext Context { get; }

    public UserRepository(IApplicationDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<IReadOnlyList<object>> GetAllRoles(int id)
    {
        var query = @"SELECT [roleName]
                        FROM   [role] r
                               INNER JOIN userrole ur
                                       ON r.id = ur.idrole
                        WHERE  ur.iduser = @p_id ";

        return await QueryAsync<object>(query, new { p_id = id });
    }

    public async Task<int> CadastroEvento(object parameters, IDbTransaction transaction = null)
    {
        var query = @" INSERT INTO [dbo].[EventoUser]
                                       ([IdEvento]
                                       ,[IdUser]
                                       ,[DataCadastro])
                                 VALUES 
                                       (@IdEvento
                                       ,@IdUser
                                       ,GETDATE())  ";
        return await ExecuteAsync(query, parameters, transaction);
    }
}
