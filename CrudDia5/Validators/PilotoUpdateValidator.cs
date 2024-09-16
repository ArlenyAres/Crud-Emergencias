using FluentValidation;
using CrudDia5.DTOs;

public class PilotoUpdateValidator : AbstractValidator<PilotoUpdateDto>
{
    public PilotoUpdateValidator()
    {
        RuleFor(p => p.NombreCompleto).NotEmpty().WithMessage("NombreCompleto es obligatorio.");

        RuleFor(p => p.NumeroLicencia).NotEmpty().WithMessage("NumeroLicencia es obligatorio.");

        RuleFor(p => p.HorasVueloAcumuladas).GreaterThanOrEqualTo(0).WithMessage("HorasVueloAcumuladas debe ser mayor o igual a 0.");
    }
}
