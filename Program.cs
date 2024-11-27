using Microsoft.EntityFrameworkCore;
using Ct.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CtContext>(opt =>
    opt.UseSqlServer("data source=10.11.0.69;initial catalog=Directorio;user id=sa;password=2en1;MultipleActiveResultSets=True;;Connection Timeout=60;Trusted_Connection=true;TrustServerCertificate=true;Encrypt=false;Integrated Security=False;"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();