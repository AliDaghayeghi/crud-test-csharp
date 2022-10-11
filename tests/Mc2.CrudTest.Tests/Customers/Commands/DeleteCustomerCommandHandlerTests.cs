using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Handlers.Customers;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Models.Base.Customers;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Mc2.CrudTest.Tests.Customers.Commands;

public class DeleteCustomerCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public DeleteCustomerCommandHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
    }

    [Fact]
    public async Task UpdateCustomer_WhenEverythingIsOk_ShouldBeSucceeded()
    {
        var handler = new DeleteCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new DeleteCustomerCommand
        {
            Id = 1
        };

        var operation = await handler.Handle(command, CancellationToken.None);

        operation.Value.ShouldBeOfType<CustomerModel>();

        operation.Succeeded.ShouldBeTrue();
    }

    [Fact]
    public async Task UpdateCustomer_WhenIdNotFound_ShouldBeFailed()
    {
        var handler = new DeleteCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new DeleteCustomerCommand
        {
            Id = 10
        };

        var operation = await handler.Handle(command, CancellationToken.None);

        operation.Succeeded.ShouldBeFalse();
    }
}