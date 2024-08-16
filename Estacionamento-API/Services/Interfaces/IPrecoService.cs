using Estacionamento_API.Models;

namespace Estacionamento_API.Services.Interfaces
{
    public interface IPrecoService
    {
        Task<PrecoModel?> GetPrecoAtual();
        Task<IEnumerable<PrecoModel>> GetPrecoTodos();
        Task<PrecoModel?> GetPrecoPorId(int id);

        Task PostPreco(PrecoModel preco);

        Task PutPreco(int id, PrecoModel preco);

        Task DeletePreco(int id);
    }
}
