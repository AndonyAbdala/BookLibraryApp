using BookLibraryApi.Domain.Interfaces;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookLibraryContext bookLibraryContext;
        public BookRepository(BookLibraryContext bookLibraryContext)
        {
            this.bookLibraryContext = bookLibraryContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await this.bookLibraryContext.Books.ToListAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await this.bookLibraryContext.Books.FindAsync(id);
        }
        public async Task AddAsync(Book book)
        {
            this.bookLibraryContext.Books.Add(book);
            await this.bookLibraryContext.SaveChangesAsync();
        }
        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existingBook = await this.GetByIdAsync(id);
            if (existingBook == null)
                return null;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;
            existingBook.Genre = book.Genre;
            await this.bookLibraryContext.SaveChangesAsync();
            return existingBook;
        }
        public async Task DeleteAsync(int id)
        {
            Book? book = await this.bookLibraryContext.Books.FindAsync(id);
            if (book != null)
            {
                this.bookLibraryContext.Books.Remove(book);
                await bookLibraryContext.SaveChangesAsync();
            }
        }
    }
}
