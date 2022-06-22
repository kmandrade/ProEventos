using Domain.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEventoService
    {
        Task<IEnumerable<EventoDto>> GetAllEventosDto();
        Task<Result<EventoDto>> GetByIdEventoDto(int idEvento);
        Task<Result<EventoDto>> GetByLoteEventoDto(string nomeEvento);

        Task<Result<CriarEventoDto>> AddEventoDto(CriarEventoDto criarEventoDto);
        Task<Result<CriarEventoDto>> UpdateEventoDto(int idEvento,CriarEventoDto criarEventoDto);
        Task<Result> DeletarEvento(int idEvento);
        Task<Result> ArquivarEvento(int idEvento);
        Task<Result> ReativarEvento(int idEvento);


       
    }
}
