using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo10_01.Data
{
    public class Demo10_01Context : IdentityDbContext
    {
        public Demo10_01Context(DbContextOptions<Demo10_01Context> options)
            : base(options)
        {
        }
       
    }
}
