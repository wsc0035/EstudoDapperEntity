using EstudoEntityDapper.Application.DTO;
using EstudoEntityDapper.Application.Interface.Services;
using EstudoEntityDapper.Core.Interface.Repositories;
using EstudoEntityDapper.Infraestructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstudoEntityDapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DbTesteDataContext _dbTesteContext;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    public UserController(DbTesteDataContext dbTesteContext, IUserRepository userRepository, IUserService userService)
    {
        _dbTesteContext = dbTesteContext;
        _userRepository = userRepository;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _dbTesteContext.User.ToListAsync());
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _dbTesteContext.User.Where(i => i.Id == id).ToListAsync());
    }

    [HttpGet]
    [Route("role/{id:int}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var roles = await _userRepository.GetAllRoles(id);
        return Ok(roles);
    }

    [HttpGet]
    [Route("get-connect")]
    public async Task<IActionResult> GetConnection()
    {
        var conEntity = _dbTesteContext.ContextId;
        var conDapper = _userRepository.Context;

        var id = ((DbContext)conDapper).ContextId;

        var a = new
        {
            Entity = conEntity,
            Dapper = id
        };

        return Ok(a);
    }

    [HttpPost]
    [Route("cadastro-evento")]
    public async Task<IActionResult> PostEvento([FromBody] EventoUserDTO eventoUserDTO)
    {
        await _userService.CadastroEvento(eventoUserDTO);
        return Ok();
    }
}
