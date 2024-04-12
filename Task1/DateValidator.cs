using FluentValidation;
namespace Task1
{
    public class DateValidator : AbstractValidator<RegistrationModel>
    {
        public DateValidator()
        {
            RuleFor(m=>m.WantedDate).GreaterThanOrEqualTo(m=>m.CurrentDate).WithMessage("Date must be later or equal current time");
        }
    }
}
