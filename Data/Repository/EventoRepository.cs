using Data.Context;
using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EventoRepository : BaseRepository<Evento>,IEventoRepository
    {
        protected readonly DbSet<Evento> _dbSet;

        public EventoRepository(EventoContext _context):base(_context)
        {
            _dbSet = _context.Set<Evento>();
        }

        public async Task<Evento> BuscarEventoPorLote(string nomeLote)
        {
            var query = await _context.Eventos
                .AsNoTracking()
                .Where(ev=>ev.Lote==nomeLote && ev.Situation==Situation.Active)
                .FirstOrDefaultAsync();
            return query;
        }

        public override async Task<IEnumerable<Evento>> GetAll()
        {

            var query = await _context.Eventos
                .AsNoTracking()
                .Where(active => active.Situation == Situation.Active)
                .ToListAsync();
            return query;

        }
        
        
        
    }
}
