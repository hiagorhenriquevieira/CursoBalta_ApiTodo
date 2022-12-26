using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class AtualizarTarefaCommand : Notifiable<Notification>, ICommand
    {
        public AtualizarTarefaCommand()
        {
        }

        public AtualizarTarefaCommand(Guid id, string? titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        public Guid Id { get; set; }

        public string? Titulo { get; set; }

        public string? Usuario { get; set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<AtualizarTarefaCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Titulo, 3, "Titulo", "O titulo deve conter mais de 3 caracteres.")
                .IsGreaterOrEqualsThan(Usuario, 6, "Usuario", "O usuario deve conter mais de 6 caracteres.")
            );
        }
    }
}