using ModernDotnetSample.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDotnetSample.Domain.Entities;

public class OrderItem : Entity
{
    public Guid ProductId { get; private set; }

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }

    private OrderItem() { }

    public OrderItem(Guid productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}
