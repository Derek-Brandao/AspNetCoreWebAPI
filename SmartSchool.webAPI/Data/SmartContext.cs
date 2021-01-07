
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.webAPI.Models;

namespace SmartSchool.webAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Lauro"),
                    new Professor(2, "Roberto"),
                    new Professor(3, "Ronaldo"),
                    new Professor(4, "Rodrigo"),
                    new Professor(5, "Alexandre")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Física", 2),
                    new Disciplina(3, "Português", 3),
                    new Disciplina(4, "Inglês", 4),
                    new Disciplina(5, "Progamação", 5)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Marta", "Kent", "33225555"),
                    new Aluno(2, "Paula", "Isabela", "33225555"),
                    new Aluno(3, "Laura", "Antonia", "33225555"),
                    new Aluno(4, "Luiza", "Maria", "33225555"),
                    new Aluno(5, "Lucas", "Machado", "33225555"),
                    new Aluno(6, "Pedro", "Alvares", "33225555"),
                    new Aluno(7, "Paulo", "José", "33225555")
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina(1, 2),
                    new AlunoDisciplina(1, 4),
                    new AlunoDisciplina(1, 5),
                    new AlunoDisciplina(2, 1),
                    new AlunoDisciplina(2, 2),
                    new AlunoDisciplina(2, 5),
                    new AlunoDisciplina(3, 1),
                    new AlunoDisciplina(3, 2),
                    new AlunoDisciplina(3, 3),
                    new AlunoDisciplina(4, 1),
                    new AlunoDisciplina(4, 4),
                    new AlunoDisciplina(4, 5),
                    new AlunoDisciplina(5, 4),
                    new AlunoDisciplina(5, 5),
                    new AlunoDisciplina(6, 1),
                    new AlunoDisciplina(6, 2),
                    new AlunoDisciplina(6, 3),
                    new AlunoDisciplina(6, 4),
                    new AlunoDisciplina(7, 1),
                    new AlunoDisciplina(7, 2),
                    new AlunoDisciplina(7, 3),
                    new AlunoDisciplina(7, 4),
                    new AlunoDisciplina(7, 5)
                });
        }
    }
}