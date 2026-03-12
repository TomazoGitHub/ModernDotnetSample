using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDotnetSample.Domain.Events;

public class OrderCreatedEvent : IDomainEvent
{
    public Guid OrderId { get; }

    public DateTime OccurredOn { get; }

    public OrderCreatedEvent(Guid orderId)
    {
        OrderId = orderId;
        OccurredOn = DateTime.UtcNow;
    }
}