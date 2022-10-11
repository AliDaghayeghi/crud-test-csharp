using Mc2.CrudTest.Application.Interfaces.Repositories.Customers;

namespace Mc2.CrudTest.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository Customers { get; }

    Task<bool> CommitAsync();
}
