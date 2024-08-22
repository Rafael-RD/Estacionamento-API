namespace Estacionamento_API.Models.DTOs
{
    public class VeiculoSaidaPrecoDTO
    {
        public required string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }

        public int PrecoFixo { get; set; }
        public int PrecoHora { get; set; }
        public int APagar { get; set; }
    }
}
