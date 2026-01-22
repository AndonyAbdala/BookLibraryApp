using AutoMapper;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Presentation.DTOs;
using BookLibraryApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorsController(IMapper mapper, IAuthorService authorService) 
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Author> authors = await this.authorService.GetAllAuthors();
            List<AuthorOutputDTO> authorDTOs = this.mapper.Map<List<AuthorOutputDTO>>(authors);
            return Ok(authorDTOs);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorInputDTO author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Author authorItem = this.mapper.Map<Author>(author);
            await this.authorService.CreateAuthor(authorItem);

            AuthorOutputDTO authorOutput = this.mapper.Map<AuthorOutputDTO>(authorItem);

            // Devuelve 201 Created con la ruta al nuevo recurso
            return CreatedAtAction(nameof(GetAuthorById), new { id = authorItem.Id }, authorOutput);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            Author author = await this.authorService.GetAuthorById(id);
            AuthorOutputDTO authorOutput = this.mapper.Map<AuthorOutputDTO>(author);
            return Ok(authorOutput);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAuthor(int id, [FromBody] AuthorInputDTO author)
        {
            Author authorItem = this.mapper.Map<Author>(author);
            Author updatedAuthor = await this.authorService.PatchAuthor(id, authorItem);
            AuthorOutputDTO authorDTO = this.mapper.Map<AuthorOutputDTO>(updatedAuthor);
            return Ok(authorDTO);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await this.authorService.DeleteAuthor(id);
            return NoContent(); // 204 - eliminado correctamente
        }
    }
}
