using Back.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controller;

[ApiController, Route("api/configuracao")]
public class ConfiguracaoController : ControllerBase
{
    private readonly ISetupServices _setupServices;

    public ConfiguracaoController(ISetupServices setupServices)
    {
        _setupServices = setupServices;
    }
    
    [HttpGet, Route("setup")]
    public IActionResult Setup()
    {
        _setupServices.Setup();
        
        return Ok();
    }
    
    
}