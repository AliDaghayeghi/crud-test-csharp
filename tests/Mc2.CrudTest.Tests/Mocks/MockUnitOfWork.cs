using System;
using System.Collections.Generic;
using System.Linq;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Customers;
using Moq;

namespace Mc2.CrudTest.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            // Customers
            var fakeCustomers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Mohammadi",
                    DateOfBirth = DateTime.UtcNow.AddYears(-22),
                    PhoneNumber = "+16102448974",
                    Email = "ali@test.com",
                    BankAccountNumber = "13719713158835300",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Mohammad",
                    LastName = "Rezayi",
                    DateOfBirth = DateTime.UtcNow.AddYears(-24),
                    PhoneNumber = "+14845219702",
                    Email = "Hadi@test.com",
                    BankAccountNumber = "53153834006064000",
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            mockUnitOfWork.Setup(x => x.Customers.GetCustomerByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => fakeCustomers.SingleOrDefault(x => x.Id == id));

            mockUnitOfWork.Setup(x => x.Customers.Add(It.IsAny<Customer>()))
                .Callback((Customer customer) => fakeCustomers.Add(customer));

            mockUnitOfWork.Setup(x => x.Customers.Update(It.IsAny<Customer>()))
                .Callback((Customer updatedCustomer) =>
                {
                    var customer = fakeCustomers.SingleOrDefault(x => x.Id == updatedCustomer.Id);
                    fakeCustomers.Remove(customer);
                    fakeCustomers.Add(updatedCustomer);
                });

            return mockUnitOfWork;
        }
    }
}