using LibSis.Domain.Commands;

namespace LibSis.Domain.Validations
{
    public class RemoveBookCommandValidation : BookValidation<RemoveBookCommand>
    {
        public RemoveBookCommandValidation()
        {
            ValidateId();
        }
    }
}