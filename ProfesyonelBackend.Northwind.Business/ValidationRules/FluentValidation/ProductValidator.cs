using FluentValidation;
using ProfesyonelBackend.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty()
                .WithMessage("Kategori Id boş olamaz");

            RuleFor(p => p.ProductName).NotEmpty()
                .WithMessage("Ürün adı boş olamaz.");

            RuleFor(p => p.UnitPrice).GreaterThan(0)
                .WithMessage("Birim fiyat 0'dan büyük olmalı.");

            RuleFor(p => p.QuantityPerUnit).NotEmpty()
                .WithMessage("QuantityPerUnit boş olamaz.");

            RuleFor(p => p.ProductName).Length(2, 40)
                .WithMessage("Ürün adı min. 2, max. 20 karakter olabilir.");

            // Kendi mantığımızla bu şeklide kural uydurup yazabiliriz
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1) 
                .WithMessage("Kategorisi 2 olan ürünün fiyatı 20 den büyük olmalıdır.");

            //bir metot aracılığıyla kendi kurallarımızı yazabiliriz.
            //RuleFor(p => p.ProductName).Must(StartsWithA);
           
        }

        /*private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }*/
    }
}
