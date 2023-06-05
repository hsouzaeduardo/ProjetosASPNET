using Lab07_Extra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Infra.Map
{
    public static class DatabaseMap
    {
        public static void MapPessoa(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("TB_PESSOA").HasKey(x=> x.Id);
            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Nome).HasMaxLength(50).HasColumnType("varchar(50)");


            modelBuilder.Entity<Curso>().ToTable("TB_Curso").HasKey(x => x.Id);
            modelBuilder.Entity<Curso>()
                .Property(x => x.Descricao).HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}
