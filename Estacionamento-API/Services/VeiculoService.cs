using Estacionamento_API.Data;
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

        public VeiculoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<VeiculoModel?> GetVeiculoPorId(int id)
        {
            var veiculo = await _dataContext.Veiculos.FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null) return null;

            return veiculo;
        }

        public async Task<VeiculoModel?> GetVeiculoPorPlaca(string placa)
        {
            var veiculo = await _dataContext.Veiculos.LastOrDefaultAsync(v => v.Placa == placa);

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

        public Task PostVeiculoEntrada(VeiculoEntradaDTO veiculoEntradaDTO)
        {
            throw new NotImplementedException();
        }

        public Task PostVeiculoSaida(VeiculoSaidaDTO veiculoSaidaDTO)
        {
            throw new NotImplementedException();
        }

        public Task PutVeiculo(int id, VeiculoModel veiculo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVeiculo(int id)
        {
            throw new NotImplementedException();
        }

        public void VerificarPlaca(string placa)
        {
            bool placaCorreta = Regex.IsMatch(placa, "^[a-zA-Z]{3}[0-9]([0-9]|[a-zA-Z])[0-9]{2}$");

            if (placaCorreta == false) throw new Exception("Placa invalida");

            return;
        }
    }
}
