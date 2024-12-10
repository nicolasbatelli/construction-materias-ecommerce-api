using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext 
{ 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            // Use HasColumnType if you want to specify the SQL type directly
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

            // Or use HasPrecision to specify precision and scale in a more abstract way
            // entity.Property(e => e.Price).HasPrecision(18, 2);
        });
    }

}