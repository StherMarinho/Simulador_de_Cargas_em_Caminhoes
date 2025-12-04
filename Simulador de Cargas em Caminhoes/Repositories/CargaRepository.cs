using Dapper;
using MySql.Data.MySqlClient;
using Simulador_de_Cargas_em_Caminhoes.DTOs.Carga;
using Simulador_de_Cargas_em_Caminhoes.Models;

namespace Simulador_de_Cargas_em_Caminhoes.Repositories
{
    public class CargaRepository
    {
        private readonly IConfiguration _configuration;

        public CargaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string connectionString => _configuration.GetConnectionString("DefaultConnection");

        public List<Carga> ObtemCargas()
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                var ret = conexao.Query<Carga>("SELECT * FROM Cargas").AsList();
                conexao.Close();
                return ret;
            }
        }

        public Carga ObtemCarga(int id)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                var ret = conexao.Query<Carga>("SELECT * FROM Cargas WHERE Id = @Id", new { Id = id }).FirstOrDefault();
                conexao.Close();
                return ret;
            }
        }

        public int CriaCarga(CriaCargaDTO cargaDto)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                int id = conexao.ExecuteScalar<int>(
                    "INSERT INTO Cargas (Peso, DestinoX, DestinoY, Prioridade) VALUES (@Peso, @DestinoX, @DestinoY, @Prioridade); SELECT LAST_INSERT_ID();",
                    cargaDto
                );
                conexao.Close();
                return id;
            }
        }

        public void AtribuirCaminhao(int cargaId, int caminhaoId)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                conexao.Execute("UPDATE Cargas SET CaminhaoId = @CaminhaoId WHERE Id = @CargaId",
                    new { CaminhaoId = caminhaoId, CargaId = cargaId });
                conexao.Close();
            }
        }

        public List<Carga> ObtemCargasPendentes()
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                var ret = conexao.Query<Carga>("SELECT * FROM Cargas WHERE CaminhaoId IS NULL").AsList();
                conexao.Close();
                return ret;
            }
        }
    }
}
