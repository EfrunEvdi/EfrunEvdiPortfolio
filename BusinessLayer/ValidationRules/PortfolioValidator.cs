using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı alanı boş geçilemez.").MinimumLength(5).WithMessage("Proje adı minimum 5 karakter olmalıdır.");
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform görsel alanı boş geçilemez.");
            RuleFor(x => x.ProjectUrlTitle).NotEmpty().WithMessage("Proje başlık alanı boş geçilemez.");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Proje URL alanı boş geçilemez.");
            RuleFor(x => x.ImageUrl1).NotEmpty().WithMessage("Proje görsel1 alanı boş geçilemez.");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Proje görsel2 alanı boş geçilemez.");
            RuleFor(x => x.ImageUrl3).NotEmpty().WithMessage("Proje görsel3 alanı boş geçilemez.");
            RuleFor(x => x.ImageUrl4).NotEmpty().WithMessage("Proje görsel4 alanı boş geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Proje ücret alanı boş geçilemez.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Proje tamamlanma oranı alanı boş geçilemez.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Proje durum alanı boş geçilemez.");
        }
    }
}
