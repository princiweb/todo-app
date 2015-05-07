using System;
using System.Linq;
using System.Linq.Expressions;

namespace TodoApp.Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> ObterTodos();
        T ObterPor(Expression<Func<T, bool>> match);
        void Atualizar(T obj);
        T Adicionar(T obj);
        void Excluir(Expression<Func<T, bool>> match);
    }
}
