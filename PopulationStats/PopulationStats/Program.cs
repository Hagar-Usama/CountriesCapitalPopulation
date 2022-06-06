
//using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PopulationStats.Models;
//using RestSharp
//Using System.Net.Http directive which will enable HttpClient.
using System.Net.Http;
//use newtonsoft to convert json to c# objects.
using Newtonsoft.Json.Linq;

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
