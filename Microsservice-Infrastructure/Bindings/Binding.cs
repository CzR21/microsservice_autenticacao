using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsservice_Application.Interfaces.Repositories;
using Microsservice_Application.Interfaces.Services;
using Microsservice_Application.Services;
using Microsservice_Domain.Configuration;
using Microsservice_Infrastructure.Context;
using Microsservice_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Infrastructure.Bindings
{
    public class Binding
    {

        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            #region Options
            ConnectionConfiguration connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionConfiguration>();
            JWTConfiguration jwt = configuration.GetSection("JWT").Get<JWTConfiguration>();

            services.AddSingleton(connectionStrings);
            services.AddSingleton(jwt);
            #endregion


            #region DI
            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            #region GoVisitContext
            services.AddDbContext<MicrosserviceContext>(options => options.UseNpgsql(connectionStrings.Connection));
            #endregion

            #region JWT
            services.AddSingleton(jwt);

            var key = Encoding.ASCII.GetBytes(jwt.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            #endregion
        }
    }
}
