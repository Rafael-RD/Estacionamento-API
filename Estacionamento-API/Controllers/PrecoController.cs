using Estacionamento_API.Models;
using Estacionamento_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrecoController : ControllerBase
    {
        private readonly IPrecoService _precoService;

        public PrecoController(IPrecoService precoService)
        {
            _precoService = precoService;
        }

        [HttpGet]
        public async Task<ActionResult<PrecoModel>> GetPrecoTodos()
        {
            return Ok(await _precoService.GetPrecoTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrecoModel?>> GetPrecoPorId(int id)
        {
            return Ok(await _precoService.GetPrecoPorId(id));
        }
    }
}
