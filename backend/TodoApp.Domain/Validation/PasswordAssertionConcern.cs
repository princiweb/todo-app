using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TodoApp.Domain.Validation
{
    public static class PasswordAssertionConcern
    {
        public static void AssertIsValid(string senha, string param)
        {
            AssertionConcern.AssertArgumentNotNull(senha, "Senha inválida.", param);
            AssertionConcern.AssertArgumentLength(senha, 6, 20, "A senha deve conter entre 6 a 20 caracteres.", param);
        }

        public static string Encrypt(string senha)
        {
            return senha.Encriptar();
        }

        public static string Encriptar(this string senha)
        {
            var pattern = new Regex("[0-9a-f]{64}");

            if (senha == null || pattern.IsMatch(senha))
                return senha;
            else
            {
                var sha256 = new SHA256Managed();

                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

                sha256.Clear();

                var sb = new StringBuilder();

                foreach (var t in hashedBytes)
                    sb.Append(t.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
