namespace Auth.Domain.Base;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task SaveEntitiesAsync(CancellationToken cancellationToken = default);
}