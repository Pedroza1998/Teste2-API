using Entidades.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Clientes> Clientes { get; set; }
    }
}