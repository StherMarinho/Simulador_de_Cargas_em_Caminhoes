namespace Simulador_de_Cargas_em_Caminhoes.Models
{
    public class Carga
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public int DestinoX { get; set; }
        public int DestinoY { get; set; }
        public int Prioridade { get; set; }
        public int CaminhaoId { get; set; }
    }
}
