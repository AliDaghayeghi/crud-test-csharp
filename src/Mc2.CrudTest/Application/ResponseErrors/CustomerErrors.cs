using Mc2.CrudTest.Application.Infrastructure.Errors;

namespace Mc2.CrudTest.Application.ResponseErrors;

public static class CustomerErrors
{
    // Code ranges for Customer is between 12001 and 12050

    public static ErrorModel NotFoundCustomerError = new ErrorModel(
        code: 12001,
        title: "Customer Error",
        message: "Not found customer with given customer id.");

    public static ErrorModel EmailAddressUniquenessError = new ErrorModel(
        code: 12002,
        title: "Customer Error",
        message: "This email address was registered before.");

    public static ErrorModel InvalidCustomerIdError = new ErrorModel(
        code: 12003,
        title: "Customer Error",
        message: "Invalid customer id.");

    public static ErrorModel InvalidFirstNameError = new ErrorModel(
        code: 12004,
        title: "Customer Error",
        message: "First name is required and its length should be between 3 to 30 characters.");

    public static ErrorModel InvalidLastNameError = new ErrorModel(
        code: 12005,
        title: "Customer Error",
        message: "Last name is required and its length should be between 3 to 30 characters.");

    public static ErrorModel InvalidPhoneNumberError = new ErrorModel(
        code: 12006,
        title: "Customer Error",
        message: "Phone number is not valid.");

    public static ErrorModel InvalidBankAccountNumberError = new ErrorModel(
        code: 12007,
        title: "Customer Error",
        message: "Bank account number is not valid.");

    public static ErrorModel InvalidEmailError = new ErrorModel(
        code: 12008,
        title: "Customer Error",
        message: "Email address is not valid.");

    public static ErrorModel InvalidDateOfBirthError = new ErrorModel(
        code: 12009,
        title: "Customer Error",
        message: "Date of birth is required.");
}