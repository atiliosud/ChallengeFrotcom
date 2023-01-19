using FluentValidation;

namespace ChallengeFrotcom.Bussines.Model.Validations
{
    public class CategorieValidation : AbstractValidator<Categorie>
    {
        public CategorieValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Field {PropertyName} needs to be provided");
        }
    }
}
