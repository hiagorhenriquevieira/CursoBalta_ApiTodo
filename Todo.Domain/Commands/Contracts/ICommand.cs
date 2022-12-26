using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace Todo.Domain.Commands.Contracts
{
    public interface ICommand 
    {
        void Validar();
    }
}