using BookLibraryApi.Domain.Interfaces;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Application.Interfaces;
using BookLibraryApi.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthors() 
        {
            List<Author> authors = await this.authorRepository.GetAllAsync();
            return authors;
        }

        public async Task CreateAuthor(Author author)
        {
            try
            {
                await authorRepository.AddAsync(author);
            }
            catch (DbUpdateException)
            {
                throw new ValidationException("Error creating author in DB");
            }
        }

        public async Task<Author> GetAuthorById(int id)
        {
            if (id <= 0)
                throw new ValidationException("El id debe ser mayor que 0");

            Author? author = await authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new NotFoundException("El autor no existe");
            return author;
        }

        public async Task<Author> PatchAuthor(int id, Author author)
        {
            if (id <= 0)
                throw new ValidationException("El id debe ser mayor que 0");

            try
            {
                Author? updatedAuthor = await authorRepository.UpdateAsync(id, author);
                if (updatedAuthor == null)
                    throw new NotFoundException("El autor no existe");
                return updatedAuthor;
            }
            catch (DbUpdateException)
            {
                throw new ValidationException("Error updating author from DB");
            }
        }

        public async Task DeleteAuthor(int id)
        {
            if (id <= 0)
                throw new ValidationException("El id debe ser mayor que 0");

            Author? author = await authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundException("El autor no existe");
            try
            {
                await authorRepository.DeleteAsync(id);
            }
            catch (DbUpdateException)
            {
                throw new ValidationException("Error deleting author from DB");
            }
        }
    }
}
