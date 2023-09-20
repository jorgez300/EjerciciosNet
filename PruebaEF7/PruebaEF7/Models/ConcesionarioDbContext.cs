using Microsoft.EntityFrameworkCore;
using Models;

namespace Db
{
    public class ConcesionarioDbContext : DbContext
    {
        public ConcesionarioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Vendedor> Vendedores => Set<Vendedor>();
        public DbSet<Pregunta> Preguntas => Set<Pregunta>();
        public DbSet<Respuesta> Respuestas => Set<Respuesta>();
        public DbSet<VehiculoVendedor> VehiculosVendedores => Set<VehiculoVendedor>();
    }
}
