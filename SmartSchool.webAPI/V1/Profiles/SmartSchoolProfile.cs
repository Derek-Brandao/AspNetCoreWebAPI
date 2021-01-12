using System;
using AutoMapper;
using SmartSchool.webAPI.V1.Dtos;
using SmartSchool.webAPI.Models;
using SmartSchool.webAPI.Helpers;

namespace SmartSchool.webAPI.V1.Profiles
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