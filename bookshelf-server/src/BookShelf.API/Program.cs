using BookShelf.API.Middlewares;
using BookShelf.Application;
using BookShelf.Infrastructure;
using BookShelf.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.DescribeAllParametersInCamelCase();
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(o =>
    {
        o.AddPolicy("CorsPolicy",
            builder => 
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");

    // Initialise and seed database
    using IServiceScope scope = app.Services.CreateScope();

    BookshelfDbContextInitializer initialiser = scope.ServiceProvider.GetRequiredService<BookshelfDbContextInitializer>();

    await initialiser.SeedAsync();
}

app.UseMiddleware<CorrelationIdMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
