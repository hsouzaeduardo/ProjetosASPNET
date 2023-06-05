using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo10_Dominio
{
    public interface IRepositorio<T> where T: Tarefa
    {
        IEnumerable<T> GetAll(string user);
        IEnumerable<T> GetAllDone(string user);
        IEnumerable<T> GetAllUnDone(string user);
    }
}
