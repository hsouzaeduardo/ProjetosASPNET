using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07_Extra.Infra.Repostiorio
{
    public class RepoSQLDB<T> : IRepo<T> where T : class
    {
        internal readonly Contexto.Contexto _ctx;
        internal readonly DbSet<T> _tabelas;

        public RepoSQLDB(Contexto.Contexto ctx)
        {
            _ctx = ctx;
            _tabelas = _ctx.Set<T>();
        }

        public void Add(T entidade)
        {
            _tabelas.Add(entidade);
            _ctx.SaveChanges();
       }

        public int Count()
        {
            return _tabelas.Count();
            
        }

        public void Delete(T entidade)
        {
            _tabelas.Remove(entidade);
            _ctx.SaveChanges();
        }

        public void Edit(T entidade)
        {
            _tabelas.Update(entidade);
            _ctx.SaveChanges();
        }

        public T Get(Guid id)
        {
            return _tabelas.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _tabelas.ToList();
        }
    }
}
