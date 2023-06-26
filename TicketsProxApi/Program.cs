using TicketsProxApi.Data;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();

var Default = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<Contexto>(options =>
   options.UseSqlServer(Default)
);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Contexto, Contexto>();

var app = builder.Build();

app.UseCors(option =>
{
    option.WithOrigins("http://localhost:5173");
    option.AllowAnyMethod();
    option.AllowAnyHeader();

});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   
//}


 app.UseSwagger();
 app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
