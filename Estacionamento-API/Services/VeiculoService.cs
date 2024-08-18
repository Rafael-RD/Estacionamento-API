using Estacionamento_API.Data;
using Estacionamento_API.Models;
using Estacionamento_API.Models.DTOs;
using Estacionamento_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task<IEnumerable<VeiculoModel>> GetVeiculoEstacionados()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VeiculoModel>> GetVeiculoTodos()
        {
            throw new NotImplementedException();
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
    }
}
