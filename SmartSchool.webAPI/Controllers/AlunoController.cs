using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        // api/aluno/byId
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O(A) aluno(a) não foi encontrado(a)");
            return Ok(aluno);
        }

        // api/alunobyId
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(aluno);
            }

            return BadRequest("Aluno(a) não cadastrado(a)");
        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno(a) não encontrado(a)");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(aluno);
            }

            return BadRequest("Aluno(a) não atualizado(a)");
        }

        //
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno(a) não encontrado(a)");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(aluno);
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