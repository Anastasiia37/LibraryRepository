using AutoMapper;
using Library.BusinessLogic.DTOs;
using Library.DAL.Entities;
using Library.ViewModels.RequestViewModels;
using Library.ViewModels.ResponseViewModels;

namespace Library
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorRequestViewModel, AuthorDTO>().ReverseMap();
            CreateMap<BookRequestViewModel, BookDTO>().ReverseMap();
            CreateMap<CountryRequestViewModel, CountryDTO>().ReverseMap();
            CreateMap<PublisherRequestViewModel, PublisherDTO>().ReverseMap();

            CreateMap<BookDTO, BookResponseViewModel>().ReverseMap();
            CreateMap<AuthorDTO, AuthorResponseViewModel>().ForMember(dest => dest.CountryId, src => src.MapFrom(s => s.Country.Id));
            CreateMap<CountryDTO, CountryResponseViewModel>().ReverseMap();
            CreateMap<PublisherDTO, PublisherResponseViewModel>().ReverseMap();

            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<CountryDTO, Country>().ReverseMap();
            CreateMap<PublisherDTO, Publisher>().ReverseMap();

            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
        }
    }
}
