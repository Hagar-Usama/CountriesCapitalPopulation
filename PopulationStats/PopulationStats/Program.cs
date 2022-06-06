
using Microsoft.EntityFrameworkCore;
using PopulationStats.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PopuContext>(opt =>
    opt.UseInMemoryDatabase("Population"));

builder.Services.AddEndpointsApiExplorer();

// reading external apis

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
