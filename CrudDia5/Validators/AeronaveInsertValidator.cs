using CrudDia5.DTOs;
using FluentValidation;

namespace CrudDia5.Validators
{
    public class AeronaveInsertValidator : AbstractValidator<AeronaveDto>
    {

       public AeronaveInsertValidator()
        {
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("El Tipo de la aeronave es obligatorio").Length(2, 20).WithMessage("El Tipo de la aeronave es obligatorio");

            RuleFor(x => x.Modelo).NotEmpty().WithMessage("El modelo de la aeronave es obligatorio");

            RuleFor(x => x.CapacidadCarga).GreaterThan(0).WithMessage("La capacidad debe ser mayor a 0");
        }
    }

    
}
