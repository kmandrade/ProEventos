using Data.Context;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProEventosApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoContext _context;

        public EventoController(EventoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos.ToList();
            
        }
    }
}
