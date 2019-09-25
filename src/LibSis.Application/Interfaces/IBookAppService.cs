using LibSis.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LibSis.Application.Interfaces
{
    public interface IBookAppService : IDisposable
    {
        void Register(BookViewModel bookViewModel);
        IEnumerable<BookViewModel> GetAll();
        BookViewModel GetById(Guid id);
        void Update(BookViewModel bookViewModel);
        void Remove(Guid id);
    }
}
