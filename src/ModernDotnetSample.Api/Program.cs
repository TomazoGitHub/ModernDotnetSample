using ModernDotnetSample.Application;
using ModernDotnetSample.Domain.Entities;
using ModernDotnetSample.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderRepository, FakeOrderRepository>();
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


public class FakeOrderRepository : IOrderRepository
{
    public Task AddAsync(Order order, CancellationToken ct)
        => Task.CompletedTask;

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct)
        => throw new NotImplementedException();

    public Task SaveChangesAsync(CancellationToken ct)
        => Task.CompletedTask;
}
