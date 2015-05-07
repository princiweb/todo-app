using Microsoft.Practices.Unity;
using TodoApp.Business.Services;
using TodoApp.Data.Repositories;
using TodoApp.Domain.Contracts.Repositories;
using TodoApp.Domain.Contracts.Services;

namespace TodoApp.Api
{
    public partial class Startup
    {
        public void ResolveDependencies(IUnityContainer container)
        {
            // Repositories
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITarefaRepository, TarefaRepository>(new HierarchicalLifetimeManager());

            // Services
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITarefaService, TarefaService>(new HierarchicalLifetimeManager());
        }
    }
}