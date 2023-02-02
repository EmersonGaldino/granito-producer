using granito.domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace granito.repository.Repository.Context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
    }

    public virtual DbSet<UserEntity> User { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(p => p.Id);

        });
    }
    public async Task<int> SaveChangesAsync()
    {
        ChangeTracker.DetectChanges();
        
        return await base.SaveChangesAsync();

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLoggerFactory(_loggerFactory);
        //optionsBuilder.EnableSensitiveDataLogging();

        //optionsBuilder.UseNpgsql("Server=iza-pg-hmg.cluster-cndmdvlrx2le.us-east-1.rds.amazonaws.com;Port=5432;Database=massissue;User Id=admizahmg;Password=0pl!ie12+32d!cx9;");
        base.OnConfiguring(optionsBuilder);
    }
}