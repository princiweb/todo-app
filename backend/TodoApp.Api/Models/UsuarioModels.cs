using TodoApp.Domain.Models;

namespace TodoApp.Api.Models
{
    public class UsuarioPublicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static UsuarioPublicoModel From(Usuario usuario)
        {
            return new UsuarioPublicoModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }

    public class UsuarioModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}