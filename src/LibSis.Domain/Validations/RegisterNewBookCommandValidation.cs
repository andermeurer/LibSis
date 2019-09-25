using LibSis.Domain.Commands;

namespace LibSis.Domain.Validations
{
    public class RegisterNewBookCommandValidation : BookValidation<RegisterNewBookCommand>
    {
        public RegisterNewBookCommandValidation()
        {
            ValidateName();
            ValidateAuthor();
        }
    }
}