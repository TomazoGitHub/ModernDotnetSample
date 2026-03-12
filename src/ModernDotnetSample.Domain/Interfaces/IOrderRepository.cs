using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModernDotnetSample.Domain.Entities;

namespace ModernDotnetSample.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken ct);

    Task AddAsync(Order order, CancellationToken ct);

    Task SaveChangesAsync(CancellationToken ct);
}