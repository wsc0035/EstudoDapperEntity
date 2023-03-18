using Microsoft.AspNetCore.Mvc;

namespace EstudoEntityDapper.Controllers;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet]
    private void Get() 
    {
        Response.Redirect("swagger/");
    }
}
