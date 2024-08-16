﻿using Estacionamento_API.Data;
using Estacionamento_API.Models;
using Estacionamento_API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento_API.Services
{
    public class PrecoService : IPrecoService
    {
        private readonly DataContext _dataContext;

        public PrecoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<PrecoModel?> GetPrecoAtual()
        {
            var Preco = await _dataContext.Precos.OrderBy(p => p.PeriodoInicio).FirstOrDefaultAsync(p => p.PeriodoInicio <= DateTime.Now);

            if (Preco == null)  return null;

            return Preco;
        }

        public async Task<PrecoModel?> GetPrecoPorId(int id)
        {
            var Preco = await _dataContext.Precos.FirstOrDefaultAsync(p => p.Id == id);

            if (Preco == null) return null;

            return Preco;
        }

        public async Task<IEnumerable<PrecoModel>> GetPrecoTodos()
        {
            var Precos = await _dataContext.Precos.OrderBy(p => p.PeriodoInicio).ToListAsync();

            return Precos;
        }

        public async Task PostPreco(PrecoModel preco)
        {
            ValidarPostPreco(preco);

            _dataContext.Precos.Add(preco);
            await _dataContext.SaveChangesAsync();
        }

        public Task PutPreco(int id, PrecoModel preco)
        {
            throw new NotImplementedException();
        }

        public Task DeletePreco(int id)
        {
            throw new NotImplementedException();
        }

        public void ValidarPostPreco(PrecoModel preco)
        {
            if (preco.PrecoFixo >= 0) throw new Exception("Preco Fixo deve ser positivo");
            if (preco.PrecoHora >= 0) throw new Exception("Preco Hora deve ser positivo");

            if (preco.PeriodoInicio == null) throw new Exception("Inicio do periodo não pode ser nulo");
            if (preco.PeriodoFinal == null) throw new Exception("Final do periodo não pode ser nulo");

            if (preco.PeriodoFinal > DateTime.Now) throw new Exception("Final do periodo deve ser no futuro");
            if (preco.PeriodoInicio < preco.PeriodoFinal) throw new Exception("Inicio do periodo deve vir antes do final");
        }
    }
}
