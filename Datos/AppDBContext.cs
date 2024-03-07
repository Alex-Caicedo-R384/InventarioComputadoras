using InventarioComputadoras.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioComputadoras.Datos
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
        }

        public DbSet<Computadora> Computadoras { get; set; } = default!;

    }
}
