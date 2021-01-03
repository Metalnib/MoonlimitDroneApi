using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moonlimit.DroneAPI.Entity.DroneCom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;

namespace Moonlimit.DroneAPI.Entity.Context
{
    public partial class DefaultDbContext : DbContext
    {

        private readonly IEnumerable<IEntityTypeMap> _mappings;
        
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IEnumerable<IEntityTypeMap> mappings)
            : base(options)
        {
            _mappings = mappings;
        }

        public DbSet<CompanyAccount> CompanyAccounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<DroneNetworkSettings> DroneNetworkSettings { get; set; }
        public DbSet<DroneOnvifSettings> DroneOnvifSettings { get; set; }
        public DbSet<GeoArea> GeoAreas { get; set; }
        public DbSet<GeoPoint> GeoPoints { get; set; }
        public DbSet<PatrolConfig> PatrolConfigs { get; set; }
        public DbSet<DroneCommands> DroneCommands { get; set; }
        public DbSet<ObjectDetection> ObjectDetections { get; set; }
        public DbSet<PlannedRoute> PlannedRoutes { get; set; }
        public DbSet<StatusReport> StatusReports { get; set; }

        // Lazy loading should be disabled in Postgresql because it does NOT support Multiple Active Result Sets
        //lazy-loading https://entityframeworkcore.com/querying-data-loading-eager-lazy
        //https://docs.microsoft.com/en-us/ef/core/querying/related-data
        //EF Core will enable lazy-loading for any navigation property that is virtual and in an entity class that can be inherited
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSnakeCaseNamingConvention();
        //.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Apply Db configuration mappings: indexes, constraints and db generated fields
            foreach (var mapping in _mappings)
            {
                mapping.Map(modelBuilder);
            }
            
            //Fluent API

            SetAdditionalConcurency(modelBuilder); ;
        }

        //call scaffolded class method to add concurrency
        partial void SetAdditionalConcurency(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).ModifiedAt = DateTime.UtcNow;
            }
        }

    }
}
