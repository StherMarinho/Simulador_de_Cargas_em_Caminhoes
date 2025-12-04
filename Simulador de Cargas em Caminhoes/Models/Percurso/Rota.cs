namespace Simulador_de_Cargas_em_Caminhoes.Models.Percurso
{
    public class Rota
    {
        public int OrigemX { get; set; }
        public int OrigemY { get; set; }
        public int DestinoX { get; set; }
        public int DestinoY { get; set; }
        public double Distancia { get; set; }
        public Rota(int origemX, int origemY, int destinoX, int destinoY) 
        {
            if (origemX == destinoX && origemY == destinoY)
            {
                throw new ArgumentException("A origem e o destino não podem ser o mesmo ponto.");
            }
            OrigemX = origemX;
            OrigemY = origemY;
            DestinoX = destinoX;
            DestinoY = destinoY;

            Distancia = CalculaDistancia(origemX, origemY,destinoX,destinoY);
        }
        private double CalculaDistancia(int origemX, int origemY, int destinoX, int destinoY)
        {
            return Math.Sqrt(Math.Pow(destinoX - origemX, 2) + Math.Pow(destinoY - origemY, 2));
        }
    }
}
