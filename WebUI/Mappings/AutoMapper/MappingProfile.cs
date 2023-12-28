using AutoMapper;
using Models.Entities.Concrete;
using Models.ViewModels;

namespace WebUI.Mappings.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddBookViewModel, Book>();

        CreateMap<Book, ListBookViewModel>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

        CreateMap<ListBookViewModel, LendBookViewModel>();
    }
}
