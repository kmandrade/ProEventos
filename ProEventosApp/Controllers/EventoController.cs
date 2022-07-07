using Data.Context;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.EventoServices;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventosApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IMemoryCache _memoryCache;
        private const string EVENTOS_KEY = "Eventos";
        public EventoController(IEventoService eventoService, IMemoryCache memoryCache)
        {
            _eventoService = eventoService;
            _memoryCache = memoryCache;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEventos()
        {
            //checar se existe essa informação na memoria
            if (_memoryCache.TryGetValue(EVENTOS_KEY,out IEnumerable<EventoDto> eventos))
            {
                return Ok(eventos);
            }
            eventos = await _eventoService.GetAllEventosDto();
            if (eventos == null)
            {
                return BadRequest(new { message = "Nao foi possivel buscar os Eventos" });
            }
            //adicionando um tempo de expiração
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)//se n for acessado em absolute ele entra nesse
            };

            //setando a informação no cach
            _memoryCache.Set(EVENTOS_KEY,eventos,memoryCacheEntryOptions);

            return Ok(eventos);

        }

        [HttpGet("GetEventoById{id}")]
        public async Task<IActionResult> GetEventoById(int id)
        {
            if (id < 0 || id == 0) { return BadRequest(new { message = "Este numero é invalido" }); }
            var resultado = await _eventoService.GetByIdEventoDto(id);
            if (resultado.IsFailed)
            {
                return NotFound(new { message = resultado.ToString() });
            }
            return Ok(resultado.Value);
        }

        [HttpGet("GetByLoteEvento")]
        public async Task<IActionResult> GetByLoteEvento([FromQuery] string nomeLote)
        {
            
            var resultado = await _eventoService.GetByLoteEventoDto(nomeLote);
            if (resultado.IsFailed)
            {
                return NotFound(new { message = resultado.ToString() });
            }
            return Ok(resultado.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvento([FromBody] CriarEventoDto criarEventoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _eventoService.AddEventoDto(criarEventoDto);
            if (resultado.IsFailed)
            {
                return BadRequest(new { message = resultado.ToString() });
            }
            return Ok();
        }

        [HttpPut("ArquivarEvento{id}")]
        public async Task<IActionResult> ArquivarEvento(int id)
        {
            if (id < 0) { return BadRequest(new { message = "Este numero é invalido" }); }
            var resultado = await _eventoService.ArquivarEvento(id);
            if (resultado.IsFailed)
            {
                return NotFound(new { message = resultado.ToString() });
            }
            return Ok();
        }

        [HttpPut("ReativarEvento{id}")]
        public async Task<IActionResult> ReativarEvento(int id)
        {
            if (id < 0 || id==0) { return BadRequest(new { message = "Este numero é invalido" }); }
            var resultado = await _eventoService.ReativarEvento(id);
            if (resultado.IsFailed)
            {
                return NotFound(new { message = resultado.ToString() });
            }
            return Ok();
        }

        [HttpPut("UpdateEvento{id}")]
        public async Task<IActionResult> UpdateEvento(int id, [FromBody] CriarEventoDto criarEventoDto)
        {
            if (id < 0 || id == 0) { return BadRequest(new { message = "Este numero é invalido" }); }
            var resultado = await _eventoService.UpdateEventoDto(id, criarEventoDto);
            if (resultado.IsFailed)
            {
                return BadRequest(new { message = resultado.ToString() });
            }
            return Ok();

        }

        [HttpDelete("DeletarEvento{id}")]
        public async Task<IActionResult> DeletarEvento(int id)
        {
            if (id < 0 || id == 0) { return BadRequest(new { message = "Este numero é invalido" }); }
            var resultado = await _eventoService.DeletarEvento(id);
            if (resultado.IsFailed)
            {
                return BadRequest(new { message = resultado.ToString() });
            }
            return Ok();
        }


    }
}
