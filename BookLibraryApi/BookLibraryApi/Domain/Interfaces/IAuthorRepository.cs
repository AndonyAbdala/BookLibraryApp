using BookLibraryApi.Domain.Models;

namespace BookLibraryApi.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task AddAsync(Author book);
        Task<Author?> UpdateAsync(int id, Author book);
        Task DeleteAsync(int id);
    }
}
