using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CriacaoTarefaCommandTests
    {
        private readonly CriacaoTarefaCommand _commandInvalido = new CriacaoTarefaCommand("","", DateTime.Now);
        private readonly CriacaoTarefaCommand _commandValido = new CriacaoTarefaCommand("Titulo da Tarefa","Hiagor", DateTime.Now);

        public CriacaoTarefaCommandTests()
        {
            _commandInvalido.Validar();
            _commandValido.Validar();
        }

        [TestMethod]
        public void Deve_retornar_falso_quando_commando_for_invalido()
        {
            Assert.AreEqual(_commandInvalido.IsValid, false);
        }

        [TestMethod]
        public void Deve_retornar_verdadeiro_quando_commando_for_valido()
        {
            Assert.AreEqual(_commandValido.IsValid, true);
        }
    }
}