using Microsoft.EntityFrameworkCore;
using PropertyManagementApi.Domain.Entities;

namespace PropertyManagementApi.Infrastructure.Persistence
{
    public class PropertyManagementDbContext : DbContext
    {
        public PropertyManagementDbContext(DbContextOptions<PropertyManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyForSale> PropertiesForSale { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
