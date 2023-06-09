﻿using FluentValidation;
using Product_Inventory_Management_System.Models;

namespace Product_Inventory_Management_System.Validators
{
    public class ProductInformationValidator : AbstractValidator<ProductInformation>
    {
        public ProductInformationValidator() 
        {

            GeneralRules();
        }

        private void GeneralRules() 
        {
            this.RuleFor(_ => _.ProductId)
                .GreaterThanOrEqualTo(0);

            this.RuleFor(_ => _.Name)
                .MaximumLength(100);

            this.RuleFor(_ => _.Description)
                .MaximumLength(300);

            this.RuleFor(_ => _.Price)
                .GreaterThan(0);

            this.RuleFor(_ => _.Quantity)
                .GreaterThan(0);
        }

    }
}
