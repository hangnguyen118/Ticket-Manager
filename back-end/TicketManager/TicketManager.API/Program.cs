using Microsoft.EntityFrameworkCore;
using TicketManager.API.Data;
using TicketManager.API.Data.DbInitializer;
using TicketManager.API.Data.Repository;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseRepository<Cinema>, BaseRepository<Cinema>>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader().WithOrigins("http://172.0.0.235:3000").AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
