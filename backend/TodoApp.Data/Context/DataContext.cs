using System;
using System.Collections.Generic;
using System.Data.Entity;
using TodoApp.Data.Mappings;
using TodoApp.Domain.Models;

namespace TodoApp.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ConnDB") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
