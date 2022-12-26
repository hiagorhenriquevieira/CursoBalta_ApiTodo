using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITarefaRepository
    {
         void CriarTarefa(Tarefa pendencia);

         void AtualizarTarefa(Tarefa pendencia);

         Tarefa GetById(Guid Id, string email);
    }
}