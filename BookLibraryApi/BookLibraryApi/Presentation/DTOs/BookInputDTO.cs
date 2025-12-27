namespace BookLibraryApi.Presentation.DTOs
{
    public class BookInputDTO
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;
    }
}