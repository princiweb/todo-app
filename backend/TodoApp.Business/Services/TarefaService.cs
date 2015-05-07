using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Domain.Contracts.Repositories;
using TodoApp.Domain.Contracts.Services;
using TodoApp.Domain.Models;

namespace TodoApp.Business.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Tarefa> ObterTodas(Usuario usuario, Status? status)
        {
            return _repository.ObterTodos()
                .Where(x => x.CriadoPor.Id == usuario.Id && x.Status == (status ?? x.Status))
                .OrderByDescending(x => x.CriadoEm)
                .ToList();
        }

        private Tarefa ObterPorId(int id, Usuario usuario)
        {
            var tarefa = _repository.ObterPor(x => x.Id == id && x.CriadoPor.Id == usuario.Id);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            return tarefa;
        }

        public Tarefa Adicionar(string titulo, Usuario usuario)
        {
            var tarefa = new Tarefa(titulo, usuario);

            tarefa.Validate();

            return _repository.Adicionar(tarefa);
        }

        public Tarefa Editar(int id, Usuario usuario, string titulo, Status? status)
        {
            var tarefa = ObterPorId(id, usuario);

            if (titulo == null && status == null)
            {
                throw new ArgumentNullException("titulo, status", "Especifique ao menos um dos parâmetros: título, status.");
            }

            if (titulo != null)
                tarefa.Titulo = titulo;

            if (status != null)
                tarefa.Status = (Status)status;

            tarefa.Validate();

            _repository.Atualizar(tarefa);

            return tarefa;
        }

        public Tarefa AlterarStatus(int id, Usuario usuario, Status status)
        {
            var tarefa = ObterPorId(id, usuario);

            tarefa.Status = status;

            tarefa.Validate();

            _repository.Atualizar(tarefa);

            return tarefa;
        }

        public void Deletar(int id, Usuario usuario)
        {
            _repository.Excluir(x => x.Id == id && x.CriadoPor.Id == usuario.Id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
