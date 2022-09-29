using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
	public DbSet<Product>? Products { get; set; }	
	public DbSet<Category>? Categories { get; set; }	

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Product>()
			.Property(p => p.Description).HasMaxLength(500).IsRequired();
		builder.Entity<Product>()
			.Property(p => p.Name).HasMaxLength(120).IsRequired();
		builder.Entity<Product>()
			.Property(p => p.Code).HasMaxLength(20).IsRequired();
		builder.Entity<Category>()
			.ToTable("Categories");
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		//	This configuration can be overrided by using Property HasMaxLength
		configurationBuilder.Properties<string>()
			.HaveMaxLength(100);
	}
}
