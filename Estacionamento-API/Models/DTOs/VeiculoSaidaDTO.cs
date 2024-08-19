namespace Estacionamento_API.Models.DTOs
{
    public class VeiculoSaidaDTO
    {
        public string Placa { get; set; } = string.Empty;

        public DateTime DataSaida { get; set; }
    }
}
