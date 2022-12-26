using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using  Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TarefaQueries
    {
        
        public static Expression<Func<Tarefa, bool>> GetAllUndone(string usuario)
        {
            return x => 
            x.Usuario == usuario &&
            x.Concluido == false;
        }

        public static Expression<Func<Tarefa, bool>> GetAllDone(string usuario)
        {
            return x => 
            x.Usuario == usuario &&
            x.Concluido == true;
        }

        public static Expression<Func<Tarefa, bool>> GetAll(string usuario)
        {
            return x => 
            x.Usuario == usuario;
        }

        public static Expression<Func<Tarefa, bool>> GetByPeriod(string usuario, DateTime data, bool concluido)
        {
            return x =>
            x.Usuario == usuario &&
            x.Concluido == concluido &&
            x.Data == data;
        }
    }
}