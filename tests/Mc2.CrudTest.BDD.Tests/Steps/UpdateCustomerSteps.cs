using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mc2.CrudTest.Application.Handlers.Customers;
using Mc2.CrudTest.Application.Infrastructure.Errors;
using Mc2.CrudTest.Application.Infrastructure.FluentValidation;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.Validators.Customers;
using Mc2.CrudTest.Persistence;
using Shouldly;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.BDD.Tests.Steps;

[Binding]
public sealed class UpdateCustomerSteps
{
    private readonly UnitOfWork _unitOfWork;
    private UpdateCustomerCommand _updateCommand;
    
    public UpdateCustomerSteps(UpdateCustomerCommand updateCommand)
    {
        _updateCommand = updateCommand;
        _unitOfWork = new UnitOfWork(new InMemoryDbContextFactory().CreateDbContext());
    }
    
    [Given(@"customer information for update are \((.*),(.*),(.*),(.*),(.*),(.*),(.*)\)")]
    public async Task GivenCustomerInformationForUpdateAre(int id, string firstName, string lastName, string dateOfBirth, 
        string phoneNumber, string email, string bankAccountNumber)
    {
        _updateCommand = new UpdateCustomerCommand
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = DateTime.ParseExact(dateOfBirth, "yyyyMMdd", null),
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber,
        };
        
        var addCustomerHandler = new AddCustomerCommandHandler(_unitOfWork);

        // Filling database with customers
        var sampledata1 = new AddCustomerCommand
        {
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-21),
            PhoneNumber = "+989220922323",
            Email = "Sina@test.com",
            BankAccountNumber = "4999999999999103",
        };
        _ = await addCustomerHandler.Handle(sampledata1, CancellationToken.None);
        var sampledata2 = new AddCustomerCommand
        {
            FirstName = "Ali",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-32),
            PhoneNumber = "+989167654343",
            Email = "Ali@test.com",
            BankAccountNumber = "4999999999999103",
        };
        _ = await addCustomerHandler.Handle(sampledata2, CancellationToken.None);
        var sampledata3 = new AddCustomerCommand
        {
            FirstName = "Mohammad",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-53),
            PhoneNumber = "+989337654242",
            Email = "Mohammad@test.com",
            BankAccountNumber = "4999999999999103",
        };
        _ = await addCustomerHandler.Handle(sampledata3, CancellationToken.None);
        await  _unitOfWork.CommitAsync();
    }

    [When(@"the update validation result is succeeded")]
    public async Task WhenTheUpdateValidationResultIsSucceeded()
    {
        var validation = await new UpdateCustomerValidator().ValidateAsync(_updateCommand);
        validation.IsValid.ShouldBeTrue();
    }

    [Then(@"the update operation result should be succeeded")]
    public async Task ThenTheUpdateOperationResultShouldBeSucceeded()
    {
        var handler = new UpdateCustomerCommandHandler(_unitOfWork);
        var operation = await handler.Handle(_updateCommand, CancellationToken.None);
        operation.Succeeded.ShouldBeTrue();
    }

    [Then(@"the update operation result should be failed with error code (\d+)")]
    public async Task ThenTheUpdateOperationResultShouldBeFailedWithErrorCode(int expectedErrorCode)
    {
        var updateCustomerHandler = new UpdateCustomerCommandHandler(_unitOfWork);

        var operation = await updateCustomerHandler.Handle(_updateCommand, CancellationToken.None);
        operation.Succeeded.ShouldBeFalse();
        ((ErrorModel)operation.Value).Code.ShouldBeEquivalentTo(expectedErrorCode);
    }

    [Then(@"the update validation result should be failed with error code (\d+)")]
    public async Task ThenTheUpdateValidationResultShouldBeFailedWithErrorCode(int expectedErrorCode)
    {
        var validation = await new UpdateCustomerValidator().ValidateAsync(_updateCommand);
        validation.IsValid.ShouldBeFalse();
        ((ErrorModel)validation.GetFirstCustomState()).Code.ShouldBeEquivalentTo(expectedErrorCode);
    }
}