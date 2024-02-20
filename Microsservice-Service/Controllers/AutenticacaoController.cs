using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsservice_Application.Extensions;
using Microsservice_Application.Services;
using Microsservice_Domain.Models;
using System.Security.Claims;

namespace Microsservice_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private IAutenticacaoService _autenticacaoService;
        
        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Resgistrar([FromBody] NewUserModel newUserModel)
        {
            try
            {
                var response = _autenticacaoService.RegistrarUsuario(newUserModel);

                return this.HandleStatusCode(response);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseBaseModel()
                {
                    Mensagem = "Erro ao registrar usuario." + e.Message,
                    Codigo = 400
                });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var response = _autenticacaoService.Login(loginModel);

                return this.HandleStatusCode(response);
                
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseBaseModel()
                { 
                    Mensagem = "Erro no login." + e.Message, 
                    Codigo = 400 
                });
            }
        }
        
        [HttpPost]
        [Authorize]
        [Route("redefinir-senha")]
        public IActionResult ResetarSenha([FromBody] LoginModel model)
        {
            try
            {
                var response = _autenticacaoService.ResetarSenhaUsuario(model);

                return this.HandleStatusCode(response);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseBaseModel()
                {
                    Mensagem = "Erro ao redefinir senha." + e.Message,
                    Codigo = 400
                });
            }
        }
    }
}
