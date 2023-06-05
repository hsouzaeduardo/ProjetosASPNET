using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo07.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
