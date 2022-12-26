using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TarefaHandler : 
    Notifiable<Notification>,
    IHandler<CriacaoTarefaCommand>,
    IHandler<AtualizarTarefaCommand>,
    IHandler<MarcaTarefaConcluidaCommand>,
    IHandler<MarcaTarefaNaoConcluidaCommand>
    {
        private readonly ITarefaRepository _repository;
        
        public TarefaHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CriacaoTarefaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericoCommandResult{
                    Sucesso = false,
                    Mensagem = "Não foi possivel executar a criacao da tarefa",
                    Data = command.Notifications
                };
            }

            var tarefa = new Tarefa(command.Titulo,command.Usuario, command.Data);

            _repository?.CriarTarefa(tarefa);
          
            return new GenericoCommandResult{
                Sucesso = true, 
                Mensagem = "Tarefa criada com sucesso",
                Data = tarefa
            };

        }

        public ICommandResult Handle(AtualizarTarefaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericoCommandResult{
                    Sucesso = false,
                    Mensagem = "Não foi concluir a execução da tarefa",
                    Data = command.Notifications
                };
            }

            var tarefa = _repository.GetById(command.Id, command.Usuario);
           
           tarefa.AtualizarTitulo(command.Titulo);

            _repository.AtualizarTarefa(tarefa);     

            return new GenericoCommandResult{
                Sucesso = true, 
                Mensagem = "Tarefa atualizada com sucesso",
                Data = tarefa
            };
        }

        public ICommandResult Handle(MarcaTarefaConcluidaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericoCommandResult{
                    Sucesso = false,
                    Mensagem = "Não foi possivel executar a atualização da tarefa",
                    Data = command.Notifications
                };
            }

            var tarefa = _repository.GetById(command.Id, command.Usuario);
           
           tarefa.MarcarComoConcluido();

            _repository.AtualizarTarefa(tarefa);     

            return new GenericoCommandResult{
                Sucesso = true, 
                Mensagem = "Tarefa salva",
                Data = tarefa
            };
        }

        public ICommandResult Handle(MarcaTarefaNaoConcluidaCommand command)
        {
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericoCommandResult{
                    Sucesso = false,
                    Mensagem = "Não foi possivel executar atualização da tarefa",
                    Data = command.Notifications
                };
            }

            var tarefa = _repository.GetById(command.Id, command.Usuario);
           
           tarefa.MarcarComoNaoConcluido();

            _repository.AtualizarTarefa(tarefa);     

            return new GenericoCommandResult{
                Sucesso = true, 
                Mensagem = "Tarefa salva",
                Data = tarefa
            };
        }
    }
}