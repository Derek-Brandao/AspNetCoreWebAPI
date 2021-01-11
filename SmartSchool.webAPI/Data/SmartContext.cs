using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});

            builder.Entity<AlunoCurso>()
                .HasKey(AD => new {AD.AlunoId, AD.CursoId});

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, 1, "Lauro", "Oliveira"),
                    new Professor(2, 2, "Roberto", "Soares"),
                    new Professor(3, 3, "Ronaldo", "Marconi"),
                    new Professor(4, 4, "Rodrigo", "Carvalho"),
                    new Professor(5, 5, "Alexandre", "Montanha"),
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>{
                    new Curso(1, "Tecnologia da Informação"),
                    new Curso(2, "Sistemas de Informação"),
                    new Curso(3, "Ciência da Computação")             
                });
            
            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1, 1),
                    new Disciplina(2, "Matemática", 1, 3),
                    new Disciplina(3, "Física", 2, 3),
                    new Disciplina(4, "Português", 3, 1),
                    new Disciplina(5, "Inglês", 4, 1),
                    new Disciplina(6, "Inglês", 4, 2),
                    new Disciplina(7, "Inglês", 4, 3),
                    new Disciplina(8, "Programação", 5, 1),
                    new Disciplina(9, "Programação", 5, 2),
                    new Disciplina(10, "Programação", 5, 3)
                });
            
            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("28/05/2005")),
                    new Aluno(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("28/05/2005")),
                    new Aluno(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("28/05/2005")),
                    new Aluno(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("28/05/2005")),
                    new Aluno(5, 5, "Lucas", "Machado", "565685415", DateTime.Parse("28/05/2005")),
                    new Aluno(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("28/05/2005")),
                    new Aluno(7, 7, "Paulo", "José", "9874512", DateTime.Parse("28/05/2005"))
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina(1,2),
                    new AlunoDisciplina(1,4),
                    new AlunoDisciplina(1,5),
                    new AlunoDisciplina(2,1),
                    new AlunoDisciplina(2,2),
                    new AlunoDisciplina(2,5),
                    new AlunoDisciplina(3,1),
                    new AlunoDisciplina(3,2),
                    new AlunoDisciplina(3,3),
                    new AlunoDisciplina(4,1),
                    new AlunoDisciplina(4,4),
                    new AlunoDisciplina(4,5),
                    new AlunoDisciplina(5,4),
                    new AlunoDisciplina(5,5),
                    new AlunoDisciplina(6,1),
                    new AlunoDisciplina(6,2),
                    new AlunoDisciplina(6,3),
                    new AlunoDisciplina(6,4),
                    new AlunoDisciplina(7,1),
                    new AlunoDisciplina(7,2),
                    new AlunoDisciplina(7,3),
                    new AlunoDisciplina(7,4),
                    new AlunoDisciplina(7,5)
                });
        }
    }
}