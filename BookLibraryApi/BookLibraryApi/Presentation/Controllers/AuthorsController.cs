using BookLibraryApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorsController(IAuthorRepository authorRepository) 
        {
            this.authorRepository = authorRepository;
        }


        [HttpGet]
        public 
    }
}
