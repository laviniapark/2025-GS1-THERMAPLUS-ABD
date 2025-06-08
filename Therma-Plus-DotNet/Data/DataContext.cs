using Microsoft.EntityFrameworkCore;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Regiao> Regioes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Usuario>()
        .HasOne(u => u.Regiao)
        .WithMany(r => r.Usuarios)
        .HasForeignKey(u => u.RegiaoId);
}
}