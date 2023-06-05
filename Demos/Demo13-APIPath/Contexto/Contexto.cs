using Demo13_APIPath.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo13_APIPath.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options):base(options)
        {

        }

        public virtual DbSet<Pessoa> Pessoas { get; set; }
    }
}
