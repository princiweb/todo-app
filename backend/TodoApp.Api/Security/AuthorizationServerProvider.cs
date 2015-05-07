using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using TodoApp.Domain.Contracts.Services;

namespace TodoApp.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioService _usuarioService;

        public AuthorizationServerProvider(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var usuario = _usuarioService.Autenticar(context.UserName, context.Password);
                
            if (usuario == null)
            {
                context.SetError("invalid_grant", "E-mail ou senha inválidos.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Id.ToString()));

            context.Validated(identity);
        }
    }
}