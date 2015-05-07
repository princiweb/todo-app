using System;
using TodoApp.Domain.Models;

namespace TodoApp.Api.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; }
        public Status? Status { get; set; }

        public static TarefaModel From(Tarefa tarefa)
        {
            return new TarefaModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                CriadoEm = tarefa.CriadoEm,
                Status = tarefa.Status
            };
        }
    }
}