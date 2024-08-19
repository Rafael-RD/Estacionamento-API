namespace Estacionamento_API.Models.DTOs
{
    public class VeiculoEntradaDTO
    {
        public string Placa {  get; set; } = string.Empty;

        public DateTime DataEntrada { get; set; }
    }
}
