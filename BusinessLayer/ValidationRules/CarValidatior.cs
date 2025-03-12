using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CarValidatior : AbstractValidator<Car>
    {
        public CarValidatior()
        {
            RuleFor(x => x.CarName).NotEmpty().WithMessage("Araç ismi boş geçilemez");
            RuleFor(x => x.CarPlate).NotEmpty().WithMessage("Araç plakası boş geçilemez");
            RuleFor(x => x.ActiveWorkTime).NotEmpty().WithMessage("Aktif çalışma süresi boş geçilemez");
            RuleFor(x => x.MaintenanceTime).NotEmpty().WithMessage("Bakım süresi boş geçilemez");
            RuleFor(x => x.IdleTime).NotEmpty().WithMessage("Boşta bekleme süresi boş geçilemez");
            //RuleFor(x => x.CarName).MinimumLength(2).MaximumLength(20).WithMessage("Araç ismi en az 2 en çok 20 karakterden oluşmalıdır");
            //RuleFor(x => x.CarPlate).MinimumLength(5).MaximumLength(20).WithMessage("Araç plakası en az 5 en çok 20 karakterden oluşmalıdır");
        }
    }
}
