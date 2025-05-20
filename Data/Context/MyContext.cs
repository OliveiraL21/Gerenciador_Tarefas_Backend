using Data.ModelMapping;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ProjetoEntity> Projetos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<TarefaEntity> Tarefas { get; set; }

        public DbSet<StatusEntity> Status { get; set; }

        public MyContext(DbContextOptions<MyContext>options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<ProjetoEntity>(new ProjetoMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<TarefaEntity>(new TarefaMap().Configure); 
            modelBuilder.Entity<StatusEntity>(new StatusMap().Configure);
            modelBuilder.Entity<StatusEntity>().HasData(new StatusEntity() { Id = Guid.NewGuid(), Descricao = "Ativo" });
            modelBuilder.Entity<StatusEntity>().HasData(new StatusEntity() { Id = Guid.NewGuid(),  Descricao = "Inatívo" });
            modelBuilder.Entity<StatusEntity>().HasData(new StatusEntity() { Id = Guid.NewGuid(),  Descricao = "Em pausa" });
            modelBuilder.Entity<StatusEntity>().HasData(new StatusEntity() { Id = Guid.NewGuid(), Descricao = "Excluído" });
            modelBuilder.Entity<StatusEntity>().HasData(new StatusEntity() { Id = Guid.NewGuid(), Descricao = "Finalizado" });
            modelBuilder.Entity<StatusEntity>().HasData(new StatusEntity() { Id = Guid.NewGuid(), Descricao = "Bloqueado" });
        }
    }
}
