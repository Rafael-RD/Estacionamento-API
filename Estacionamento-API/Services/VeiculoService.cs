using Estacionamento_API.Data;
using Estacionamento_API.Models;
using Estacionamento_API.Models.DTOs;
using Estacionamento_API.Services.Interfaces;

namespace Estacionamento_API.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly DataContext _dataContext;

        public VeiculoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<VeiculoModel?> GetVeiculoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VeiculoModel?> GetVeiculoPorPlaca(string placa)
        {
            throw new NotImplementedException();
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
