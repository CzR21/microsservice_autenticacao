using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsservice_Application.Interfaces.Services;
using Microsservice_Application.Services;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Models;
using Seed_API_Application.Extentions;

namespace Microsservice_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize]
        [Route("buscar-usuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            try
            {
                var usuarios = _usuarioService.BuscarUsuarios();

                if (usuarios == null)
                {
                    return NotFound(new ResponseBaseModel() { Mensagem = "Nnehum usuário encontrado", Codigo = 404 });
                }
                else
                {
                    return Ok(new ResponseBaseModel() { Dados = usuarios, Mensagem = "Usuários encontrados com suscesso", Codigo = 200});
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new ResponseBaseModel() { Mensagem = "Erro ao buscar usuários. " + ex.Message, Codigo = 400 });
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("remover-usuario/{idUsuario}")]
        public async Task<IActionResult> DeletarUsuario(Guid idUsuario)
        {
            try
            {
                var idUser = User.BuscarIdUser();

                _usuarioService.RemoverUsuario(idUsuario, idUser);

                return Ok(new ResponseBaseModel() { Mensagem = "Usuários removido com suscesso", Codigo = 200 });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBaseModel() { Mensagem = "Erro ao remover usuário. " + ex.Message, Codigo = 400 });
            }
        }
    }
}
