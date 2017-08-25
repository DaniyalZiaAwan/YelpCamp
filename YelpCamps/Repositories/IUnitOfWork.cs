namespace YelpCamps.Repositories
{
    public interface IUnitOfWork
    {
        ICampgroundRepository Campgrounds { get; }
        IUserRepository Users { get; }
        ICommentRepository Comments { get; }
        int Complete();
    }
}