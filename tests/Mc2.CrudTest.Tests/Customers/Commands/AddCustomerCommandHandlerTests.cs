using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Mc2.CrudTest.Application.Handlers.Customers;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Models.Base.Customers;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.Validators.Customers;
using Mc2.CrudTest.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Mc2.CrudTest.Tests.Customers.Commands;

public class AddCustomerCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public AddCustomerCommandHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
    }

    [Fact]
    public async Task AddCustomer_WhenEverythingIsOk_ShouldBeSucceeded()
    {
        var handler = new AddCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new AddCustomerCommand
        {
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Sina@test.com",
            BankAccountNumber = "4999999999999103",
        };

        var validation = await new AddCustomerValidator().ValidateAsync(command);
        validation.IsValid.ShouldBeTrue();
        
        var operation = await handler.Handle(command, CancellationToken.None);
        operation.Succeeded.ShouldBeTrue();
    }

    [Fact]
    public async Task AddCustomer_WhenBankAccountNumberIsNotValid_ShouldBeFailed()
    {
        var handler = new AddCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new AddCustomerCommand
        {
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Sina@test.com",
            BankAccountNumber = "64765823547283647823435549500",
        };

        var validation = await new AddCustomerValidator().ValidateAsync(command);
        validation.IsValid.ShouldBeFalse();
    }

    [Fact]
    public async Task AddCustomer_WhenEmailIsNotValid_ShouldBeFailed()
    {
        var handler = new AddCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new AddCustomerCommand
        {
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "Siyjhcgtescom",
            BankAccountNumber = "4999999999999103",
        };
        
        var validation = await new AddCustomerValidator().ValidateAsync(command);
        validation.IsValid.ShouldBeFalse();
    }

    [Fact]
    public async Task AddCustomer_WhenEmailExistsBefore_ShouldBeFailed()
    {
        var handler = new AddCustomerCommandHandler(_mockUnitOfWork.Object);

        var command = new AddCustomerCommand
        {
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            PhoneNumber = "+14844578895",
            Email = "hadi@test.com",
            BankAccountNumber = "4999999999999103",
        };
        
        var validation = await new AddCustomerValidator().ValidateAsync(command);
        validation.IsValid.ShouldBeTrue();

        var operation = await handler.Handle(command, CancellationToken.None);
        operation.Succeeded.ShouldBeFalse();
    }
}
