using Microsservice_Application.Interfaces.Repositories;
using Microsservice_Application.Interfaces.Services;
using Microsservice_Domain.Entites;
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

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.AtualizarUsuario(usuario);
        }
    }
}
