using FluentValidation;
using Task1.Models;
namespace Task1
{
    public class DateValidator : AbstractValidator<RegistrationModel>
    {
        public DateValidator()
        {
            RuleFor(m => m.WantedDate)
                .GreaterThanOrEqualTo(m => m.CurrentDate)
                .WithMessage("Date must be later or equal current time");

            RuleFor(m => m.SelectedValue)
                .NotEqual("основи")
                .When(m => m.WantedDate.DayOfWeek == DayOfWeek.Monday)
                .WithMessage("Основи can't be in Monday");
        }
    }
}
