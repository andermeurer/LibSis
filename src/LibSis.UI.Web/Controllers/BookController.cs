using System;
using System.Linq;
using LibSis.Application.Interfaces;
using LibSis.Application.ViewModels;
using LibSis.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibSis.UI.Web.Controllers
{
    [AllowAnonymous]
    public class BookController : BaseController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService, 
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("book-management/book-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = _bookAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [HttpGet]
        [Route("book-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("book-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return View(bookViewModel);
            _bookAppService.Register(bookViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Book Registered!";

            return View(bookViewModel);
        }
        
        [HttpGet]
        [Route("book-management/edit-book/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookViewModel = _bookAppService.GetById(id.Value);

            if (bookViewModel == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        [HttpPost]
        [Route("book-management/edit-book/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return View(bookViewModel);

            _bookAppService.Update(bookViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Book Updated!";

            return View(bookViewModel);
        }

        [HttpGet]
        [Route("book-management/remove-book/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookViewModel = _bookAppService.GetById(id.Value);

            if (bookViewModel == null)
            {
                return NotFound();
            }

            return View(bookViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("book-management/remove-book/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookAppService.Remove(id);

            if (!IsValidOperation()) return View(_bookAppService.GetById(id));

            ViewBag.Sucesso = "Book Removed!";
            return RedirectToAction("Index");
        }
    }
}
