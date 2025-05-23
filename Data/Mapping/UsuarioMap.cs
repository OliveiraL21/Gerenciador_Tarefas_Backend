using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id);

            builder.Property(u => u.Username).IsRequired();
            builder.HasIndex(u => u.Username);

            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            builder.ToTable("Usuarios");
        }
    }
}
