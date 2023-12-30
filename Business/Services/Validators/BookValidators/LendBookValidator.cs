using Business.Services.Validators.Common;
using FluentValidation;
using Models.ViewModels;

namespace Business.Services.Validators.BookValidators;

public class LendBookValidator : AbstractValidator<LendBookViewModel>
{
    public LendBookValidator()
    {
        RuleFor(x => x.ReturnDate)
            .DateTimeShouldBeGreaterThanNow()
            .DateTimeShouldBeWithinAMonthRange();
    }
}
