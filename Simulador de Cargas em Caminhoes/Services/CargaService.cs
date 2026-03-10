using Simulador_de_Cargas_em_Caminhoes.DTOs.Carga;
using Simulador_de_Cargas_em_Caminhoes.Models;
using Simulador_de_Cargas_em_Caminhoes.Repositories;
using System.Collections.Generic;

namespace Simulador_de_Cargas_em_Caminhoes.Services
{
    public class CargaService
    {
        private readonly CargaRepository _cargaRepository;
        private readonly CaminhaoRepository _caminhaoRepository;

        public CargaService(CargaRepository cargaRepository, CaminhaoRepository caminhaoRepository)
        {
            _cargaRepository = cargaRepository;
            _caminhaoRepository = caminhaoRepository;
        }
        public List<Carga> ObtemCargas()
        {
            return _cargaRepository.ObtemCargas();
        }
        public Carga ObtemCarga(int id)
        {
            return _cargaRepository.ObtemCarga(id) ??
                   throw new Exception("Carga não encontrada");
        }

        public int CriarCarga(CriaCargaDTO cargaDto)
        {
            if (cargaDto.Peso <= 0)
                throw new Exception("O peso deve ser maior que zero.");

            if (cargaDto.Prioridade < 1 || cargaDto.Prioridade > 3)
                throw new Exception("A prioridade deve ser entre 1 e 3.");

            return _cargaRepository.CriaCarga(cargaDto);
        }

        public List<Caminhao> DistribuirCargas()
        {
            List<Caminhao> todosCaminhoes = _caminhaoRepository.ObtemCaminhoes()
                                                    .OrderByDescending(c => c.CargaMax)
                                                    .ToList();

            foreach (Caminhao caminhao in todosCaminhoes)
            {
                if (caminhao.CargasAtribuidas == null)
                {
                    caminhao.CargasAtribuidas = new List<Carga>();
                }
            }

            List<Carga> cargasPendentes = _cargaRepository.ObtemCargasPendentes()
                                                  .OrderByDescending(c => c.Prioridade)
                                                  .ThenByDescending(c => c.Peso)
                                                  .ToList();

            List<Carga> naoAtribuidas = new List<Carga>();

            foreach (Carga carga in cargasPendentes)
            {
                var melhorCaminhao = todosCaminhoes
                    .Where(c => c.PodeTransportar(carga.Peso) &&
                                c.PodeChegar(carga.DestinoX, carga.DestinoY))
                    .OrderByDescending(c => c.PesoTotal() + carga.Peso)
                    .FirstOrDefault();

                if (melhorCaminhao != null)
                {
                    carga.CaminhaoId = melhorCaminhao.Id;
                    melhorCaminhao.CargasAtribuidas.Add(carga);
                    _cargaRepository.AtribuirCaminhao(carga.Id, melhorCaminhao.Id);
                }
                else
                {
                    naoAtribuidas.Add(carga);
                }
            }

            return todosCaminhoes;
        }
    }
}
