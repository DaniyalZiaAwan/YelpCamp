using System.Collections.Generic;

namespace YelpCamps.Models
{
    public class Campground
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public ApplicationUser Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}