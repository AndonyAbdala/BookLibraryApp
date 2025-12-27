namespace BookLibraryApi.Presentation.DTOs
{
    public class BookOutputDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;

        // Mostrar información básica del autor
        public string AuthorName { get; set; } = string.Empty;
    }
}