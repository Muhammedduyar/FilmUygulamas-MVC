namespace FilmApp.Models
{
    public class MovieImages
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public string MovieDescription { get; set; }
        public DateTime ReleasedDate { get; set; }
        public bool isWatched { get; set; }
        public IFormFile Image { get; set; }
    }
}
