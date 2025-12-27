using AutoMapper;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Presentation.DTOs;


namespace BookLibraryApi.Presentation.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookOutputDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<BookInputDTO, Book>();
        }
    }
}
