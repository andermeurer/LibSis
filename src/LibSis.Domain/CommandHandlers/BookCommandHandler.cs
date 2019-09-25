using LibSis.Domain.Commands;
using LibSis.Domain.Core.Bus;
using LibSis.Domain.Core.Notifications;
using LibSis.Domain.Interfaces;
using LibSis.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibSis.Domain.CommandHandlers
{
    public class BookCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewBookCommand, bool>,
        IRequestHandler<UpdateBookCommand, bool>,
        IRequestHandler<RemoveBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public BookCommandHandler(IBookRepository bookRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _bookRepository = bookRepository;
        }

        public Task<bool> Handle(RegisterNewBookCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var book = new Book(Guid.NewGuid(), message.Name, message.Author);

            _bookRepository.Add(book);

            return Task.FromResult(Commit());
        }

        public Task<bool> Handle(UpdateBookCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var book = new Book(message.Id, message.Name, message.Author);

            _bookRepository.Update(book);
            
            return Task.FromResult(Commit());
        }

        public Task<bool> Handle(RemoveBookCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _bookRepository.Remove(message.Id);
            
            return Task.FromResult(Commit());
        }

        public void Dispose()
        {
            _bookRepository.Dispose();
        }
    }
}