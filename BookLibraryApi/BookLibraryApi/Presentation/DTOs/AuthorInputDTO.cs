namespace BookLibraryApi.Presentation.DTOs
{
    public class AuthorInputDTO
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}