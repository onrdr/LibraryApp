using Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebUI.Controllers;

[Authorize]
public class BorrowerController(IBorrowerService _borrowerService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    #region API Calls
    [HttpGet]
    public async Task<IActionResult> BorrowerList()
    {
        var borrowers = await _borrowerService.GetAllBorrowersAsync(default);

        return Json(new { data = borrowers.Data.OrderBy(b => b.Name) });
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBorrowerViewModel addBorrowerViewModel)
    {
        var addBorrowerResult = await _borrowerService.AddBorrowerAsync(addBorrowerViewModel, default);

        return Json(new { serviceResponse = addBorrowerResult.Success, message = addBorrowerResult.Message });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteBorrowerResult = await _borrowerService.DeleteBorrowerAsync(id, default);

        return Json(new { serviceResponse = deleteBorrowerResult.Success, message = deleteBorrowerResult.Message });
    }
    #endregion
}
