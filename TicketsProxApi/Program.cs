using TicketsProxApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))

    };
});


var app = builder.Build();

app.UseCors(option =>
{
   option.WithOrigins("http://localhost:5173");
  // option.WithOrigins("https://ticketssalesprox.netlify.app");
    //option.WithMethods("GET", "POST", "PUT");
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
