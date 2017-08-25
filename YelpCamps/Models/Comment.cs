namespace YelpCamps.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(ApplicationUser author, string text, int campId)
        {
            Author = author;
            Text = text;
            CampgroundId = campId;
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public ApplicationUser Author { get; set; }
        public Campground Campground { get; set; }
        public int CampgroundId { get; set; }
    }
}