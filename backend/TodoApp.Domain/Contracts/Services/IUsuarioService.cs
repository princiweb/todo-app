using System;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Contracts.Services
{
    public interface IUsuarioService : IDisposable
    {
        Usuario ObterPorId(int id);
        bool ExisteEmail(string email);
        Usuario Adicionar(string nome, string email, string senha, string confirmaSenha);
        Usuario Editar(int id, string nome, string email, string senha, string confirmaSenha);
        Usuario Autenticar(string email, string senha);
    }
}
