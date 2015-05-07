using System;
using TodoApp.Domain.Validation;

namespace TodoApp.Domain.Models
{
    public enum Status
    {
        Pendente = 1,
        Finalizado = 2
    }

    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; }
        public Status Status { get; set; }
        public Usuario CriadoPor { get; set; }

        public Tarefa() { }

        public Tarefa(string titulo, Usuario usuario)
        {
            Titulo = titulo;
            CriadoEm = DateTime.Now;
            Status = Status.Pendente;
            CriadoPor = usuario;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Titulo, "O título não pode ser vazio.", "titulo");
            AssertionConcern.AssertArgumentNotNull(CriadoPor, "O autor da tarefa não pode ser vazio.", "criadoPor");
        }
    }
}
