using EstudoEntityDapper.Core.Entities;
using EstudoEntityDapper.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EstudoEntityDapper.Infraestructure.DataContext;

public class DbTesteDataContext : DbContext, IApplicationDbContext
{
    public DbTesteDataContext(DbContextOptions<DbTesteDataContext> options) : base(options) { }
    public IDbConnection Connection => Database.GetDbConnection();
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Evento> Evento { get; set; }
}
