using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class CriacaoTarefaCommand : Notifiable<Notification>, ICommand
    {
        public CriacaoTarefaCommand(string titulo, string usuario, DateTime data)
        {
            Titulo = titulo;
            Usuario = usuario;
            Data = data;
        }

        public string Titulo { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get;set;}

        public void Validar()
        {
            AddNotifications(
                new Contract<CriacaoTarefaCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Titulo, 3, "Titulo", "O titulo deve conter mais de 3 caracteres.")
                .IsGreaterOrEqualsThan(Usuario, 6, "Usuario", "O usuario deve conter mais de 6 caracteres.")
            
            );
        }
    }
}