using LibSis.Domain.Validations;

namespace LibSis.Domain.Commands
{
    public class RegisterNewBookCommand : BookCommand
    {
        public RegisterNewBookCommand(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}