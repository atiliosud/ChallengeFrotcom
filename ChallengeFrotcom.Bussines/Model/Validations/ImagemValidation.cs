using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Bussines.Model.Validations
{
    public class ImagemValidation : AbstractValidator<Imagem>
    {
        public ImagemValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Field {PropertyName} needs to be provided");
        }
    }
}
