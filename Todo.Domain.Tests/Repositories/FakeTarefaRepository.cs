using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTarefaRepository : ITarefaRepository
    {
        public void AtualizarTarefa(Tarefa pendencia)
        {

        }

        public void CriarTarefa(Tarefa pendencia)
        {

        }

        public Tarefa GetById(Guid Id, string email)
        {
         return new Tarefa("Titulo aqui","Hiagor", DateTime.Now);
        }
    }
}