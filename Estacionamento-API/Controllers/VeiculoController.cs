using Estacionamento_API.Models;
using Estacionamento_API.Models.DTOs;
using Estacionamento_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estacionamento_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoPorId(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoPorId(id);

            if (veiculo == null) return NotFound("Veiculo não encontrado");

            return Ok(veiculo);
        }

        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<VeiculoModel?>> GetVeiculoPorPlaca(string placa)
        {
            var veiculo = await _veiculoService.GetVeiculoPorPlaca(placa);

            if (veiculo == null) return NotFound("Veiculo não encontrado");

            return Ok(veiculo);
        }

        [HttpGet("estacionados")]
        public async Task<ActionResult<IEnumerable<VeiculoModel>>> GetVeiculoEstacionados()
        {
            return Ok(await _veiculoService.GetVeiculoEstacionados());
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<VeiculoModel>>> GetVeiculoTodos()
        {
            return Ok(await _veiculoService.GetVeiculoTodos());
        }

        [HttpPost("entrada")]
        public async Task<ActionResult<string>> PostVeiculoEntrada(VeiculoEntradaDTO veiculoEntradaDTO)
        {
            await _veiculoService.PostVeiculoEntrada(veiculoEntradaDTO);
            return Ok("Veiculo adicionado");
        }

        [HttpPost("saida")]
        public async Task<ActionResult<VeiculoSaidaPrecoDTO>> PostVeiculoSaida(VeiculoSaidaDTO veiculoSaidaDTO)
        {
            return Ok(await _veiculoService.PostVeiculoSaida(veiculoSaidaDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutVeiculo(int id, VeiculoModel veiculo)
        {
            await _veiculoService.PutVeiculo(id, veiculo);
            return Ok("Veiculo atualizado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteVeiculo(int id)
        {
            await _veiculoService.DeleteVeiculo(id);
            return Ok("Veiculo deletado");
        }
    }
}
