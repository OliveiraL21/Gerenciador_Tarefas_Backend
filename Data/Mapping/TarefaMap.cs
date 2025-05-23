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
    public class TarefaMap : IEntityTypeConfiguration<TarefaEntity>
    {
        public void Configure(EntityTypeBuilder<TarefaEntity> builder)
        {
            builder.HasKey(t => t.Id); 
            builder.Property(t => t.Id);

            builder.Property(t => t.Descricao).IsRequired();
            builder.Property(t => t.HorarioInicio).IsRequired();
            builder.Property(t => t.HorarioFim).IsRequired();
            builder.Property(t => t.Duracao).IsRequired();
            builder.Property(t => t.Data).IsRequired();

            builder.HasOne(t => t.Projeto).WithMany(p => p.Tarefas).HasForeignKey(t => t.ProjetoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Status).WithMany(s => s.Tarefas).HasForeignKey(t => t.StatusId).OnDelete(DeleteBehavior.NoAction);


          
        }
    }
}
