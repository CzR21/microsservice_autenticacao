using Microsservice_Application.Interfaces.Repositories;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Enums;
using Microsservice_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MicrosserviceContext _context;

        public UsuarioRepository(MicrosserviceContext context)
        {
            _context = context;
        }

        public Usuario BuscarUsuarioPorId(Guid idUsuario)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == idUsuario && x.TipoStatus == TipoStatus.Ativo);
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()) && x.TipoStatus == TipoStatus.Ativo);
        }

        public Usuario BuscarUsuarioPorEmail(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()) && x.Senha.Equals(senha) && x.TipoStatus == TipoStatus.Ativo);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}
