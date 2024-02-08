using Business.Services.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Models.Identity;
using Models.ViewModels;

namespace Business.Services.Concrete;

public class IdentityService(
    UserManager<AppUser> _userManager,
    SignInManager<AppUser> _signInManager) : IIdentityService
{
    public async Task<IResult> LoginAsync(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is null)
        {
            return new ErrorResult(Messages.UserNotFound);
        }

        await _signInManager.SignOutAsync();
        var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
        if (!signInResult.Succeeded)
        {
            return new ErrorResult(Messages.LoginFailed);
        }

        return new SuccessResult(Messages.LoginSuccessfull);
    }

    public async Task<IResult> ChangePasswordAsync(string? currentEmail, ChangePasswordViewModel model)
    {
        if (currentEmail is null)
        {
            return new ErrorResult(Messages.UserNotFound);
        }

        var user = await _userManager.FindByEmailAsync(currentEmail);
        if (user == null)
        {
            return new ErrorResult(Messages.UserNotFound);
        }

        var currentPassword = model.CurrentPassword;
        var newPassword = model.NewPassword;

        var passwordCheckResult = await _userManager.CheckPasswordAsync(user, currentPassword);
        if (!passwordCheckResult)
        {
            return new ErrorResult(Messages.InvalidCurrentPassword);
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (!changePasswordResult.Succeeded)
        {
            var errorMessages = changePasswordResult.Errors.Select(e => e.Description).First();
            return new ErrorResult(errorMessages);
        }

        return new SuccessResult(Messages.PasswordChangeSuccess);
    }
}
