using Demo10_Dominio;
using Demo10_Teste.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Demo10_Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Quando_Criar_uma_nova_tarefa_ela_esta_pendente()
        {
            //Arange
            Tarefa tarefa = new Tarefa("Tarefa Teste", "hsouza", DateTime.Now);
            //Act
            //Assert
            Assert.AreEqual(tarefa.Concluida, true, "Deveria estar pendente");
        }
        [TestMethod]
        public void Feita_uma_consulta_nas_tarefas_pendentes_usuario_hsouza_retorna_6_tarefas()
        {
            //Arange
            IRepositorio<Tarefa> repo = new FakeRepository();
            string nome = "hsouza";

            //Act
            var tarafas = repo.GetAll(nome).ToList();

            //Assert 
            //retona 6 tarefas
            Assert.AreEqual(tarafas.Count, 6);

            foreach (var item in tarafas)
            {
                item.TarefaConcluida();

                Assert.AreEqual(item.Concluida, false);
            }

        }
    }
}
