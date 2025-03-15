using ApiProject.WebApi.Entities;
using FluentValidation;

namespace ApiProject.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ürün adı boş geçilemez")
                .MinimumLength(2)
                .WithMessage("Ürün adı 2 karakterden küçük olamaz")
                .MaximumLength(50)
                .WithMessage("Ürün adı 50 karakterden büyük olamaz");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Ürün fiyatı boş geçilemez")
                .LessThan(0)
                .WithMessage("Ürün fiyatı negatif değer olamaz");

        }
    }
}
