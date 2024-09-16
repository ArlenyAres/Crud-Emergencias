using CrudDia5.DTOs;
using FluentValidation;

namespace CrudDia5.Validators
{
    public class MisionEmergenciaInsertValidator : AbstractValidator<MisionEmergenciaInsertDto>
    {
        public MisionEmergenciaInsertValidator()
        {
            RuleFor(x => x.TipoMision).NotEmpty().WithMessage("El tipo de Mision de Emergencia no puede esta vacia").Length(2,40).WithMessage("El tipo de Mision debe tener entre 2 y 40 caracteres");

            RuleFor(x => x.Duracion).NotEmpty().WithMessage("LA fecha de la Mision de Emergencia es obligatoria").GreaterThan(0).WithMessage("La duracion de la misison debe ser mayor a 0");

            RuleFor(x => x.Destino).NotEmpty().WithMessage("El tipo de destino de Emergencia no puede esta vacio");
        }  

    }
}
