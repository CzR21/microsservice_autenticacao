using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Domain.Models
{
    public class ResponseBaseModel
    {
        [JsonProperty("dados")]
        public object? Dados { get; set; }
        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
        [JsonProperty("codigo")]
        public int Codigo { get; set; }
    }
}
