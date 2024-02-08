using AutoMapper;
using Business.Services.Abstract;
using Core.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebUI.Controllers;
[Authorize]

public class BookController(
    IBookService _bookService,
    IMapper _mapper,
    IValidator<LendBookViewModel> __lendBookModelValidator,
    IWebHostEnvironment _webHostEnvironment) : Controller
{
    #region List Books
    public IActionResult Index()
    {
        return View();
    }
    #endregion

    #region Lend Book
    public async Task<IActionResult> Lend(Guid id)
    {
        var bookResult = await _bookService.GetBookByIdAsync(id, default);
        if (!bookResult.Success)
        {
            TempData["ErrorMessage"] = bookResult.Message;
            return View();
        }

        return View(_mapper.Map<LendBookViewModel>(bookResult.Data));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Lend(LendBookViewModel lendBookViewModel)
    {
        var validationResult = __lendBookModelValidator.Validate(lendBookViewModel);
        if (!validationResult.IsValid)
        {
            TempData["ErrorMessage"] = validationResult.Errors.First().ToString();
            return RedirectToAction(nameof(Lend), new { id = lendBookViewModel.Id });
        }

        var bookResult = await _bookService.UpdateLendedBookAsync(lendBookViewModel, default);
        if (!bookResult.Success)
        {
            TempData["ErrorMessage"] = bookResult.Message;
            return RedirectToAction(nameof(Lend), new { id = lendBookViewModel.Id });
        }

        TempData["SuccessMessage"] = Messages.LendBookSuccessfull;
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Return Book
    public async Task<IActionResult> Return(Guid id)
    {
        var bookResult = await _bookService.UpdateReturnedBookAsync(id, default);
        if (!bookResult.Success)
        {
            TempData["ErrorMessage"] = bookResult.Message;
            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = Messages.ReturnBookSuccessfull;
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Add Book
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(AddBookViewModel addBookViewModel, IFormFile? file)
    {
        HandleImageUpload(addBookViewModel, file);

        var addBookResult = await _bookService.AddBookAsync(addBookViewModel, default);
        if (!addBookResult.Success)
        {
            TempData["ErrorMessage"] = addBookResult.Message;
            return View();
        }

        TempData["SuccessMessage"] = addBookResult.Message;
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region API Calls

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllBooksWithAuthorAndBorrowerAsync(c => true, default);
        return Json(new { data = books.Data.OrderBy(b => b.Name) });
    }

    #endregion

    #region Image Upload 
    protected void HandleImageUpload(AddBookViewModel model, IFormFile? file)
    {
        var wwwRootPath = _webHostEnvironment.WebRootPath;

        if (file is not null)
            CreateNewImage(model, file, wwwRootPath);
    }

    protected static void CreateNewImage(AddBookViewModel model, IFormFile file, string wwwRootPath)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var imagePath = Path.Combine(wwwRootPath, "images", "book", fileName);

        using var fileStream = new FileStream(imagePath, FileMode.Create);
        file.CopyTo(fileStream);

        model.ImageUrl = @$"images\book\" + fileName;
    }
    #endregion
}
