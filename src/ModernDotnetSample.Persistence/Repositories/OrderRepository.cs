using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModernDotnetSample.Domain.Entities;
using ModernDotnetSample.Domain.Interfaces;
using ModernDotnetSample.Persistence.Context;

namespace ModernDotnetSample.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order, CancellationToken ct)
    {
        await _context.Orders.AddAsync(order, ct);
    }

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return _context.Orders.FindAsync(new object[] { id }, ct).AsTask();
    }

    public Task SaveChangesAsync(CancellationToken ct)
    {
        return _context.SaveChangesAsync(ct);
    }
}