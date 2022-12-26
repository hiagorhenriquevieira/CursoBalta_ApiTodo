using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CriacaoTarefaHandlerTest
    {
        private readonly CriacaoTarefaCommand _commandInvalido = new CriacaoTarefaCommand("","", DateTime.Now);
        private readonly CriacaoTarefaCommand _commandValido = new CriacaoTarefaCommand("Titulo da Tarefa","Hiagor", DateTime.Now);
        private readonly TarefaHandler _handler = new TarefaHandler(new FakeTarefaRepository());
        private GenericoCommandResult _result = new GenericoCommandResult();        

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
           _result = (GenericoCommandResult)_handler.Handle(_commandInvalido);
            Assert.AreEqual(_result.Sucesso, false);
        }

         [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            _result = (GenericoCommandResult)_handler.Handle(_commandValido);
            Assert.AreEqual(_result.Sucesso, true);
        }
    }
}