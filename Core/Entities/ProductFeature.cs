using Core.Entities.Shared;

namespace Core.Entities
{
	public class ProductFeature : BaseEntity
	{
		public string Color { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
