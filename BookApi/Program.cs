using BookApi.Database;
using BookApi.Interface;
using BookApi.Mapper;
using BookApi.Reposoratory;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
// //Connection 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Add Scope
builder.Services.AddScoped(typeof(IAutherRep), typeof(AutherRep));
builder.Services.AddScoped(typeof(IBookRep), typeof(BookRep));

//Auto Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new Imapper()));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Test Api",
        Description = "My first Api",
        TermsOfService = new Uri("https://www.google.com"),
        Contact = new OpenApiContact
        {
            Name = "Esam",
            Email = "mohamed@gmail.com",
        },
        License = new OpenApiLicense
        {
            Name = "My License",
            Url = new Uri("https://www.google.com")
        }
    });
    option.AddSecurityDefinition("Barer", new OpenApiSecurityScheme
    {
        Name = "Autheraiz",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
           {
               Reference =new OpenApiReference
               {
                   Type = ReferenceType.SecurityScheme,
                   Id ="Bearer"
               }, 
               Name ="Bearer",
               In=ParameterLocation.Header
           },
           new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();
app.MapControllers();
app.Run();
