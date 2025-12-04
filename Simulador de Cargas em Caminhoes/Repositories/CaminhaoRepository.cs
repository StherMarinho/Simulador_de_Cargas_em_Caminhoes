using Dapper;
using MySql.Data.MySqlClient;
using Simulador_de_Cargas_em_Caminhoes.DTOs.Caminhao;
using Simulador_de_Cargas_em_Caminhoes.Models;

namespace Simulador_de_Cargas_em_Caminhoes.Repositories
{
    public class CaminhaoRepository
    {
        private readonly IConfiguration _configuration;

        public CaminhaoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string connectionString => _configuration.GetConnectionString("DefaultConnection");

        public List<Caminhao> ObtemCaminhoes()
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                var ret = conexao.Query<Caminhao>("SELECT * FROM Caminhoes").AsList();
                conexao.Close();
                return ret;
            }
        }

        public Caminhao ObtemCaminhao(int id)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                var ret = conexao.Query<Caminhao>("SELECT * FROM Caminhoes WHERE Id = @Id", new { Id = id }).FirstOrDefault();
                conexao.Close();
                return ret;
            }
        }

        public int CriaCaminhao(CriaCaminhaoDTO caminhao)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                int id = conexao.ExecuteScalar<int>(
                    "INSERT INTO Caminhoes (Nome, DistanciaMax, CargaMax) VALUES (@Nome, @DistanciaMax, @CargaMax); SELECT LAST_INSERT_ID();",
                    caminhao
                );
                conexao.Close();
                return id;
            }
        }
    }
}
