using Microsoft.EntityFrameworkCore;
using Microsservice_Domain.Entites;
using Microsservice_Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Infrastructure.Context
{
    public class MicrosserviceContext : DbContext
    {
        public MicrosserviceContext(DbContextOptions<MicrosserviceContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
