
using SGEfinal.Aplicacion;
using Microsoft.EntityFrameworkCore;
namespace SGEfinal.Repositorios;

public class BaseContext: DbContext
{
    
    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Expediente> Expedientes {get; set;}
    public DbSet<Tramite> Tramites {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Base.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().HasKey(u=>u.idUsuario);
        modelBuilder.Entity<Expediente>().HasKey(e=> e.idExpediente);
        modelBuilder.Entity<Tramite>().HasKey(t=>  t.idTramite);
    }

}