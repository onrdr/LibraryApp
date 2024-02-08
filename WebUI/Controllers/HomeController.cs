using Business.Services.Abstract;
using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Identity;
using Models.ViewModels;
using System.Security.Claims;

namespace WebUI.Controllers;

public class HomeController(
    SignInManager<AppUser> _signInManager,
    IIdentityService _identityService) : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    #region Login
    public IActionResult Login(string returnUrl)
    {
        if (!string.IsNullOrEmpty(returnUrl))
        {
            TempData["ReturnUrl"] = returnUrl;
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var loginResult = await _identityService.LoginAsync(model);
        if (!loginResult.Success)
        {
            TempData["ErrorMessage"] = loginResult.Message;
            return View();
        }

        TempData["SuccessMessage"] = loginResult.Message;
        return TempData["ReturnUrl"] is not string returnUrl ? View() : Redirect(returnUrl);
    }
    #endregion

    #region ChangePassword
    [Authorize]
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        string? email = User.FindFirstValue(ClaimTypes.Email);

        var changeResult = await _identityService.ChangePasswordAsync(email ,model);
        if (!changeResult.Success)
        {
            TempData["ErrorMessage"] = changeResult.Message;
            return View();
        }

        TempData["SuccessMessage"] = changeResult.Message;
        return RedirectToAction(nameof(Index));
    }


    #endregion

    #region Logout
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        TempData["SuccessMessage"] = Messages.LogoutSuccessfull;

        return RedirectToAction(nameof(Index));
    }
    #endregion
}
