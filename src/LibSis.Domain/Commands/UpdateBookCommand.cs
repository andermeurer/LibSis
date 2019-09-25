using System;
using LibSis.Domain.Validations;

namespace LibSis.Domain.Commands
{
    public class UpdateBookCommand : BookCommand
    {
        public UpdateBookCommand(Guid id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}