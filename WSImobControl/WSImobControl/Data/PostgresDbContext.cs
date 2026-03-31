using Microsoft.EntityFrameworkCore;
using WSImobControl.Model;

namespace WSImobControl.Data
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
        }

        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
    }
}
