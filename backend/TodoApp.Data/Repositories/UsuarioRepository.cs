using TodoApp.Data.Context;
using TodoApp.Domain.Contracts.Repositories;
using TodoApp.Domain.Models;

namespace TodoApp.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context)
        {
        }
    }
}
