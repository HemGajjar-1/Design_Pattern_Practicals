using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Practical_22.Application.Interfaces;
using Practical_22.Infrastructure.Data;
using Practical_22.Infrastructure.Logging;
using Practical_22.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSingleton<ILoggerService>(LoggerService.Instance);
builder.Services.AddScoped<IEmployeeService>(provider =>{
    var context = provider.GetRequiredService<ApplicationDbContext>();
    var logger = provider.GetRequiredService<ILoggerService>();
    return EmployeeService.GetInstance(context, logger);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
