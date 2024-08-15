using Estacionamento_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento_API.Data
{
    public class DataContext : DbContext
    {
        public object DbPath { get; }

        public DataContext()
        {
            DbPath = "Estacionamento.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public DbSet<PrecoModel> Precos { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }
    }
}
