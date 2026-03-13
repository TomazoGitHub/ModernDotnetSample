using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModernDotnetSample.Domain.Common;
using ModernDotnetSample.Domain.Enums;
using ModernDotnetSample.Domain.Events;

namespace ModernDotnetSample.Domain.Entities;

public class Order : AggregateRoot
{
    private readonly List<OrderItem> _items = new();

    public Guid CustomerId { get; private set; }

    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { } // EF Core

    public Order(Guid customerId)
    {
        CustomerId = customerId;
        Status = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;

        AddDomainEvent(new OrderCreatedEvent(Id));
    }

    public void AddItem(Guid productId, int quantity, decimal price)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero");

        var item = new OrderItem(productId, quantity, price);

        _items.Add(item);
    }

    public decimal GetTotal()
    {
        return _items.Sum(x => x.Price * x.Quantity);
    }

    public void MarkAsPaid()
    {
        if (Status != OrderStatus.Created)
            throw new InvalidOperationException("Order cannot be paid");

        Status = OrderStatus.Paid;
    }
}