using Demo07.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo07.conrtexto
{
    public class Demo07Contexto : DbContext
    {
        public Demo07Contexto(DbContextOptions<Demo07Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            //modelBuilder.Entity<Pessoa>().Property(x => x.Cpf).HasColumnType("varchar").HasMaxLength(20);
            //modelBuilder.Entity<Pessoa>().Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(5);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
