using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class TarefaContext : DbContext
    {
        public TarefaContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tarefa>? Tarefas {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("Tarefa");
            modelBuilder.Entity<Tarefa>().Property(x => x.Id);
            modelBuilder.Entity<Tarefa>().Property(x => x.Usuario).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Tarefa>().Property(x => x.Titulo).HasMaxLength(160).HasColumnType("varcbar(160)");
            modelBuilder.Entity<Tarefa>().Property(x => x.Concluido).HasColumnType("bit");
            modelBuilder.Entity<Tarefa>().Property(x => x.Data);
            modelBuilder.Entity<Tarefa>().HasIndex(b => b.Usuario);
        }
    }
}