using Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebUI.Controllers;

[Authorize]
public class BorrowerController(IBorrowerService _borrowerService) : Controller
{
    #region API Calls
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBorrowerViewModel addBorrowerViewModel)
    {
        var addBorrowerResult = await _borrowerService.AddBorrowerAsync(addBorrowerViewModel, default);

        return Json(new {serviceResponse = addBorrowerResult.Success, message = addBorrowerResult.Message });
    }
    #endregion
}
