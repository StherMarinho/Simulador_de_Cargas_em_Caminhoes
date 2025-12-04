using Microsoft.AspNetCore.Mvc;
using Simulador_de_Cargas_em_Caminhoes.DTOs.Carga;
using Simulador_de_Cargas_em_Caminhoes.Models;
using Simulador_de_Cargas_em_Caminhoes.Repositories;
using Simulador_de_Cargas_em_Caminhoes.Services;

namespace Simulador_de_Cargas_em_Caminhoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargaController : ControllerBase
    {
        private readonly CargaRepository _cargaRepository;
        private readonly CargaService _cargaService;

        public CargaController(CargaRepository cargaRepository, CargaService cargaService)
        {
            _cargaRepository = cargaRepository;
            _cargaService = cargaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cargas = _cargaRepository.ObtemCargas();
                return Ok(cargas);
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
                var carga = _cargaRepository.ObtemCarga(id);
                return Ok(carga);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriaCargaDTO cargaDTO)
        {
            try
            {
                var carga = new Carga { Peso = cargaDTO.Peso, DestinoX = cargaDTO.DestinoX, DestinoY = cargaDTO.DestinoY, Prioridade = cargaDTO.Prioridade };
                var id = _cargaRepository.CriaCarga(cargaDTO);
                return Ok(new { id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CaminhoesAtribuidos")]
        public IActionResult GetCaminhoesComCargas()
        {
            try
            {
                var caminhoes = _cargaService.DistribuirCargas();
                return Ok(caminhoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}