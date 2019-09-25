using System;
using LibSis.Domain.Validations;

namespace LibSis.Domain.Commands
{
    public class RemoveBookCommand : BookCommand
    {
        public RemoveBookCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}