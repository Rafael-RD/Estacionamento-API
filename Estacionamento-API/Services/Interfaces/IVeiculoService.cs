using Estacionamento_API.Models;
using Estacionamento_API.Models.DTOs;

namespace Estacionamento_API.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<VeiculoModel?> GetVeiculoPorId(int id);
        Task<VeiculoModel?> GetVeiculoPorPlaca(string placa);
        Task<IEnumerable<VeiculoModel>> GetVeiculoTodos();
        Task<IEnumerable<VeiculoModel>> GetVeiculoEstacionados();

        Task PostVeiculoEntrada(VeiculoEntradaDTO veiculoEntradaDTO);
        Task PostVeiculoSaida(VeiculoSaidaDTO veiculoSaidaDTO);

        Task PutVeiculo(int id, VeiculoModel veiculo);

        Task DeleteVeiculo(int id);
    }
}
