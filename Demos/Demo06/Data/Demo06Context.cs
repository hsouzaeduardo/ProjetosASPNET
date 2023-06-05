using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo06.Models;

namespace Demo06.Data
{
    public class Demo06Context : DbContext
    {
        public Demo06Context (DbContextOptions<Demo06Context> options)
            : base(options)
        {
        }

        public DbSet<Demo06.Models.Pessoa> Pessoa { get; set; }
    }
}
