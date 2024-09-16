using CrudDia5.DTOs;
using FluentValidation;

namespace CrudDia5.Validators
{
    public class MisionEmergenciaUpdateValidator : AbstractValidator<MisionEmergenciaUpdateDto>
    {
        public MisionEmergenciaUpdateValidator()
        {
            RuleFor(x => x.TipoMision).NotEmpty().WithMessage("El tipo de mision es obligatoria");
                
              
            RuleFor(x => x.Duracion).GreaterThan(0).WithMessage("La duracion debe ser mayor que 0");

         
        }
    }
}
