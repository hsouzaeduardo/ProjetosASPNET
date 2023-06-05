using System;

namespace Demo10_Dominio
{
    public class Tarefa
    {
        public string Titulo { get; private set; }
        public string Usuario { get; private set; }
        public DateTime DateTime { get; private set; }

        public bool Concluida { get; private set; }

        public Tarefa(string titulo, string usuario, DateTime data)
        {
            Titulo = titulo;
            Usuario = usuario;
            DateTime = data;
        }

        public void TarefaConcluida()
        {
            Concluida = true;
        }

        public void TarefaPendente()
        {
            Concluida = false;
        }
    }
}
