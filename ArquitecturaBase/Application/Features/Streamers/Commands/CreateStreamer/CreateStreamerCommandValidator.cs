using FluentValidation;

namespace Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(s => s.Name)
                   .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                   .NotNull().WithMessage("{Nombre} no puede ser nulo")
                   .MaximumLength(50).WithMessage("{Numbre} no puede exceder los 50 caracteres");
        }
    }
}
