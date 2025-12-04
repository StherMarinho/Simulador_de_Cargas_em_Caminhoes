namespace Simulador_de_Cargas_em_Caminhoes.Models
{
    public class Caminhao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double DistanciaMax { get; set; }
        public double CargaMax { get; set; }

        public List<Carga> CargasAtribuidas { get; set; } = new();

        public bool PodeTransportar(double peso)
        {
            return peso + PesoTotal() <= CargaMax;
        }

        public bool PodeChegar(double destinoX, double destinoY)
        {
            double distancia = Math.Sqrt(Math.Pow(destinoX, 2) + Math.Pow(destinoY, 2));
            return distancia <= DistanciaMax;
        }

        public double PesoTotal()
        {
            return CargasAtribuidas.Sum(c => c.Peso);
        }
    }
}
