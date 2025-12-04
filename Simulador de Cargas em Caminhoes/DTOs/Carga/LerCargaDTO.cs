namespace Simulador_de_Cargas_em_Caminhoes.DTOs.Carga
{
    public class LerCargaDTO
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public int DestinoX { get; set; }
        public int DestinoY { get; set; }
        public string Prioridade { get; set; }
    }
}
