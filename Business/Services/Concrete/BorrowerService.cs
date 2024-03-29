﻿using AutoMapper;
using Business.Services.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Repositories.Abstract;
using Models.Entities.Concrete;
using Models.ViewModels;

namespace Business.Services.Concrete;

public class BorrowerService(
    IBorrowerRepository _borrowerRepository,
    IMapper _mapper) : IBorrowerService
{
    private const int MAX_ALLOWED_BOOK_COUNT = 5;

    #region Read Borrower / Borrowers
    public async Task<IDataResult<Borrower>> GetBorrowerIfAllowedToBorrowBooksAsync(string libraryBorrowerId, CancellationToken ct)
    {
        var borrower = await _borrowerRepository.GetBorrowerByLibraryBorrowerIdAsync(libraryBorrowerId, ct);
        if (borrower == null)
        {
            return new ErrorDataResult<Borrower>(message: Messages.BorrowerNotFound);
        }

        var allowResult = await CheckIfBorrowerAllowedToBorrowBooksAsync(libraryBorrowerId, ct);
        if (!allowResult.Success)
        {
            return allowResult;
        }

        return new SuccessDataResult<Borrower>(data: borrower);
    }
    #endregion

    #region Add Borrower
    public async Task<IResult> AddBorrowerAsync(AddBorrowerViewModel model, CancellationToken ct)
    {
        var borrower = await _borrowerRepository.GetBorrowerByLibraryBorrowerIdAsync(model.LibraryBorrowerId, ct);
        if (borrower is not null)
        {
            return new ErrorResult(Messages.BorrowerAlreadyExists);
        }

        int addResult = await CompleteAddProcessAsync(model, ct);
        return addResult > 0
            ? new SuccessResult(Messages.BorrowerAddSuccessfull)
            : new ErrorResult(Messages.BorrowerAddError);
    }
    #endregion

    #region Helper Methods
    private async Task<IDataResult<Borrower>> CheckIfBorrowerAllowedToBorrowBooksAsync(string libraryBorrowerId, CancellationToken ct)
    {
        var hasOverDueBook = await _borrowerRepository.DoesBorrowerHaveOverDueBookAsync(libraryBorrowerId, ct);

        return hasOverDueBook
            ? new ErrorDataResult<Borrower>(message: Messages.BookOverDueError)
            : await CheckIfBorrowerReachedMaximumAllowedBookCount(libraryBorrowerId, ct);
    }

    private async Task<IDataResult<Borrower>> CheckIfBorrowerReachedMaximumAllowedBookCount(string libraryBorrowerId, CancellationToken ct)
    {
        var bookCount = await _borrowerRepository.GetBorrowerBookCountAsync(libraryBorrowerId, ct);

        return bookCount >= MAX_ALLOWED_BOOK_COUNT
            ? new ErrorDataResult<Borrower>(message: Messages.MaxBookCountError)
            : new SuccessDataResult<Borrower>();
    }

    private async Task<int> CompleteAddProcessAsync(AddBorrowerViewModel model, CancellationToken ct)
    {
        var borrowerToAdd = _mapper.Map<Borrower>(model);

        var addResult = await _borrowerRepository.AddAsync(borrowerToAdd, ct);
        return addResult;
    }
    #endregion
}
