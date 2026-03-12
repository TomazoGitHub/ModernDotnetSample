using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using ModernDotnetSample.Domain.Entities;
using ModernDotnetSample.Domain.Interfaces;

namespace ModernDotnetSample.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _repository;

    public CreateOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = new Order(request.CustomerId);

        await _repository.AddAsync(order, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}