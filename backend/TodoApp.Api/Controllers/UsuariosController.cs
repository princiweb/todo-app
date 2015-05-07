using System.Web.Http;
using TodoApp.Api.Models;
using TodoApp.Domain.Contracts.Services;

namespace TodoApp.Api.Controllers
{
    [RoutePrefix("usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        public IHttpActionResult Me()
        {
            var usuario = _service.ObterPorId(int.Parse(User.Identity.Name));

            var model = UsuarioPublicoModel.From(usuario);

            return Ok(model);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult ExisteEmail(string email)
        {
            var existe = _service.ExisteEmail(email);

            return Ok(existe);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Adicionar([FromBody]UsuarioModel model)
        {
            var usuario = _service.Adicionar(model.Nome, model.Email, model.Senha, model.ConfirmaSenha);

            return Ok(UsuarioPublicoModel.From(usuario));
        }

        [Authorize]
        [HttpPut]
        [Route("me")]
        public IHttpActionResult Editar([FromBody]UsuarioModel model)
        {
            var id = int.Parse(User.Identity.Name);

            var usuario = _service.Editar(id, model.Nome, model.Email, model.Senha, model.ConfirmaSenha);

            return Ok(UsuarioPublicoModel.From(usuario));
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
