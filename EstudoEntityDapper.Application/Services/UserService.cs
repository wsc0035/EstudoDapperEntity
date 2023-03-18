using EstudoEntityDapper.Application.DTO;
using EstudoEntityDapper.Application.Interface.Services;
using EstudoEntityDapper.Core.Interface.Repositories;
using EstudoEntityDapper.Infraestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace EstudoEntityDapper.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly DbTesteDataContext _dbTesteContext;

    public UserService(IUserRepository userRepository, DbTesteDataContext dbTesteContext)
    {
        _userRepository = userRepository;
        _dbTesteContext = dbTesteContext;
    }

    public async Task CadastroEvento(EventoUserDTO eventoUserDTO)
    {
        var evento = _dbTesteContext.Evento.Where(i => i.Id == eventoUserDTO.IdEvento).FirstOrDefault();

        if (evento is null)
            throw new Exception("Evento desconhecido");

        if (evento.QtdMax == evento.QtdInscritos)
            throw new Exception("Limite excedido");

        evento.QtdInscritos++;

        _dbTesteContext.Connection.Open();
        using (var transaction = _dbTesteContext.Connection.BeginTransaction())
        {
            try
            {
                _dbTesteContext.Database.UseTransaction(transaction as DbTransaction);

                _dbTesteContext.Update(evento);
                await _dbTesteContext.SaveChangesAsync();

                await _userRepository.CadastroEvento(eventoUserDTO, transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}
