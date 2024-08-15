using System.ComponentModel.DataAnnotations;

namespace Estacionamento_API.Models
{
    public class VeiculoModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string Placa { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; } 

        public DateTime? DataSaida { get; set; }
    }
}
