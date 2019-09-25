using LibSis.Domain.Commands;

namespace LibSis.Domain.Validations
{
    public class UpdateBookCommandValidation : BookValidation<UpdateBookCommand>
    {
        public UpdateBookCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateAuthor();
        }
    }
}