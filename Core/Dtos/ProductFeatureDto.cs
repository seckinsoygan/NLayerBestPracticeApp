using Core.Dtos.Shared;

namespace Core.Dtos
{
	public class ProductFeatureDto : BaseDto
	{
		public string Color { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int ProductId { get; set; }
	}
}
