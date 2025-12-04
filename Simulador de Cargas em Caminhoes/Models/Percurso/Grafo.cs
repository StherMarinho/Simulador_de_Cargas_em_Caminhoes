namespace Simulador_de_Cargas_em_Caminhoes.Models.Percurso
{
    public class Grafo
    {
        public Dictionary<string, List<(string destino, double distancia)>> Adjacencias { get; set; }

        public Grafo() 
        {
            Adjacencias = new Dictionary<string, List<(string destino, double distancia)>>();
        }
    }
}
