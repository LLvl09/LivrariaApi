using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt): base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Livro>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(4,2)")
                .IsRequired(true);
            
        }
        
        public DbSet<Livro> Livros { get; set; }

       
    }
}
