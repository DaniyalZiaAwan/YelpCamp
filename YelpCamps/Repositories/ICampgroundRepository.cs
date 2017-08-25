using YelpCamps.Models;

namespace YelpCamps.Repositories
{
    public interface ICampgroundRepository : IRepository<Campground>
    {
        Campground GetCampWithRelatedData(int id);
    }
}