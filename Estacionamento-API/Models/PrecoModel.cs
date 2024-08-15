using System.ComponentModel.DataAnnotations;

namespace Estacionamento_API.Models
{
    public class PrecoModel
    {
        [Key]
        public int Id { get; set; }

        public int PrecoFixo { get; set; }

        public int PrecoHora { get; set; }

        public DateTime PeriodoInicio { get; set; }
        public DateTime? PeriodoFinal { get; set; }
    }
}
