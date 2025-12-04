namespace Simulador_de_Cargas_em_Caminhoes.DTOs.Carga
{
    public class CriaCargaDTO
    {
        public required double Peso { get; set; }
        public required int DestinoX { get; set; }
        public required int DestinoY { get; set; }
        public required int Prioridade { get; set; }
    }
}
