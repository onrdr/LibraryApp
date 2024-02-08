using Core.Utilities.Results;
using Models.ViewModels;

namespace Business.Services.Abstract;

public interface IIdentityService
{
    Task<IResult> LoginAsync(LoginViewModel loginViewModel);
    Task<IResult> ChangePasswordAsync(string? currentEmail, ChangePasswordViewModel model);
}
