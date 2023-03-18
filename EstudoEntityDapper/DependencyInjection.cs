using EstudoEntityDapper.Application.Interface.Services;
using EstudoEntityDapper.Application.Services;
using EstudoEntityDapper.Core.Interface;
using EstudoEntityDapper.Core.Interface.Repositories;
using EstudoEntityDapper.Infraestructure.DataContext;
using EstudoEntityDapper.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EstudoEntityDapper;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructureInjection(this IServiceCollection service, ConfigurationManager configuration)
    {
        var connString = configuration.GetConnectionString("Teste_Dev");

        service.AddDbContext<DbTesteDataContext>(options => options.UseSqlServer(connString));
        service.AddScoped<IApplicationDbContext>(provider => provider.GetService<DbTesteDataContext>());
        service.AddScoped<IUserRepository>(s => new UserRepository(s.GetService<IApplicationDbContext>()));
        return service;
    }

    public static IServiceCollection AddServiceInjection(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        return service;
    }

}
