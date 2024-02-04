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

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Status> Status { get; set; }

        public MyContext(DbContextOptions<MyContext>options) : base(options) 
        {

        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;database=Controle_Tarefas;Trusted_Connection=true;");
            optionsBuilder.UseMySql("Server=localhost;Port=3306;DataBase=GerenciadorTarefasDev;Uid=root;Pwd=Lucas98971@;SSL Mode=None",new MySqlServerVersion(new Version(8, 0, 38)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<Projeto>(new ProjetoMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Tarefa>(new TarefaMap().Configure); 
            modelBuilder.Entity<Status>(new StatusMap().Configure);
        }
    }
}
