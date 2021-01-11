using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Dtos;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AlunoController(IRepository repo,
                                IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(new AlunoRegistrarDto());
        }

        // api/aluno/byId
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O(A) aluno(a) não foi encontrado(a)");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }

        // api/alunobyId
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno(a) não cadastrado(a)");
        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno(a) não encontrado(a)");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno(a) não atualizado(a)");
        }

        //
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno(a) não encontrado(a)");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno(a) não atualizado(a)");
        }

        //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno(a) não encontrado(a)");
            string sucesso = String.Format("O(A) aluno(a) {0} foi deletado(a) com sucesso!!", aluno.Nome);
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(sucesso);
            }

            return BadRequest("Aluno(a) não deletado(a)");
        }
    }
}