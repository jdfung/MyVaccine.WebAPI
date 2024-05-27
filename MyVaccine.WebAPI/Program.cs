using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyVaccine.Core;
using MyVaccine.DB;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddTransient<IAppointmentServices, AppointmentServices>();
builder.Services.AddTransient<IApplicantServices, ApplicantServices>();
builder.Services.AddTransient<IVaccCentreServices, VaccCentreServices>();
builder.Services.AddTransient<IAdminAuthServices, AdminAuthServices>();

builder.Services.AddAuthentication().AddJwtBearer(options =>{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:AccessToken").Value!))
    };
        
});

builder.Services.Configure<GetAppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddOptions();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyVaccinePolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:7015/", "http://localhost:3000/").AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials();
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

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyVaccinePolicy");

app.MapControllers();

app.Run();
