using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Bunları tek satırda yazma. Ayrı ayrı yaz. Single responsibility prensibine göre daha doğru.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).MaximumLength(10);

            //RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adı 'a' harfi ile başlamalıdır."); //ProductName 'a' ya da 'A' ile başlasın gibi kendi kuralımızı bu şekilde ekstra metod oluşturup koyabiliriz.

            RuleFor(p => p.CategoryId).NotEmpty();

            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId.Equals(2));//Bu şekil kategori id'si 2 olanlar için minimum fiyat 10 olabilir gibi şartlı bir kural da koyabiliriz.

            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => (int)p.UnitsInStock).GreaterThan(0);
        }

        private bool StartWithA(string arg)
        {
            return arg.ToLower().StartsWith("a");
        }
    }
}
