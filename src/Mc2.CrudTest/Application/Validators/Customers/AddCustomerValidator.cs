using FluentValidation;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using Mc2.CrudTest.Application.ResponseErrors;
using PhoneNumbers;

namespace Mc2.CrudTest.Application.Validators.Customers;

public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
{
    public AddCustomerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithState(_ => CustomerErrors.InvalidFirstNameError)
            .Length(min: 3, max: 30)
            .WithState(_ => CustomerErrors.InvalidFirstNameError);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithState(_ => CustomerErrors.InvalidLastNameError)
            .Length(min: 3, max: 30)
            .WithState(_ => CustomerErrors.InvalidLastNameError);

        RuleFor(x => x.PhoneNumber)
            .Must(x => x.StartsWith("+") && PhoneNumberUtil.GetInstance()
                .IsValidNumber(PhoneNumberUtil.GetInstance().Parse(x, "")))
            .WithState(_ => CustomerErrors.InvalidPhoneNumberError)
            .When(x => x.PhoneNumber is not null);

        RuleFor(x => x.BankAccountNumber)
            .CreditCard()
            .WithState(_ => CustomerErrors.InvalidBankAccountNumberError)
            .When(x => x.BankAccountNumber is not null);

        RuleFor(x => x.Email)
            .MaximumLength(320)
            .WithState(_ => CustomerErrors.InvalidEmailError)
            .NotEmpty()
            .WithState(_ => CustomerErrors.InvalidEmailError)
            .EmailAddress()
            .WithState(_ => CustomerErrors.InvalidEmailError);

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithState(_ => CustomerErrors.InvalidDateOfBirthError);
    }
}