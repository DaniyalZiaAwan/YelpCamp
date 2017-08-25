using System.Data.Entity;
using System.Linq;
using YelpCamps.Models;

namespace YelpCamps.Repositories
{
    public class CampgroundRepository : Repository<Campground>, ICampgroundRepository
    {
        public CampgroundRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Campground GetCampWithRelatedData(int id) => DbContext.Campgrounds
                    .Include(c => c.Comments)
                    .Include(c => c.Comments.Select(co => co.Author))
                    .Include(c => c.Author)
                    .SingleOrDefault(c => c.Id == id);

        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
    }
}