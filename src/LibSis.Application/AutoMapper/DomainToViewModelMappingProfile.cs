using AutoMapper;
using LibSis.Application.ViewModels;
using LibSis.Domain.Models;

namespace LibSis.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Book, BookViewModel>();
        }
    }
}
