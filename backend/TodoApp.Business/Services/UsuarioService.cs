using System;
using TodoApp.Domain.Contracts.Repositories;
using TodoApp.Domain.Contracts.Services;
using TodoApp.Domain.Models;
using TodoApp.Domain.Validation;

namespace TodoApp.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario ObterPorId(int id)
        {
            var usuario = _repository.ObterPor(x => x.Id == id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            return usuario;
        }

        public bool ExisteEmail(string email)
        {
            return _repository.ObterPor(x => x.Email == email) != null;
        }

        public Usuario Adicionar(string nome, string email, string senha, string confirmaSenha)
        {
            if (ExisteEmail(email))
                throw new ArgumentException("Esse e-mail já está cadastrado.", "email");

            var usuario = new Usuario(nome, email, senha, confirmaSenha);

            usuario.Validate();

            return _repository.Adicionar(usuario);
        }

        public Usuario Editar(int id, string nome, string email, string senha, string confirmaSenha)
        {
            var usuario = ObterPorId(id);

            if (usuario.Email != email && ExisteEmail(email))
                throw new ArgumentException("Esse e-mail já está cadastrado.", "email");

            usuario.Nome = nome;
            usuario.Email = email;

            if (senha != null)
            {
                usuario.AlterarSenha(senha, confirmaSenha);
            }

            usuario.Validate();

            _repository.Atualizar(usuario);

            return usuario;
        }

        public Usuario Autenticar(string email, string senha)
        {
            senha = PasswordAssertionConcern.Encrypt(senha);

            return _repository.ObterPor(x => x.Email == email && x.Senha == senha);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
