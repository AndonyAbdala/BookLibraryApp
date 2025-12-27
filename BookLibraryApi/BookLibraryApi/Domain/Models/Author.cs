namespace BookLibraryApi.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }

        // Relación con libros
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
