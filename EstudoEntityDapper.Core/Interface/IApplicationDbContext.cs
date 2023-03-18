using System.Data;

namespace EstudoEntityDapper.Core.Interface;

public interface IApplicationDbContext
{
    public IDbConnection Connection { get; }
}
