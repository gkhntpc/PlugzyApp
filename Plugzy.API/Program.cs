using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure;
using Plugzy.Service.Commands;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});




builder.Services.AddDbContext<PlugzyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<PlugzyDbContext>();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(LoginCommand)));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
