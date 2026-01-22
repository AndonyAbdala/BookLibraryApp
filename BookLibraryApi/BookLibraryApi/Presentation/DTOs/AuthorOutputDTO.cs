using BookLibraryApi.Domain.Models;

namespace BookLibraryApi.Presentation.DTOs
{
    public class AuthorOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}