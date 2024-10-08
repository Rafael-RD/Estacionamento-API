﻿using Estacionamento_API.Data;
using Estacionamento_API.Models;
using Estacionamento_API.Models.DTOs;
using Estacionamento_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Estacionamento_API.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly DataContext _dataContext;
        private readonly IPrecoService _precoService;

        public VeiculoService(DataContext dataContext, IPrecoService precoService)
        {
            _dataContext = dataContext;
            _precoService = precoService;
        }

        public async Task<VeiculoModel?> GetVeiculoPorId(int id)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null) return null;

            return veiculo;
        }

        public async Task<VeiculoModel?> GetVeiculoPorPlaca(string placa)
        {
            var veiculo = await _dataContext.Veiculos.OrderBy(v => v.Id).LastOrDefaultAsync(v => v.Placa == placa);

            if(veiculo == null) return null;

            return veiculo;
        }

        public async Task<IEnumerable<VeiculoModel>> GetVeiculoEstacionados()
        {
            var veiculos = await _dataContext.Veiculos.Where(v => v.DataSaida == null).ToListAsync();

            return veiculos;
        }

        public async Task<IEnumerable<VeiculoModel>> GetVeiculoTodos()
        {
            var veiculos = await _dataContext.Veiculos.ToListAsync();

            return veiculos;
        }

        public async Task PostVeiculoEntrada(VeiculoEntradaDTO veiculoEntradaDTO)
        {
            VerificarPlaca(veiculoEntradaDTO.Placa);

            VeiculoModel veiculo = new VeiculoModel()
            {
                Placa = veiculoEntradaDTO.Placa,
                DataEntrada = veiculoEntradaDTO.DataEntrada
            };

            _dataContext.Veiculos.Add(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<VeiculoSaidaPrecoDTO> PostVeiculoSaida(VeiculoSaidaDTO veiculoSaidaDTO)
        {
            VerificarPlaca(veiculoSaidaDTO.Placa);

            var veiculo = await GetVeiculoPorPlaca(veiculoSaidaDTO.Placa);

            if (veiculo == null) throw new Exception("Veiculo não encontrado");

            if (veiculo.DataEntrada > veiculoSaidaDTO.DataSaida) throw new Exception("Saida antes da entrada");

            var preco = await _precoService.GetPrecoAtual();

            if (preco == null) throw new Exception("Preço não definido");

            TimeSpan tempoEstacionado = veiculoSaidaDTO.DataSaida.Subtract(veiculo.DataEntrada);

            TimeSpan tempoEstacionadoComTolerancia = tempoEstacionado.TotalMinutes > 10 ?
                tempoEstacionado.Subtract(new TimeSpan(0, 10, 0)) : 
                tempoEstacionado;

            int aPagarHora =((int) Math.Floor(tempoEstacionadoComTolerancia.TotalHours)) * preco.PrecoHora;

            int aPagarTotal = aPagarHora + preco.PrecoFixo; 

            VeiculoSaidaPrecoDTO veiculoSaidaPrecoDTO = new VeiculoSaidaPrecoDTO()
            {
                Placa = veiculo.Placa,
                DataEntrada = veiculo.DataEntrada,
                DataSaida = veiculoSaidaDTO.DataSaida,
                PrecoFixo = preco.PrecoFixo,
                PrecoHora = preco.PrecoHora,
                APagar = aPagarTotal
            };

            veiculo.DataSaida = veiculoSaidaDTO.DataSaida;

            await _dataContext.SaveChangesAsync();

            return veiculoSaidaPrecoDTO;
        }

        public async Task PutVeiculo(int id, VeiculoModel veiculo)
        {
            if (veiculo.Id != id) throw new Exception("Id requisitado diferente do veiculo id");

            if (veiculo.DataEntrada > veiculo.DataSaida) throw new Exception("Saida antes da entrada");

            var veiculoAntigo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id) ?? throw new Exception("Veiculo id não encontrado");

            veiculoAntigo.Placa = veiculo.Placa;
            veiculoAntigo.DataEntrada = veiculo.DataEntrada;
            veiculoAntigo.DataSaida = veiculo.DataSaida;

            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteVeiculo(int id)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id) ?? throw new Exception("Veiculo id não encontrado");

            _dataContext.Veiculos.Remove(veiculo);
            await _dataContext.SaveChangesAsync();
        }

        public void VerificarPlaca(string placa)
        {
            bool placaCorreta = Regex.IsMatch(placa, "^[a-zA-Z]{3}[0-9]([0-9]|[a-zA-Z])[0-9]{2}$");

            if (placaCorreta == false) throw new Exception("Placa invalida");

            return;
        }
    }
}
