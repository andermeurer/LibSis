using AutoMapper;
using LibSis.Application.ViewModels;
using LibSis.Domain.Commands;

namespace LibSis.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BookViewModel, RegisterNewBookCommand>()
                .ConstructUsing(c => new RegisterNewBookCommand(c.Name, c.Author));
            CreateMap<BookViewModel, UpdateBookCommand>()
                .ConstructUsing(c => new UpdateBookCommand(c.Id, c.Name, c.Author));
        }
    }
}
