using BuildingWorks.Common.Constants;
using BuildingWorks.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;

namespace BuildingWorks.Repositories.Common;

public interface IDatabaseChanges
{
    Task TrySaveChanges(string errorMessage = "");
}

public class DatabaseChanges : IDatabaseChanges
{
    private readonly BuildingWorksDbContext _context;

    public DatabaseChanges(BuildingWorksDbContext context)
    {
        _context = context;
    }

    public async Task TrySaveChanges(string errorMessage = "")
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException exception)
        {
            ThrowExceptionIfEntityAlreadyExistInDatabase(exception, errorMessage);
        }
    }

    private void ThrowExceptionIfEntityAlreadyExistInDatabase(DbUpdateException exception, string displayedErrorMessage = "")
    {
        var message = exception.InnerException != null ? exception.InnerException.Message : exception.Message;

        if (message.Contains(ErrorsConstants.Codes.DuplicateDatabaseEntity.ToString()))
        {
            if (string.IsNullOrWhiteSpace(displayedErrorMessage))
            {
                displayedErrorMessage = message;
            }
            throw new ValidationException(displayedErrorMessage);
        }

        throw exception;
    }
}
