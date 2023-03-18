using System.Data;

namespace EstudoEntityDapper.Core.Interface.Repositories;

public interface IUserRepository
{
    Task<IReadOnlyList<object>> GetAllRoles(int id);
    Task<int> CadastroEvento(object parameters, IDbTransaction transaction = null);
    public IApplicationDbContext Context { get; }
}
