using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		DbSet<Category> Categories { get; set; }
		DbSet<Product> Products { get; set; }
		DbSet<ProductFeature> ProductFeatures { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
			//Best Practice değil bu örnek olması açısından yapıldı. Normalde seed dataları kendine özgü classlarda tutuyoruz. Seeds klasörünün altında örneklerini bulabilirsin.
			modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
			{
				Id = 1,
				Color = "Kırmızı",
				Height = 200,
				Width = 100,
				ProductId = 1,
			},
			new ProductFeature()
			{
				Id = 2,
				Color = "Mavi",
				Height = 200,
				Width = 100,
				ProductId = 2,
			});
		}
	}
}
