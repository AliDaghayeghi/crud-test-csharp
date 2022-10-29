using Mc2.CrudTest.Application.Handlers.Customers;
using Mc2.CrudTest.Application.Infrastructure.Errors;
using Mc2.CrudTest.Application.Infrastructure.FluentValidation;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.Validators.Customers;
using Mc2.CrudTest.Persistence;
using Shouldly;

namespace Mc2.CrudTest.BDD.Tests.Steps;

[Binding]
public class AddCustomerSteps
{
    private readonly UnitOfWork _unitOfWork;
    private AddCustomerCommand _command;
    
    public AddCustomerSteps(AddCustomerCommand command)
    {
        _command = command;
        _unitOfWork = new UnitOfWork(new InMemoryDbContextFactory().CreateDbContext());
    }
    
    [Given(@"customer information are \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
    public void GivenCustomerInformationAre(string firstName, string lastName, string dateOfBirth, 
        string phoneNumber, string email, string bankAccountNumber)
    {
        _command = new AddCustomerCommand
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = DateTime.ParseExact(dateOfBirth, "yyyyMMdd", null),
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber,
        };
    }

    [When(@"the validation result is succeeded")]
    public async Task WhenTheValidationResultIsSucceeded()
    {
        var validation = await new AddCustomerValidator().ValidateAsync(_command);
        validation.IsValid.ShouldBeTrue();
    }

    [Then(@"the operation result should be succeeded")]
    public async Task ThenTheOperationResultShouldBeSucceeded()
    {
        var handler = new AddCustomerCommandHandler(_unitOfWork);
        var operation = await handler.Handle(_command, CancellationToken.None);
        operation.Succeeded.ShouldBeTrue();
    }

    [Then(@"the operation result should be failed with error code (\d+)")]
    public async Task ThenTheOperationResultShouldBeFailedWithErrorCode(int expectedErrorCode)
    {
        var handler = new AddCustomerCommandHandler(_unitOfWork);
        
        // Filling database with repeated cases
        var sampledata1 = new AddCustomerCommand
        {
            FirstName = "Sina",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-21),
            PhoneNumber = "+14844578895",
            Email = "Sina@test.com",
            BankAccountNumber = "4999999999999103",
        };
        _ = await handler.Handle(sampledata1, CancellationToken.None);
        var sampledata2 = new AddCustomerCommand
        {
            FirstName = "Ali",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-32),
            PhoneNumber = "+14844578895",
            Email = "Ali@test.com",
            BankAccountNumber = "4999999999999103",
        };
        _ = await handler.Handle(sampledata2, CancellationToken.None);
        var sampledata3 = new AddCustomerCommand
        {
            FirstName = "Mohammad",
            LastName = "Ahmadi",
            DateOfBirth = DateTime.UtcNow.AddYears(-53),
            PhoneNumber = "+14844578895",
            Email = "Mohammad@test.com",
            BankAccountNumber = "4999999999999103",
        };
        _ = await handler.Handle(sampledata3, CancellationToken.None);
        await  _unitOfWork.CommitAsync();
        
        var operation = await handler.Handle(_command, CancellationToken.None);
        operation.Succeeded.ShouldBeFalse();
        ((ErrorModel)operation.Value).Code.ShouldBeEquivalentTo(expectedErrorCode);
    }

    [Then(@"the validation result should be failed with error code (\d+)")]
    public async Task ThenTheValidationResultShouldBeFailedWithErrorCode(int expectedErrorCode)
    {
        var validation = await new AddCustomerValidator().ValidateAsync(_command);
        validation.IsValid.ShouldBeFalse();
        ((ErrorModel)validation.GetFirstCustomState()).Code.ShouldBeEquivalentTo(expectedErrorCode);
    }
}