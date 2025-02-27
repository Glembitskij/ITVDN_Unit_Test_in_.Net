using _033_InMemory_Cosmos.Models;
using _033_InMemory_Cosmos.Options;
using Microsoft.EntityFrameworkCore;

namespace _033_InMemory_Cosmos.Cosmos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private readonly string _databaseName;
        private readonly string _containerName;

        public AppDbContext(DbContextOptions<AppDbContext> options, CosmosDbOptions cosmosDbOptions)
            : base(options)
        {
            _databaseName = cosmosDbOptions.DatabaseName;
            _containerName = cosmosDbOptions.ContainerName;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().
                ToContainer(_containerName).
                HasNoDiscriminator().
                HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
