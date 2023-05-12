using FluentValidation;
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
                .GreaterThan(0);

            this.RuleFor(_ => _.Name)
                .MaximumLength(20);

            this.RuleFor(_ => _.Description)
                .MinimumLength(20);

            this.RuleFor(_ => _.Price)
                .GreaterThan(0);

            this.RuleFor(_ => _.Quantity)
                .GreaterThan(0);
        }

    }
}
