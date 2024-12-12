using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data.Models.SharedTables;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth;
using RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic;
using RS1_2024_25.API.Helper.BaseClasses;
using RS1_2024_25.API.Services;
using System.Linq.Expressions;

namespace RS1_2024_25.API.Data
{
    public class ApplicationDbContext(
        DbContextOptions options,
        IServiceProvider serviceProvider
        ) : DbContext(options)
    {
        public int? _CurrentTenantId = null;
        public int CurrentTenantId
        {
            get
            {
                if (_CurrentTenantId == null )
                {
                    var authService = serviceProvider.GetRequiredService<MyAuthService>();
                    MyAuthInfo myAuthInfo = authService.GetAuthInfo();
                    if (!myAuthInfo.IsLoggedIn)
                    {
                        throw new UnauthorizedAccessException();
                        
                    }
                    _CurrentTenantId = myAuthInfo.TenantId;
                }
                return _CurrentTenantId.Value;
            }
            set
            {
                _CurrentTenantId = value;
            }
        }


        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<MyAppUser> MyAppUsers { get; set; }
        public DbSet<MyAuthenticationToken> MyAuthenticationTokens { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            // opcija kod nasljeđivanja
            // modelBuilder.Entity<NekaBaznaKlasa>().UseTpcMappingStrategy();

            // Globalni filter za TenantSpecificTable
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => typeof(TenantSpecificTable).IsAssignableFrom(t.ClrType)))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var tenantProperty = Expression.Property(parameter, "TenantId");
                var currentTenantId = Expression.Constant(_CurrentTenantId??0);
                var equality = Expression.Equal(tenantProperty, currentTenantId);

                var lambda = Expression.Lambda(equality, parameter);

                // Primjena filtera na entitet
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
     
        public override int SaveChanges()
        {
            AddTenantIdToNewEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTenantIdToNewEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTenantIdToNewEntities()
        {
            // Iteracija kroz sve promjene u DbContext
            foreach (var entry in ChangeTracker.Entries()
                         .Where(e => e.State == EntityState.Added && e.Entity is TenantSpecificTable))
            {
                // Postavljanje TenantId za nove entitete
                var entity = (TenantSpecificTable)entry.Entity;
                entity.TenantId = CurrentTenantId;
            }
        }
    }
}
