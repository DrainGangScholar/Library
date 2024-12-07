using api.Data;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(o =>
{
    o.LowercaseUrls = true;
    o.LowercaseQueryStrings = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]);
}, ServiceLifetime.Scoped);
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoanService, LoanService>();
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
