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
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id);

            builder.Property(c => c.RazaoSocial).IsRequired();
            builder.Property(c => c.Cnpj);
            builder.Property(c => c.Telefone);
            builder.Property(c => c.Celular);
            builder.Property(c => c.Email);

            builder.HasMany(c => c.Projetos).WithOne(c => c.Cliente);   
        }
    }
}
