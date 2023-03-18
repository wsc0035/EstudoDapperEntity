using EstudoEntityDapper.Application.DTO;

namespace EstudoEntityDapper.Application.Interface.Services;

public interface IUserService
{
    Task CadastroEvento(EventoUserDTO eventoUserDTO);
}
