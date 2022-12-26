using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TarefaQueriesTest
    {
        private List<Tarefa> _itens;

        public TarefaQueriesTest()
        {
            _itens = new List<Tarefa>();
            _itens.Add(new Tarefa("Tarefa 1","usuario 1", DateTime.Now));
            _itens.Add(new Tarefa("Tarefa 2","usuario 2", DateTime.Now));
            _itens.Add(new Tarefa("Tarefa 3","hiagor", DateTime.Now));
            _itens.Add(new Tarefa("Tarefa 4","usuario 4", DateTime.Now));
            _itens.Add(new Tarefa("Tarefa 5","hiagor", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_hiagor()
        {
            var result = _itens.AsQueryable().Where(TarefaQueries.GetAll("hiagor"));
            Assert.AreEqual(expected: 2, result.Count());
        }
    }
}