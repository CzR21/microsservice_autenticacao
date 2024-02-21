using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seed_API_Application.Extentions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid BuscarIdUser(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new Exception("Token inválido");
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Guid.Parse(claim);
        }

        public static string BuscarNomeUser(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new Exception("Token inválido");
            }

            return principal.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
