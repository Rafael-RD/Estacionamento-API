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
            try
            {
                var veiculo = await _veiculoService.GetVeiculoPorId(id);

                if (veiculo == null) return NotFound("Veiculo não encontrado");

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<VeiculoModel?>> GetVeiculoPorPlaca(string placa)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoPorPlaca(placa);

                if (veiculo == null) return NotFound("Veiculo não encontrado");

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("estacionados")]
        public async Task<ActionResult<IEnumerable<VeiculoModel>>> GetVeiculoEstacionados()
        {
            try
            {
                return Ok(await _veiculoService.GetVeiculoEstacionados());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<VeiculoModel>>> GetVeiculoTodos()
        {
            try
            {
                return Ok(await _veiculoService.GetVeiculoTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("entrada")]
        public async Task<ActionResult<string>> PostVeiculoEntrada(VeiculoEntradaDTO veiculoEntradaDTO)
        {
            try
            {
                await _veiculoService.PostVeiculoEntrada(veiculoEntradaDTO);
                return Ok("Veiculo adicionado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("saida")]
        public async Task<ActionResult<VeiculoSaidaPrecoDTO>> PostVeiculoSaida(VeiculoSaidaDTO veiculoSaidaDTO)
        {
            try
            {
                return Ok(await _veiculoService.PostVeiculoSaida(veiculoSaidaDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutVeiculo(int id, VeiculoModel veiculo)
        {
            try
            {
                await _veiculoService.PutVeiculo(id, veiculo);
                return Ok("Veiculo atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteVeiculo(int id)
        {
            try
            {
                await _veiculoService.DeleteVeiculo(id);
                return Ok("Veiculo deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
