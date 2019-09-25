using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibSis.Application.Interfaces;
using LibSis.Application.ViewModels;
using LibSis.Domain.Commands;
using LibSis.Domain.Core.Bus;
using LibSis.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace LibSis.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IMediatorHandler Bus;

        public BookAppService(IMapper mapper,
                                  IBookRepository bookRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            Bus = bus;
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            return _bookRepository.GetAll().ProjectTo<BookViewModel>(_mapper.ConfigurationProvider);
        }

        public BookViewModel GetById(Guid id)
        {
            return _mapper.Map<BookViewModel>(_bookRepository.GetById(id));
        }

        public void Register(BookViewModel bookViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewBookCommand>(bookViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(BookViewModel bookViewModel)
        {
            var updateCommand = _mapper.Map<UpdateBookCommand>(bookViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveBookCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
