using Microsservice_Domain.Entites;
using Microsservice_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Services
{
    public interface ITokenService
    {
        TokenResponseModel GenerateToken(Usuario usuario);
    }
}
