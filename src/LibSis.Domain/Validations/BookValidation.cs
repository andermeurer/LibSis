using System;
using LibSis.Domain.Commands;
using FluentValidation;

namespace LibSis.Domain.Validations
{
    public abstract class BookValidation<T> : AbstractValidator<T> where T : BookCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }


        protected void ValidateAuthor()
        {
            RuleFor(c => c.Author)
                .NotEmpty().WithMessage("Please ensure you have entered the Author")
                .Length(2, 150).WithMessage("The Author must have between 2 and 150 characters"); ;
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}