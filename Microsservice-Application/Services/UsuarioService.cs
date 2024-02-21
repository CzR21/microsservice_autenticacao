using Microsservice_Application.Interfaces.Repositories;
using Microsservice_Application.Interfaces.Services;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Enums;
using Microsservice_Domain.Models;
using Microsservice_Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario BuscarUsuarioPorId(Guid idUsuario)
        {
            return _usuarioRepository.BuscarUsuarioPorId(idUsuario);
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return _usuarioRepository.BuscarUsuarioPorEmail(email);
        }

        public Usuario BuscarUsuarioPorEmail(string email, string senha)
        {
            return _usuarioRepository.BuscarUsuarioPorEmail(email, senha);
        }

        public List<UsuarioModel> BuscarUsuarios()
        {
            List<Usuario> usuarios = _usuarioRepository.BuscarUsuarios();

            if (usuarios.Count() == 0)
            {
                return null;
            }

            var model = usuarios.Select(x => new UsuarioModel()
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Celular = x.Celular,
            }).ToList();

            return model;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.AtualizarUsuario(usuario);
        }

        public void RemoverUsuario(Guid idUsuario, Guid idUser)
        {
            var user = _usuarioRepository.BuscarUsuarioPorId(idUsuario);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.TipoStatus = TipoStatus.Removido;
            user.DataModificacao = DataUtils.GetDateTimeBrasil();
            user.ModificadoPor = idUser;

            _usuarioRepository.AtualizarUsuario(user);
        }
    }
}
