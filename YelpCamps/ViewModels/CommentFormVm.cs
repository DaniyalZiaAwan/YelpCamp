namespace YelpCamp.ViewModels
{
    public class CommentFormVm
    {
        public CommentFormVm()
        {

        }

        public CommentFormVm(int campId, string campName)
        {
            CampId = campId;
            CampName = campName;
        }

        public int CampId { get; set; }
        public string CampName { get; set; }
        public string Text { get; set; }
        public int CommentId { get; set; }
    }
}