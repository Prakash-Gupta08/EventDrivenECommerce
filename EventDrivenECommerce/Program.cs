using EventDrivenECommerce.AppDBContext;
using EventDrivenECommerce.Interfaces;
using EventDrivenECommerce.RabbitMQ;
using EventDrivenECommerce.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (IMPORTANT: configure connection string)
builder.Services.AddDbContext<db_context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MySqlConn")
    )
);

// Dependency Injection
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();
builder.Services.AddHostedService<RabbitMqConsumer>();


var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();