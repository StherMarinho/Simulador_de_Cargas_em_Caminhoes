using Microsoft.AspNetCore.Mvc;
using Simulador_de_Cargas_em_Caminhoes.DTOs.Carga;
using Simulador_de_Cargas_em_Caminhoes.Models;
using Simulador_de_Cargas_em_Caminhoes.Services;

namespace Simulador_de_Cargas_em_Caminhoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargaController : ControllerBase
    {
        private readonly CargaService _cargaService;

        public CargaController(CargaService cargaService)
        {
            _cargaService = cargaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cargas = _cargaService.ObtemCargas();
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
                var carga = _cargaService.ObtemCarga(id);
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
                var id = _cargaService.CriarCarga(cargaDTO);
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