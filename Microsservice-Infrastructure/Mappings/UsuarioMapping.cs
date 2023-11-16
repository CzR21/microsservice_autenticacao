using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuarios"); //Usuário
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome);
            builder.Property(x => x.Celular);
            builder.Property(x => x.Email);
            builder.Property(x => x.Senha);

            builder.Property(c => c.TipoStatus)
               .HasConversion(
                   v => v.ToString(),
                   v => (TipoStatus)Enum.Parse(typeof(TipoStatus), v))
               .IsRequired()
               .HasColumnType("varchar(255)");
        }
    }
}
