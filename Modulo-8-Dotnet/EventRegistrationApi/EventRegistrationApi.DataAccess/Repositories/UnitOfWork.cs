using EventRegistrationApi.DataAccess.Context;
using EventRegistrationApi.Domain.Abstractions.Repositories;


namespace EventRegistrationApi.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EventRegistrationApiDbContext _context;

    public UnitOfWork(EventRegistrationApiDbContext context)
    {
        _context = context;
    }

    public Task CommitAsync() =>
        _context.SaveChangesAsync();

    public void RollbackAsync()
    {
    }
}
