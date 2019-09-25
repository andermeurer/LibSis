using LibSis.Application.Interfaces;
using LibSis.Application.Services;
using LibSis.Domain.CommandHandlers;
using LibSis.Domain.Commands;
using LibSis.Domain.Core.Bus;
using LibSis.Domain.Core.Notifications;
using LibSis.Domain.Interfaces;
using LibSis.Infra.CrossCutting.Bus;
using LibSis.Infra.Data.Context;
using LibSis.Infra.Data.Repository;
using LibSis.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibSis.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
            // Application
            services.AddScoped<IBookAppService, BookAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewBookCommand, bool>, BookCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBookCommand, bool>, BookCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBookCommand, bool>, BookCommandHandler>();

            // Infra - Data
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LibSisContext>();
        }
    }
}