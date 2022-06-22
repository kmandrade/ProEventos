using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace ProEventosApp.Profiles
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {

            CreateMap<Evento, EventoDto>()
                .ForMember(dto => dto.Local, opt => opt.MapFrom(evt => evt.Local))
                .ForMember(dto => dto.DataEvento, opt => opt.MapFrom(evt => evt.DataEvento))
                .ForMember(dto => dto.Tema, opt => opt.MapFrom(evt => evt.Tema))
                .ForMember(dto => dto.QtdPessoas, opt => opt.MapFrom(evt => evt.QtdPessoas))
                .ForMember(dto => dto.Lote, opt => opt.MapFrom(evt => evt.Lote))
                .ForMember(dto => dto.ImgURL, opt => opt.MapFrom(evt => evt.ImgURL))
                .ForMember(dto => dto.Situation, opt => opt.MapFrom(evt => evt.Situation));

            CreateMap<CriarEventoDto, Evento>()
                .ForMember(dto => dto.Local, opt => opt.MapFrom(evt => evt.Local))
                .ForMember(dto => dto.DataEvento, opt => opt.MapFrom(evt => evt.DataEvento))
                .ForMember(dto => dto.Tema, opt => opt.MapFrom(evt => evt.Tema))
                .ForMember(dto => dto.QtdPessoas, opt => opt.MapFrom(evt => evt.QtdPessoas))
                .ForMember(dto => dto.Lote, opt => opt.MapFrom(evt => evt.Lote))
                .ForMember(dto => dto.ImgURL, opt => opt.MapFrom(evt => evt.ImgURL));
                
        }
    }
}
