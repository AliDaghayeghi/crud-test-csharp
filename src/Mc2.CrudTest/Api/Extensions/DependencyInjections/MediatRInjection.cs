using Mc2.CrudTest.Application.Behaviors;
using Mc2.CrudTest.Application.Behaviors.Customers;
using Mc2.CrudTest.Application.Infrastructure.Operations;
using Mc2.CrudTest.Application.Models.Commands.Customers;
using MediatR;

namespace Mc2.CrudTest.Api.Extensions.DependencyInjections;

internal static class MediatRInjection
{
    public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

        // Customers
        services.AddTransient(typeof(IPipelineBehavior<UpdateCustomerCommand, OperationResult>),
           typeof(UpdateCustomerValidationBehavior<UpdateCustomerCommand, OperationResult>));

        services.AddTransient(typeof(IPipelineBehavior<AddCustomerCommand, OperationResult>),
           typeof(AddCustomerValidationBehavior<AddCustomerCommand, OperationResult>));

        return services;
    }
}