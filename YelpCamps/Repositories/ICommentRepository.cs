using YelpCamps.Models;

namespace YelpCamps.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Comment GetCommentWithRelatedData(int id);
    }
}
