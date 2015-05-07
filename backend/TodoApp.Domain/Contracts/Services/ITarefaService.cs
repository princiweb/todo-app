using System;
using System.Collections.Generic;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Contracts.Services
{
    public interface ITarefaService : IDisposable
    {
        ICollection<Tarefa> ObterTodas(Usuario usuario, Status? status);
        
        Tarefa Adicionar(string titulo, Usuario usuario);

        Tarefa Editar(int id, Usuario usuario, string titulo, Status? status);

        void Deletar(int id, Usuario usuario);
    }
}
