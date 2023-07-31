namespace Core.Dtos
{
	public class ProductWithCategoryDto
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public CategoryDto Category { get; set; }
	}
}
