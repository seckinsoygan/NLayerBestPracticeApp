using Core.UnitOfWorks;

namespace Repository.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
