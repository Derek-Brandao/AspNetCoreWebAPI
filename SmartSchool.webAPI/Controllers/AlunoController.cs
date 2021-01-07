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
        private readonly SmartContext _context;
        public readonly IRepository _repo;

        public AlunoController(SmartContext context,
                                IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        public List<Aluno> Alunos = new List<Aluno>() {
                new Aluno() {
                    Id = 1,
                    Nome = "Marcos",
                    Sobrenome = "Keyon",
                    Telefone = "5151515"
                },
                new Aluno() {
                    Id = 2,
                    Nome = "Marta",
                    Sobrenome = "Joseph",
                    Telefone = "1231546"
                },
                new Aluno() {
                    Id = 3,
                    Nome = "Laura",
                    Sobrenome = "Joseph",
                    Telefone = "38989898"
                },
            };

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // api/aluno/byId
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // api/aluno/byId
        [HttpGet("byNomeOuSobrenomeOuTelefoneOuId")]
        public IActionResult byNomeOuSobrenomeOuTelefoneOuId(string nome, string sobrenome, string telefone, string id)
        {

            var aluno = _context.Alunos.AsEnumerable().Where(a =>
                (a.Nome == nome || a.Sobrenome == sobrenome || a.Telefone == telefone || a.Id.ToString() == id)
            );
            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado");
            }
            else
            {
                return Ok(aluno);
            }
        }

        //
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");
        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");
        }

        //
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");
        }

        //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            string sucesso = String.Format("O aluno {0} foi deletado com sucesso!!", aluno.Nome);
            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
            return Ok(sucesso);
            }

            return BadRequest("Aluno não deletado");
        }
    }
}