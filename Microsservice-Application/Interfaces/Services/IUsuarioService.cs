using Microsservice_Domain.Entites;
using Microsservice_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario BuscarUsuarioPorId(Guid idUsuario);
        Usuario BuscarUsuarioPorEmail(string email);
        Usuario BuscarUsuarioPorEmail(string email, string senha);
        List<UsuarioModel> BuscarUsuarios();
        void AdicionarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);

    }
}
