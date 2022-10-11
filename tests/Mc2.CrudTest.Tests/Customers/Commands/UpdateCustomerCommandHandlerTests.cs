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

public class UpdateCustomerCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public UpdateCustomerCommandHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
    }

    [Fact]
    public async Task UpdateCustomer_WhenEverythingIsOk_ShouldBeSucceeded()
    {
        var handler = new UpdateCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Sina@test.com",
            BankAccountNumber = "70149340835549500",
        };

        var operation = await handler.Handle(command, CancellationToken.None);

        operation.Value.ShouldBeOfType<CustomerModel>();

        operation.Succeeded.ShouldBeTrue();
    }

    [Fact]
    public async Task UpdateCustomer_WhenBankAccountNumberIsNotValid_ShouldBeFailed()
    {
        var handler = new UpdateCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Sina@test.com",
            BankAccountNumber = "70149675764765835549500",
        };

        var operation = await handler.Handle(command, CancellationToken.None);

        operation.Succeeded.ShouldBeFalse();
    }

    [Fact]
    public async Task UpdateCustomer_WhenEmailIsNotValid_ShouldBeFailed()
    {
        var handler = new UpdateCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Siyjhcgtescom",
            BankAccountNumber = "70149340835549500",
        };

        var operation = await handler.Handle(command, CancellationToken.None);

        operation.Succeeded.ShouldBeFalse();
    }

    [Fact]
    public async Task UpdateCustomer_WhenEmailExistsBefore_ShouldBeFailed()
    {
        var handler = new UpdateCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Hadi@test.com",
            BankAccountNumber = "70149340835549500",
        };

        var operation = await handler.Handle(command, CancellationToken.None);

        operation.Succeeded.ShouldBeFalse();
    }
}
