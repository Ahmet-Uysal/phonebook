using PhoneBook.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.DataAccess.DbConnection
{
    public class PhoneBookDbContext : DbContext
    {
        public string ConnectionString { get; set; } = @"Server=127.0.0.1;Port=5432;Database=PhoneBook;User Id=postgres;Password=123456;
";
        public DbSet<Persons> Persons { get; set; }
        public DbSet<CommunicationInformations> CommunicationInformations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseNpgsql(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Persons>()
                .Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder
          .Entity<CommunicationInformations>()
          .Property(e => e.Id)
          .HasDefaultValueSql("gen_random_uuid()");
        }
    }

}

