using AutoMapper;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Presentation.DTOs;


namespace BookLibraryApi.Presentation.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookOutputDTO>();

            CreateMap<BookInputDTO, Book>();
        }
    }
}
