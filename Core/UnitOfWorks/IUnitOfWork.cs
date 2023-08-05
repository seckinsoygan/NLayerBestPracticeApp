namespace Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); //SaveChange async
        void Commit();      //SaveChange	
    }
}
