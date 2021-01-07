using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
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
        public AlunoController() { }
       
        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/byId
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // api/aluno/byId
        [HttpGet("byNomeOuSobrenomeOuTelefoneOuId")]
        public IActionResult GetByNomeOuSobrenome(string nome, string sobrenome, string telefone, string id)
        {    
            var aluno = Alunos.Where(a => 
                a.Nome == nome || a.Sobrenome == sobrenome || a.Telefone == telefone || a.Id.ToString() == id
            );       
            if (aluno == null) {
                return BadRequest("O aluno não foi encontrado");
            }
            else{
                return Ok(aluno);
            }
        }

        //
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(); 
        }
    }
}