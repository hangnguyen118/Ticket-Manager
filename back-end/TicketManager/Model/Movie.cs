namespace TicketManagerBE.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; } = null;
    }
}
