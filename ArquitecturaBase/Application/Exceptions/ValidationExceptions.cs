using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; set; }

        public ValidationExceptions() : base("Se presentaron uno o mas errores de validacion")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName,
                                      e => e.ErrorMessage).ToDictionary(failureGroup => failureGroup.Key,
                                                                        failureGroup => failureGroup.ToArray());
        }
    }
}
