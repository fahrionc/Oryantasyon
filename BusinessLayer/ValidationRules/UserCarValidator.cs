using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserCarValidator : AbstractValidator<UserCar>
    {
        public UserCarValidator()
        {
            RuleFor(x => x.ActiveWorkTime).NotEmpty().WithMessage("Aktif çalışma süresi boş geçilemez");
            RuleFor(x => x.MaintenanceTime).NotEmpty().WithMessage("Bakım süresi boş geçilemez");
            RuleFor(x => x.IdleTime).NotEmpty().WithMessage("Boşta bekleme süresi boş geçilemez");
        }
    }
}
