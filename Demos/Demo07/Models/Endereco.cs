using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo07.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string EnderecoDesc { get; set; }

        public int Numero { get; set; }
        //public virtual Pessoa Pessoa { get; set; }
    }
}
