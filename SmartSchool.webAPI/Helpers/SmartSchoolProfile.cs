using System;
using AutoMapper;
using SmartSchool.webAPI.Dtos;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(scr => $"{scr.Nome} {scr.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(scr => scr.DataNasc.GetCurrentAge())
                );

            CreateMap<AlunoDto, Aluno>();
            
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

        }
      
    }
}