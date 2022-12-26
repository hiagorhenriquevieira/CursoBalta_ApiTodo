using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarcaTarefaConcluidaCommand : Notifiable<Notification>, ICommand
    {
        public MarcaTarefaConcluidaCommand()
        {
        }

        public MarcaTarefaConcluidaCommand(Guid id, string usuario)
        {
            Id = id;
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public string? Usuario { get; set; }
        public void Validar()
        {
            AddNotifications(
                new Contract<MarcaTarefaConcluidaCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Usuario, 6, "User", "O usuario deve conter mais de 6 caracteres.")
            );
        }
    }
}