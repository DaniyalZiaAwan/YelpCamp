using YelpCamps.Models;

namespace YelpCamps.ViewModels
{
    public class CampDetailVm
    {
        public Campground Campground { get; set; }
        public bool ShowActions { get; set; }
        public bool IsAuthorized { get; set; }
    }
}