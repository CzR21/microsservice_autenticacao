using Microsservice_Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuarioPorId(Guid idUsuario);
        Usuario BuscarUsuarioPorEmail(string email);
        Usuario BuscarUsuarioPorEmail(string email, string senha);
        List<Usuario> BuscarUsuarios();
        void AdicionarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);

    }
}
