using CrudDia5.DTOs;
using FluentValidation;


namespace CrudDia5.Validators
{
    public class PilotoInsertValidator : AbstractValidator<PilotoInsertDto>
    {
        public PilotoInsertValidator()
        {
            RuleFor(x => x.NombreCompleto).NotEmpty().WithMessage(" El nombre completo del piloto es obligatorio");


            RuleFor(x => x.NumeroLicencia).NotEmpty().WithMessage(" El numero de licencia del piloto es obligatorio").Length(5, 20).WithMessage(" El numero de licencia del piloto min 5 carateres y max 20");

            RuleFor(x => x.HorasVueloAcumuladas).GreaterThanOrEqualTo(0).WithMessage("Las horas de vuelo acumuladas deben ser mayor o igual a 0");
        }

    }
}
