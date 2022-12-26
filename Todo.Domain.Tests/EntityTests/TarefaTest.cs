using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TarefaTest
    {
        private readonly Tarefa _tarefa = new Tarefa("Titulo aqui","Hiagor",DateTime.Now);
        [TestMethod]
        public void Dado_uma_nova_tarefa_ela_nao_pode_ser_concluida()
        {
            Assert.AreEqual(_tarefa.Concluido, false);
        }
    }
}