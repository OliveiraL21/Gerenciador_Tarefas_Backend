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
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(s => s.Descricao).IsRequired();

            builder.HasMany(s => s.Projetos).WithOne(p => p.Status).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(s => s.Tarefas).WithOne(t => t.Status).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
