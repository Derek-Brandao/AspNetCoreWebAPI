using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Data;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(SmartContext context,
                                IRepository repo)
        {
            _repo = repo;
        }

        // api/professor
        [HttpGet]
        public IActionResult Get()
        {   
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        // api/professor/byId
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O(A) professor(a) não foi encontrado(a)");
            return Ok(professor);
        }

        // api/professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
            return Ok(professor);
            }

            return BadRequest("Professor(a) não cadastrado(a)");
        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor(a) não encontrado(a)");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
            return Ok(professor);
            }

            return BadRequest("Professor(a) não atualizado(a)");
        }

        //
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor(a) não encontrado(a)");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
            return Ok(professor);
            }

            return BadRequest("Professor(a) não atualizado(a)");
        }

        //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor(a) não encontrado(a)");
            string sucesso = String.Format("O(A) professor(a) {0} foi deletado(a) com sucesso!!", professor.Nome);
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
            return Ok(sucesso);
            }

            return BadRequest("Professor(a) não deletado(a)");
        }
    }
}