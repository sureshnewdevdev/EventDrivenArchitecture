using EventDrivenArchitecture.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register Swagger generator
builder.Services.AddSwaggerGen();

// Other services
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<InventoryService>();
builder.Services.AddTransient<NotificationService>();

var app = builder.Build();

// Subscribe to events
app.Services.GetRequiredService<InventoryService>();
app.Services.GetRequiredService<NotificationService>();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventDrivenAPI v1");
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
