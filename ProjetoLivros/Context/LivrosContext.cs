using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{
    public class LivrosContext : DbContext
    {
        // Cada tabela -> DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }

        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            // String de Conexao
            optionsBuilder.UseSqlServer("Data Source=NOTE26-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                // Representacao da Tabela
                entity =>
                {
                    // Primary Key
                    entity.HasKey(u => u.UsuarioId);

                    entity.Property(u => u.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    //Email e Unico
                    entity.HasIndex(u => u.Email)
                    .IsUnique();

                    entity.Property(u => u.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(u => u.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                    entity.Property(u => u.DataCadastro)
                    .IsRequired();

                    entity.Property(u => u.DataAtualizacao)
                    .IsRequired();

                    entity.HasOne(u => u.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(u => u.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                // Configuro a primary key
                entity.HasKey(t => t.TipoUsuarioId);

                entity.Property(t => t.DescricaoTipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasIndex(t => t.DescricaoTipo)
                    .IsUnique();
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(l => l.LivroId);

                entity.Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(l => l.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(l => l.DataPublicacao)
                .IsRequired();

                // Relacionamentos
                // Livro - Categoria
                // 1 - N
                entity.HasOne(l => l.Categoria)
                .WithMany(c => c.Livros)
                .HasForeignKey(u => u.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.CategoriaId);

                entity.Property(c => c.NomeCategoria)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Assinatura>(entity =>
            {
                entity.HasKey(a => a.AssinaturaId);

                entity.Property(a => a.DataInicio)
                .IsRequired();

                entity.Property(a => a.DataFim)
                .IsRequired();

                entity.Property(a => a.Status)
                .IsRequired()
                 .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasOne(a => a.Usuario)
               .WithMany()
               .HasForeignKey(a => a.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
