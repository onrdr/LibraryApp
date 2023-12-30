using FluentValidation;

namespace Business.Services.Validators.Common;

public static class ShouldBeWithinAMonthRange
{
    public static IRuleBuilderOptions<T, DateTimeOffset> DateTimeShouldBeWithinAMonthRange<T>(this IRuleBuilder<T, DateTimeOffset> rule)
    {
        return rule
            .Must(dateTime => dateTime < DateTimeOffset.Now.AddDays(30))
            .WithMessage("Return date should be within 30 days");
    }
}

