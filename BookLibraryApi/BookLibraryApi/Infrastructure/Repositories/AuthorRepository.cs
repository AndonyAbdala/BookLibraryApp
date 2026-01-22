using BookLibraryApi.Domain.Interfaces;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookLibraryContext bookLibraryContext;
        public AuthorRepository(BookLibraryContext bookLibraryContext)
        {
            this.bookLibraryContext = bookLibraryContext;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await this.bookLibraryContext.Authors.ToListAsync();
        }
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await this.bookLibraryContext.Authors.FindAsync(id);
        }
        public async Task AddAsync(Author author)
        {
            this.bookLibraryContext.Authors.Add(author);
            await this.bookLibraryContext.SaveChangesAsync();
        }

        public async Task<Author?> UpdateAsync(int id, Author author)
        {
            var existingAuthor = await this.GetByIdAsync(id);
            if (existingAuthor == null)
                return null;

            existingAuthor.Id = author.Id;
            existingAuthor.Name = author.Name;
            existingAuthor.BirthDate = author.BirthDate;
            await this.bookLibraryContext.SaveChangesAsync();
            return existingAuthor;
        }
        public async Task DeleteAsync(int id)
        {
            Author? author = await this.bookLibraryContext.Authors.FindAsync(id);
            if (author != null)
            {
                this.bookLibraryContext.Authors.Remove(author);
                await bookLibraryContext.SaveChangesAsync();
            }
        }
    }
}
