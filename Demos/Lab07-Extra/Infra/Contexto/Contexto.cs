using Lab07_Extra.Infra.Map;
using Lab07_Extra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Infra.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> op):base(op)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapPessoa();
        }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Curso> cursos { get; set; }

    }
}
