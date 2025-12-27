using BookLibraryApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BookLibraryApi.Presentation.DTOs;
using AutoMapper;
using System.Collections.Generic;
using BookLibraryApi.Domain.Interfaces;

namespace BookLibraryApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository,
                               IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Book> books = await bookRepository.GetAllAsync();
            List<BookInputDTO> bookDTOs = this.mapper.Map<List<BookInputDTO>>(books);
            return Ok(bookDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            Book? book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new Exception("El libro no existe"); // Ahora será manejado globalmente
            BookInputDTO bookItem = this.mapper.Map<BookInputDTO>(book);
            return Ok(bookItem);
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookInputDTO book)
        {
            if (!ModelState.IsValid)
                throw new Exception("El formato de los datos de entrada es incorrecto"); // Ahora será manejado globalmente

            Book bookItem = this.mapper.Map<Book>(book);
            await bookRepository.AddAsync(bookItem);

            // Devuelve 201 Created con la ruta al nuevo recurso
            return CreatedAtAction(nameof(GetBookById), new { id = bookItem.Id }, book);
        }

        // PATCH: api/books/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook(int id, [FromBody] BookInputDTO book)
        {
            Book bookItem = this.mapper.Map<Book>(book);
            Book? updatedBook = await bookRepository.UpdateAsync(id, bookItem);
            if (updatedBook == null)
                throw new Exception("El libro no existe"); // Ahora será manejado globalmente

            BookInputDTO bookDTO = this.mapper.Map<BookInputDTO>(updatedBook);
            return Ok(bookDTO);
        }

        // =====================================
        // DELETE: api/students/{id}
        // =====================================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await bookRepository.GetByIdAsync(id);
            if (student == null)
                throw new Exception("El libro no existe"); // Ahora será manejado globalmente

            await bookRepository.DeleteAsync(id);

            return NoContent(); // 204 - eliminado correctamente
        }
    }
}
