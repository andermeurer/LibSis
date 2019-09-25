using LibSis.Domain.Interfaces;
using LibSis.Infra.Data.Context;

namespace LibSis.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibSisContext _context;

        public UnitOfWork(LibSisContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
