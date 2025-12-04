namespace Simulador_de_Cargas_em_Caminhoes.DTOs.Caminhao
{
    public class CriaCaminhaoDTO
    {
        public required string Nome { get; set; }
        public required double DistanciaMax { get; set; }
        public required double CargaMax { get; set; }
    }
}
