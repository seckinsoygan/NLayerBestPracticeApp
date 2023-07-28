namespace Core.Entities
{
	public class ProductFeature : Product
	{
		public int Id { get; set; }
		public string Color { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
