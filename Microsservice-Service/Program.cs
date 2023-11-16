using Microsoft.OpenApi.Models;
using Microsservice_Infrastructure.Bindings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Binding.Configure(builder.Services, builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microsserviço-Autenticador", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    /*var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);*/
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                        policy =>
                        {
                            policy.AllowAnyOrigin();
                            policy.AllowAnyMethod();
                            policy.AllowAnyHeader();
                        }
                            );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();