using Simulador_de_Cargas_em_Caminhoes.DTOs.Caminhao;
using Simulador_de_Cargas_em_Caminhoes.Models;
using Simulador_de_Cargas_em_Caminhoes.Repositories;

namespace Simulador_de_Cargas_em_Caminhoes.Services
{
    public class CaminhaoService
    {
        private readonly CaminhaoRepository _caminhaoRepository;

        public CaminhaoService(CaminhaoRepository caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }

        public int RegistrarCaminhao(CriaCaminhaoDTO caminhaoDto)
        {
            if (string.IsNullOrEmpty(caminhaoDto.Nome))
                throw new ArgumentException("Nome do Caminhão não pode ser nulo!");

            if (caminhaoDto.DistanciaMax <= 0)
                throw new Exception("A distância máxima deve ser maior que zero!");

            if (caminhaoDto.CargaMax <= 0)
                throw new Exception("A capacidade máxima deve ser maior que zero!");

            return _caminhaoRepository.CriaCaminhao(caminhaoDto);
        }

        public List<Caminhao> ObterCaminhoesDisponiveis()
        {
            return _caminhaoRepository.ObtemCaminhoes();
        }

        public Caminhao ObterCaminhao(int id)
        {
            return _caminhaoRepository.ObtemCaminhao(id) ?? throw new Exception("Caminhão não encontrado!");
        }
    }
}
