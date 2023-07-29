﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	internal class CategorySeed : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(
				new Category { Id = 1, Name = "Kalemler" },
				new Category { Id = 2, Name = "Kitaplar" },
				new Category { Id = 3, Name = "Defterler" }
				);
		}
	}
}
