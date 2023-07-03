using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaTarefas.Entities;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Npgsql;


#nullable disable
namespace SistemaTarefas.Context
{
    public partial class SistemaDbContext : DbContext
    {
        public SistemaDbContext()
        {
        }

        public SistemaDbContext(DbContextOptions<SistemaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projeto> Projects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        public IQueryable<Tarefa> SearchTarefas(DateTime? pdi,DateTime? pdf)
        {
            var ipdi = new NpgsqlParameter("@dinicial", pdi);
            var ipdf = new NpgsqlParameter("@dfinal", pdf);
            return this.Tarefas.FromSqlInterpolated($"SELECT * FROM alinea8({ipdi},{ipdf})");
        }
        public IQueryable<Tarefa> SearchTarefasalinea7()
        {
            return this.Tarefas.FromSqlRaw("SELECT * FROM alinea7");
        }
        public IQueryable<Tarefa> SearchTarefasalinea11(DateTime idata,int iid)
        {
            var id = new NpgsqlParameter("@utilizadorinput", iid);
            var data = new NpgsqlParameter("@datainput", idata);
            return this.Tarefas.FromSqlInterpolated($"SELECT * FROM alinea11({data},{id})");
        }
        public IQueryable<Tarefa> SearchTarefasalinea12(DateTime idata,int iid)
        {
            var id = new NpgsqlParameter("@projetoinput", iid);
            var data = new NpgsqlParameter("@datainput", idata);
            return this.Tarefas.FromSqlInterpolated($"SELECT * FROM alinea12({data},{id})");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=es2;Password=es2 ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.Property(e => e.idproject).HasDefaultValueSql("nextval('\"meals_idMeal_seq\"'::regclass)");

                entity.Property(e => e.nomecliente).HasDefaultValueSql(null);
                
                // entity.Property(e => e.precohora).HasDefaultValueSql("CURRENT_DATE");

                // entity.HasOne(d => d.User)
                //     .WithMany(p => p.Projetos)
                //     .HasForeignKey(d => d.idproject)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("meals_users_iduser_fk");
            });

            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.Property(e => e.UserId).HasDefaultValueSql("nextval('\"users_idUser_seq\"'::regclass)");
            // });
            // modelBuilder.Entity<Tarefa>(entity =>
            // {
            //     entity.Property(e => e.id_tarefa).HasDefaultValueSql("nextval('\"users_idUser_seq\"'::regclass)");
            // });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
