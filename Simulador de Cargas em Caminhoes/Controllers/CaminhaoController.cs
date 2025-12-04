using Simulador_de_Cargas_em_Caminhoes.Models;
using Simulador_de_Cargas_em_Caminhoes.Repositories;
using Microsoft.AspNetCore.Mvc;
using Simulador_de_Cargas_em_Caminhoes.DTOs.Caminhao;
using Simulador_de_Cargas_em_Caminhoes.Services;

namespace Simulador_de_Cargas_em_Caminhoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaminhaoController : ControllerBase
    {
        private readonly CaminhaoRepository _caminhaoRepository;
        private readonly CaminhaoService _caminhaoService;

        public CaminhaoController(CaminhaoRepository caminhaoRepository, CaminhaoService caminhaoService)
        {
            _caminhaoRepository = caminhaoRepository;
            _caminhaoService = caminhaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var caminhoes = _caminhaoRepository.ObtemCaminhoes();
                return Ok(caminhoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var caminhao = _caminhaoRepository.ObtemCaminhao(id);
                return Ok(caminhao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriaCaminhaoDTO caminhaoDTO)
        {
            try
            {
                var caminhao = new Caminhao
                {
                    Nome = caminhaoDTO.Nome,
                    DistanciaMax = caminhaoDTO.DistanciaMax,
                    CargaMax = caminhaoDTO.CargaMax
                };

                var id = _caminhaoRepository.CriaCaminhao(caminhaoDTO);
                return Ok(new { id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
