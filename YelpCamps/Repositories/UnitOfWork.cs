using YelpCamps.Models;

namespace YelpCamps.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICampgroundRepository Campgrounds { get; }
        public IUserRepository Users { get; }
        public ICommentRepository Comments { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Campgrounds = new CampgroundRepository(_context);
            Users = new UserRepository(_context);
            Comments = new CommentRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}