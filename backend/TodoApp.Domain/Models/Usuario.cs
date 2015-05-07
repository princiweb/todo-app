using TodoApp.Domain.Validation;

namespace TodoApp.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario() { }

        public Usuario(string nome, string email, string senha, string confirmaSenha)
        {
            Nome = nome;
            Email = email;
            AlterarSenha(senha, confirmaSenha);

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Nome, "O nome não pode ser vazio.", "nome");
            AssertionConcern.AssertArgumentNotNull(Email, "O e-mail não pode ser vazio.", "email");
            EmailAssertionConcern.AssertIsValid(Email, "email");
            AssertionConcern.AssertArgumentNotNull(Senha, "A senha não pode ser vazia.", "senha");
        }

        public void AlterarSenha(string senha, string confirmaSenha)
        {
            PasswordAssertionConcern.AssertIsValid(senha, "senha");
            AssertionConcern.AssertArgumentEquals(senha, confirmaSenha, "As senhas informadas não coincidem.", "senha, confirmaSenha");
            
            Senha = PasswordAssertionConcern.Encrypt(senha);
        }
    }
}
