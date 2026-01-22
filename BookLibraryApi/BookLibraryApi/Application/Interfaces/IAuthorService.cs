using BookLibraryApi.Domain.Models;

namespace BookLibraryApi.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        Task CreateAuthor(Author author);
        Task<Author> GetAuthorById(int id);
        Task<Author> PatchAuthor(int id, Author author);
        Task DeleteAuthor(int id);
    }
}
