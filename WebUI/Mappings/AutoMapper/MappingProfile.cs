using AutoMapper;
using Models.Entities.Concrete;
using Models.ViewModels;

namespace WebUI.Mappings.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddBookViewModel, Book>();
        CreateMap<AddBorrowerViewModel, Borrower>();

        CreateMap<Book, ListBookViewModel>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.BorrowedBy, opt => opt.MapFrom(src => src.Borrower!.Name))
            .ForMember(dest => dest.LibraryBorrowerId, opt => opt.MapFrom(src => src.Borrower!.LibraryBorrowerId));

        CreateMap<ListBookViewModel, LendBookViewModel>();
    }
}
