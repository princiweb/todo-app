using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TodoApp.Data.Context;
using TodoApp.Domain.Contracts.Repositories;

namespace TodoApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext Context;

        protected Repository(DataContext context)
        {
            Context = context;
        }

        public IQueryable<T> ObterTodos()
        {
            return Context.Set<T>();
        }

        public T ObterPor(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().AsNoTracking().Where(match).FirstOrDefault();
        }

        public void Atualizar(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public T Adicionar(T obj)
        {
            Context.Set<T>().Add(obj);
            Context.SaveChanges();

            return obj;
        }

        public void Excluir(Expression<Func<T, bool>> match)
        {
            Context.Set<T>()
                .Where(match).ToList()
                .ForEach(del => Context.Set<T>().Remove(del));
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
