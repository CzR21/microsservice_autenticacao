﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Domain.Models
{
    public class LoginModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}
