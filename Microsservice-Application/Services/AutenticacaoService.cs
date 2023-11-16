using Microsservice_Application.Interfaces.Services;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Models;
using Microsservice_Domain.Security;
using Microsservice_Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoService(ITokenService tokenService, IUsuarioService usuarioService)
        {
            _tokenService = tokenService;
            _usuarioService = usuarioService;
        }

        public ResponseBaseModel Login(LoginModel model, string dispositivo)
        {
            try
            {
                var user = _usuarioService.BuscarUsuarioPorEmail(model.Email);

                if (user == null)
                {
                    return new ResponseBaseModel()
                    {
                        Mensagem = "Usuário não encontrado.",
                        Codigo = 404
                    };
                }

                user = _usuarioService.BuscarUsuarioPorEmail(model.Email, SHA2.GenerateHash(model.Senha));

                if (user == null)
                {
                    return new ResponseBaseModel()
                    {
                        Codigo = 400,
                        Mensagem = "Usuário ou senha invalido!"
                    };
                }

                var token = _tokenService.GenerateToken(user);

                return new ResponseBaseModel()
                {
                    Dados = token,
                    Codigo = 200,
                    Mensagem = "Usuário logado com sucesso!",
                };
            }
            catch (Exception ex)
            {
                return new ResponseBaseModel()
                {
                    Mensagem = "Erro ao logar. " + ex.Message,
                    Codigo = 400
                };
            }
        }

        public ResponseBaseModel RegistrarUsuario(NewUserModel model)
        {
            try
            {
                var usuario = _usuarioService.BuscarUsuarioPorEmail(model.Email);

                if (usuario != null)
                {
                    return new ResponseBaseModel()
                    {
                        Mensagem = "Usuário já registrado!",
                        Codigo = 409
                    };
                }

                var newUser = new Usuario()
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = SHA2.GenerateHash(model.Senha),
                    Celular = model.Celular,
                };

                newUser.CriadoPor = newUser.Id;

                _usuarioService.AdicionarUsuario(newUser);

                return new ResponseBaseModel()
                {
                    Mensagem = "Usuário criado com sucesso",
                    Codigo = 204
                };
            }
            catch (Exception ex)
            {
                return new ResponseBaseModel()
                {
                    Mensagem = "Erro ao cadastrar. " + ex.Message,
                    Codigo = 400
                };
            }
        }

        public ResponseBaseModel ResetarSenhaUsuario(LoginModel model)
        {
            try
            {
                var usuario = _usuarioService.BuscarUsuarioPorEmail(model.Email);

                if (usuario == null)
                {
                    return new ResponseBaseModel()
                    {
                        Mensagem = "Usuário não encontrado!",
                        Codigo = 404
                    };
                }

                usuario.Senha = SHA2.GenerateHash(model.Senha);
                usuario.ModificadoPor = usuario.Id;
                usuario.DataModificacao = DataUtils.GetDateTimeBrasil();

                _usuarioService.AtualizarUsuario(usuario);

                return new ResponseBaseModel()
                {
                    Mensagem = "Senha alterada com sucesso!",
                    Codigo = 204
                };
            }
            catch (Exception ex)
            {
                return new ResponseBaseModel()
                {
                    Mensagem = "Erro ao alterar senha. " + ex.Message,
                    Codigo = 400
                };
            }
        }
    }
}
