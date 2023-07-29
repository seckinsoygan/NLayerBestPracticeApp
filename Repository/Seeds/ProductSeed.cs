using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	internal class ProductSeed : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(new Product
			{
				Id = 1,
				CategoryId = 1,
				Name = "Kalem 1",
				Price = 1000,
				Stock = 20,
				CreatedDate = DateTime.Now,
			},
			new Product
			{
				Id = 2,
				CategoryId = 1,
				Name = "Kalem 2",
				Price = 1500,
				Stock = 80,
				CreatedDate = DateTime.Now
			},
			new Product
			{
				Id = 3,
				CategoryId = 1,
				Name = "Kalem 3",
				Price = 1200,
				Stock = 10,
				CreatedDate = DateTime.Now
			},
			new Product
			{
				Id = 4,
				CategoryId = 2,
				Name = "Kitap 1",
				Price = 2100,
				Stock = 40,
				CreatedDate = DateTime.Now
			},
			new Product
			{
				Id = 5,
				CategoryId = 2,
				Name = "Kitap 2",
				Price = 1100,
				Stock = 30,
				CreatedDate = DateTime.Now
			}
			);
		}
	}
}
