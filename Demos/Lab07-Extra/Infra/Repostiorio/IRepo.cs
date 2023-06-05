using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Infra.Repostiorio
{
    public interface IRepo<T> where T : class
    {
        void Add(T entidade);
        void Edit(T entidade);
        void Delete(T entidade);
        T Get(Guid id);
        IEnumerable<T> Get();
        int Count();
        
    }
}
