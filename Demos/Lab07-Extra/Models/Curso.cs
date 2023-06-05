using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Models
{
    public class Curso : BaseEntity
    {
        public string Descricao { get; set; }
    }

    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            DtInclusao = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime DtInclusao { get; set; }
    }
}
