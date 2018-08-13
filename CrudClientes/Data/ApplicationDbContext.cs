using Microsoft.EntityFrameworkCore;
using CrudClientes.Models;

namespace CrudClientes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
           base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TelefoneCliente> TelefoneClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);
            modelBuilder.Entity<TelefoneCliente>()
                .HasOne(t=> t.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.ClienteId);
        }
    }
}
