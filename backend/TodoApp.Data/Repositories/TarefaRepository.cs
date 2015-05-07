using System;
using System.Linq;
using System.Linq.Expressions;
using TodoApp.Data.Context;
using TodoApp.Domain.Contracts.Repositories;
using TodoApp.Domain.Models;

namespace TodoApp.Data.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(DataContext context)
            : base(context)
        {
        }

        public new Tarefa ObterPor(Expression<Func<Tarefa, bool>> match)
        {
            return Context.Set<Tarefa>().AsNoTracking().Include("CriadoPor").Where(match).FirstOrDefault();
        }

        public new Tarefa Adicionar(Tarefa tarefa)
        {
            Context.Set<Usuario>().Attach(tarefa.CriadoPor);

            return base.Adicionar(tarefa);
        }
    }
}
