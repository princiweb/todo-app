using System.Linq;
using System.Web.Http;
using TodoApp.Api.Models;
using TodoApp.Domain.Contracts.Services;
using TodoApp.Domain.Models;

namespace TodoApp.Api.Controllers
{
    [Authorize]
    public class TarefasController : ApiController
    {
        private readonly ITarefaService _service;
        private readonly IUsuarioService _usuarioService;

        public TarefasController(ITarefaService service, IUsuarioService usuarioService)
        {
            _service = service;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("usuarios/me/tarefas")]
        public IHttpActionResult ObterTodos(Status? status = null)
        {
            var usuario = _usuarioService.ObterPorId(int.Parse(User.Identity.Name));

            var tarefas = _service.ObterTodas(usuario, status);

            var model = tarefas.Select(TarefaModel.From);

            return Ok(model);
        }

        [HttpPost]
        [Route("usuarios/me/tarefas")]
        public IHttpActionResult Adicionar([FromBody]TarefaModel model)
        {
            var usuario = _usuarioService.ObterPorId(int.Parse(User.Identity.Name));

            var tarefa = _service.Adicionar(model.Titulo, usuario);

            model = TarefaModel.From(tarefa);

            return Ok(model);
        }

        [HttpPut]
        [Route("usuarios/me/tarefas/{id}")]
        public IHttpActionResult Editar(int id, [FromBody]TarefaModel model)
        {
            var usuario = _usuarioService.ObterPorId(int.Parse(User.Identity.Name));

            var tarefa = _service.Editar(id, usuario, model.Titulo, model.Status);

            model = TarefaModel.From(tarefa);

            return Ok(model);
        }

        [HttpDelete]
        [Route("usuarios/me/tarefas/{id}")]
        public IHttpActionResult Deletar(int id)
        {
            var usuario = _usuarioService.ObterPorId(int.Parse(User.Identity.Name));

            _service.Deletar(id, usuario);

            return Ok();
        }
    }
}
