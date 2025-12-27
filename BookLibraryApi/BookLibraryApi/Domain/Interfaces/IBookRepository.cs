using BookLibraryApi.Domain.Models;

namespace BookLibraryApi.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task<Book?> UpdateAsync(int id, Book book);
        Task DeleteAsync(int id);
    }
}
