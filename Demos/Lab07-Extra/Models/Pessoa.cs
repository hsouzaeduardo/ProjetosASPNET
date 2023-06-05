using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Models
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
