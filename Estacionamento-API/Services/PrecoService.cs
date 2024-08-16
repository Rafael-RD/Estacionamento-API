using Estacionamento_API.Models;
using Estacionamento_API.Services.Interfaces;

namespace Estacionamento_API.Services
{
    public class PrecoService : IPrecoService
    {
        public Task<PrecoModel?> GetPrecoAtual()
        {
            throw new NotImplementedException();
        }

        public Task<PrecoModel?> GetPrecoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PrecoModel>> GetPrecoTodos()
        {
            throw new NotImplementedException();
        }

        public Task PostPreco(PrecoModel preco)
        {
            throw new NotImplementedException();
        }

        public Task PutPreco(int id, PrecoModel preco)
        {
            throw new NotImplementedException();
        }

        public Task DeletePreco(int id)
        {
            throw new NotImplementedException();
        }
    }
}
