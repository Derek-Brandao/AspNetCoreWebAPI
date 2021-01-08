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
    public class DisciplinaController : ControllerBase
    {
        private readonly SmartContext _context;
        public readonly IRepository _repo;

        public DisciplinaController(SmartContext context,
                                IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        // api/disciplina
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Disciplinas);
        }

        // api/disciplina/byId
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var disciplina = _context.Disciplinas.FirstOrDefault(a => a.Id == id);
            if (disciplina == null) return BadRequest("A disciplina não foi encontrada");
            return Ok(disciplina);
        }

        // api/disciplina/byId
        [HttpGet("byNomeOuId")]
        public IActionResult byNomeOuId(string nome, string id)
        {

            var disciplina = _context.Disciplinas.AsEnumerable().Where(a =>
                (a.Nome == nome || a.Id.ToString() == id)
            );
            if (disciplina == null)
            {
                return BadRequest("A disciplina não foi encontrada");
            }
            else
            {
                return Ok(disciplina);
            }
        }

        //
        [HttpPost]
        public IActionResult Post(Disciplina disciplina)
        {
            _repo.Add(disciplina);
            if (_repo.SaveChanges())
            {
            return Ok(disciplina);
            }

            return BadRequest("Disciplina não cadastrada");
        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, Disciplina disciplina)
        {
            var disc = _context.Disciplinas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (disc == null) return BadRequest("Disciplina não encontrada");

            _repo.Update(disciplina);
            if (_repo.SaveChanges())
            {
            return Ok(disciplina);
            }

            return BadRequest("Disciplina não atualizada");
        }

        //
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Disciplina disciplina)
        {
            var disc = _context.Disciplinas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (disc == null) return BadRequest("Disciplina não encontrada");

            _repo.Update(disciplina);
            if (_repo.SaveChanges())
            {
            return Ok(disciplina);
            }

            return BadRequest("Disciplina não atualizada");
        }

        //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var disciplina = _context.Disciplinas.FirstOrDefault(a => a.Id == id);
            if (disciplina == null) return BadRequest("Disciplina não encontrada");
            string sucesso = String.Format("A disciplina {0} foi deletada com sucesso!!", disciplina.Nome);
            _repo.Delete(disciplina);
            if (_repo.SaveChanges())
            {
            return Ok(sucesso);
            }

            return BadRequest("Disciplina não deletada");
        }
    }
}