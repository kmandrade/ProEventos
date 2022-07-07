using AutoMapper;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using FluentResults;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EventoServices
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        public EventoService(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        


        public async Task<IEnumerable<EventoDto>> GetAllEventosDto()
        {
            //colocar no reposiory somente mostrar os ativos
            var eventos = await _eventoRepository.GetAll();
            //ordenar por Data

            var eventosDto = _mapper.Map<IEnumerable<EventoDto>>(eventos);
                
            return eventosDto;
        }

        public async Task<Result<EventoDto>> GetByIdEventoDto(int idEvento)
        {
            var evento = await _eventoRepository.GetById(idEvento);
            if (evento == null || evento.Situation==Situation.Desactive)
            {
                return Result.Fail("Evento nao encontrado");
            }
            var eventoDto = _mapper.Map<EventoDto>(evento);
            
            return Result.Ok(eventoDto);
        }

        public async Task<Result<EventoDto>> GetByLoteEventoDto(string loteEvento)
        {
            var evento = await _eventoRepository.BuscarEventoPorLote(loteEvento);
            if (evento == null)
            {
                return Result.Fail("Evento nao encontrado");
            }
            var eventoDto = _mapper.Map<EventoDto>(evento);
            return Result.Ok(eventoDto);
        }
        public async Task<Result<CriarEventoDto>> AddEventoDto(CriarEventoDto criarEventoDto)
        {
            var buscarEvento = await _eventoRepository.BuscarEventoPorLote(criarEventoDto.Lote);
            if (buscarEvento != null)
            {
                return Result.Fail("Este Evento já existe");
            }
            var evento = _mapper.Map<Evento>(criarEventoDto);
            evento.Situation = Situation.Active;
            await _eventoRepository.Add(evento);
            return Result.Ok();
        }
        public async Task<Result<CriarEventoDto>> UpdateEventoDto(int idEvento, CriarEventoDto criarEventoDto)
        {
            var evento = await _eventoRepository.GetById(idEvento);
            if (evento == null || evento.Situation == Situation.Desactive)
            {
                return Result.Fail("Evento nao encontrado");
            }
            _mapper.Map(criarEventoDto, evento);
            await _eventoRepository.Save();
            return Result.Ok();
        }

        public async Task<Result> ArquivarEvento(int idEvento)
        {
            var evento = await _eventoRepository.GetById(idEvento);
            if (evento == null || evento.Situation==Situation.Desactive)
            {
                return Result.Fail("Evento nao encontrado");
            }
            evento.Situation = Situation.Desactive;
            await _eventoRepository.Update(evento);
            return Result.Ok();

        }
        public async Task<Result> ReativarEvento(int idEvento)
        {
            var evento = await _eventoRepository.GetById(idEvento);
            if(evento!=null && evento.Situation == Situation.Desactive)
            {
                evento.Situation = Situation.Active;
                await _eventoRepository.Update(evento);
                return Result.Ok();
            }
            return Result.Fail("Evento Nao encontrado ou Nao foi possivel reativar");
        }
        public async Task<Result> DeletarEvento(int idEvento)
        {
            var evento = await _eventoRepository.GetById(idEvento);
            if (evento == null)
            {
                return Result.Fail("Evento Nao encontrado");
            }
            if(evento!=null && evento.Situation == Situation.Active)
            {
                return Result.Fail("Este Evento precisa ser Arquivado");
            }
            await _eventoRepository.DeleteById(idEvento);
            return Result.Ok();
            //oioioio
            /////
        }

    }

}
