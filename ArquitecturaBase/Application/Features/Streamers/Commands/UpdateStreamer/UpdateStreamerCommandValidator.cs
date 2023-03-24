using FluentValidation;

namespace Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(s => s.Name)
                   .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                   .NotNull().WithMessage("{Nombre} no puede ser nulo")
                   .MaximumLength(50).WithMessage("{Numbre} no puede exceder los 50 caracteres");
        }
    }
}
