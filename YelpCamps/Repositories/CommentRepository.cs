using System.Data.Entity;
using System.Linq;
using YelpCamps.Models;

namespace YelpCamps.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Comment GetCommentWithRelatedData(int id) => DbContext.Comments
                 .Include(c => c.Campground)
                 .Single(c => c.Id == id);

        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
    }
}