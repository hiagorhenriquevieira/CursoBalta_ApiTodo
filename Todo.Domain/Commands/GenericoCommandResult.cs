using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericoCommandResult : ICommandResult
    {
        public bool Sucesso { get; set; } 
        public string? Mensagem { get; set; }
        public object? Data { get; set; }
    }
}