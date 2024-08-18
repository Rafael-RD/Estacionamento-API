﻿using Estacionamento_API.Models;
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
        public Task<IEnumerable<VeiculoModel>> GetVeiculoEstacionados()
        {
            throw new NotImplementedException();
        }

        [HttpGet("todos")]
        public Task<IEnumerable<VeiculoModel>> GetVeiculoTodos()
        {
            throw new NotImplementedException();
        }

        [HttpPost("entrada")]
        public Task PostVeiculoEntrada(VeiculoEntradaDTO veiculoEntradaDTO)
        {
            throw new NotImplementedException();
        }

        [HttpPost("saida")]
        public Task PostVeiculoSaida(VeiculoSaidaDTO veiculoSaidaDTO)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task PutVeiculo(int id, VeiculoModel veiculo)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task DeleteVeiculo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
