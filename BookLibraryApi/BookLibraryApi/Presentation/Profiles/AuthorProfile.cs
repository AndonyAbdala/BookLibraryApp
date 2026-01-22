using AutoMapper;
using BookLibraryApi.Domain.Models;
using BookLibraryApi.Presentation.DTOs;


namespace BookLibraryApi.Presentation.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorOutputDTO>();

            CreateMap<AuthorInputDTO, Author>();
        }
    }
}
