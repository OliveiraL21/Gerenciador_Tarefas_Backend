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
    public class ProjetoMap : IEntityTypeConfiguration<ProjetoEntity>
    {
        public void Configure(EntityTypeBuilder<ProjetoEntity> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataInicio).IsRequired();
            builder.Property(x => x.DataFim).IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(c => c.Projetos).HasForeignKey(x => x.ClienteId);
            builder.HasOne(x => x.Status).WithMany(s => s.Projetos).HasForeignKey(x => x.StatusId);
            builder.HasMany(x => x.Tarefas).WithOne(t => t.Projeto).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
