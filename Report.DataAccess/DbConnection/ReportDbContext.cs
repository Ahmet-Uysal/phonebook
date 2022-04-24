using Report.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Report.DataAccess.DbConnection
{
    public class ReportDbContext : DbContext
    {
        public string ConnectionString { get; set; } = @"Server=127.0.0.1;Port=5432;Database=Report;User Id=postgres;Password=123456;
";
        public DbSet<Reports> Reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseNpgsql(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reports>()
                .Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()");



        }
    }

}

