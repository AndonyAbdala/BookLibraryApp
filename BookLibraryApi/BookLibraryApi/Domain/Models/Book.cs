namespace BookLibraryApi.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;

        // Relación con Author
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
