using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelMapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(c => c.RazaoSocial).IsRequired();
            builder.Property(c => c.Cnpj).IsRequired();
            builder.Property(c => c.Telefone).IsRequired();
            builder.Property(c => c.Celular).IsRequired();
            builder.Property(c => c.Email).IsRequired();

            builder.HasMany(c => c.Projetos).WithOne(c => c.Cliente);   
        }
    }
}
