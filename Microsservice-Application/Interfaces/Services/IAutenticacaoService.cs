using Microsservice_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Services
{
    public interface IAutenticacaoService
    {
        ResponseBaseModel Login(LoginModel model);
        ResponseBaseModel RegistrarUsuario(NewUserModel model);
        ResponseBaseModel ResetarSenhaUsuario(LoginModel model);
    }
}
