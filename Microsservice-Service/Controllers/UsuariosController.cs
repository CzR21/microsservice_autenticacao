using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsservice_Application.Interfaces.Services;
using Microsservice_Application.Services;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Models;

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
    }
}
