using Demo10_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo10_Teste.Repository
{
    public class FakeRepository : IRepositorio<Tarefa>
    {
        private static IEnumerable<Tarefa> Dados()
        {
            var tarefas = new List<Tarefa>();
            tarefas.Add(new Tarefa("Task 1", "hsouza", DateTime.Now));
            tarefas.Add(new Tarefa("Task 2", "hsouza", DateTime.Now));
            tarefas.Add(new Tarefa("Task 3", "hsouza", DateTime.Now));
            tarefas.Add(new Tarefa("Task 4", "hsouza", DateTime.Now));
            tarefas.Add(new Tarefa("Task 5", "hsouza", DateTime.Now));
            tarefas.Add(new Tarefa("Task 6", "hsouza", DateTime.Now));
            tarefas.Add(new Tarefa("Task 7", "ozias", DateTime.Now));
            tarefas.Add(new Tarefa("Task 8", "ozias", DateTime.Now));

            return tarefas;
        }

        public IEnumerable<Tarefa> GetAll(string user)
        {
            return Dados().Where(x=> x.Usuario.Equals(user));
        }

        public IEnumerable<Tarefa> GetAllDone(string user)
        {
            return Dados().Where(x => x.Usuario.Equals(user) && x.Concluida.Equals(true));
        }

        public IEnumerable<Tarefa> GetAllUnDone(string user)
        {
            return Dados().Where(x => x.Usuario.Equals(user) && x.Concluida.Equals(false));
        }
    }
}
