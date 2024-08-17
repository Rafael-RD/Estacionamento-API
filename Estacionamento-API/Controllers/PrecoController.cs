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

        [HttpGet("Todos")]
        public async Task<ActionResult<PrecoModel>> GetPrecoTodos()
        {
            return Ok(await _precoService.GetPrecoTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrecoModel?>> GetPrecoPorId(int id)
        {
            var preco = await _precoService.GetPrecoPorId(id);
            
            if (preco == null) return NotFound("Preco não encontrado");
            
            return Ok(preco);
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostPreco(PrecoModel requisicao)
        {
            await _precoService.PostPreco(requisicao);
            return Ok("Preço criado com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutPreco(int id, PrecoModel requisicao)
        {
            await _precoService.PutPreco(id, requisicao);
            return Ok("Preço alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePreco(int id)
        {
            await _precoService.DeletePreco(id);
            return Ok("Preço deletado com sucesso");
        }
    }
}
