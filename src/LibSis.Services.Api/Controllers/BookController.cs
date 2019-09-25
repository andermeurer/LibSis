using System;
using System.Linq;
using LibSis.Application.Interfaces;
using LibSis.Application.ViewModels;
using LibSis.Domain.Core.Bus;
using LibSis.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibSis.Services.Api.Controllers
{
    [AllowAnonymous]
    public class BookController : ApiController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(
            IBookAppService bookAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet]
        [Route("book-management")]
        public IActionResult Get()
        {
            return Response(_bookAppService.GetAll().OrderBy(o => o.Name));
        }

        [HttpGet]
        [Route("book-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _bookAppService.GetById(id);

            return Response(customerViewModel);
        }     

        [HttpPost]
        [Route("book-management")]
        public IActionResult Post([FromBody]BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bookViewModel);
            }

            _bookAppService.Register(bookViewModel);

            return Response(bookViewModel);
        }
        
        [HttpPut]
        [Route("book-management")]
        public IActionResult Put([FromBody]BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(bookViewModel);
            }

            _bookAppService.Update(bookViewModel);

            return Response(bookViewModel);
        }

        [HttpDelete]
        [Route("book-management")]
        public IActionResult Delete(Guid id)
        {
            _bookAppService.Remove(id);
            
            return Response();
        }
    }
}
