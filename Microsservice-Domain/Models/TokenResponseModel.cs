using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Domain.Models
{
    public class TokenResponseModel
    {
        [JsonProperty("idUsuario")]
        public Guid IdUsuario { get; set; }
        [JsonProperty("nomeUsuario")]
        public string NomeUsuario { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
