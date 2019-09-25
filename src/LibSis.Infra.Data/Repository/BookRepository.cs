using LibSis.Domain.Interfaces;
using LibSis.Domain.Models;
using LibSis.Infra.Data.Context;

namespace LibSis.Infra.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibSisContext context)
            : base(context)
        {

        }
    }
}
