using AA.BulkSMS.Core.Data;
using AA.BulkSMS.Core.Data.Entities;
using AA.BulkSMS.Core.Data.Repositories;
using AA.BulkSMS.Core.Services;
using AA.BulkSMS.Core.Services.ServiceInterfaces;
using AA.BulkSMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IContactRespository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BulkSMS API", Version = "v1" });
});
// PXAPI-Sentinel-Global


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BulkSMS API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllers();

app.Run();
