using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrete.Contexts
{
    public class StarterKitDbContext : DbContext
    {
        public StarterKitDbContext(DbContextOptions<StarterKitDbContext> options) : base(options)
        {
        }

        public StarterKitDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Server=.;Database=StarterKit;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
            Assembly assemblyConfiguration = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyConfiguration);
        }

        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<OperationClaim> OperationClaims{ get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims{ get; set; }
    }
}