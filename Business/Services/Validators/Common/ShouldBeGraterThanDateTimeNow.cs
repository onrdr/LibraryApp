using FluentValidation;

namespace Business.Services.Validators.Common;

public static class ShouldBeGraterThanDateTimeNow
{
    public static IRuleBuilderOptions<T, DateTimeOffset> DateTimeShouldBeGreaterThanNow<T>(this IRuleBuilder<T, DateTimeOffset> rule)
    {
        return rule
            .Must(dateTime => dateTime > DateTimeOffset.Now)
            .WithMessage("The date should be greater than the current date.");
    }
}

