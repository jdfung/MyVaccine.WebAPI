using MyVaccine.Core;
using MyVaccine.DB;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddTransient<IAppointmentServices, AppointmentServices>();
builder.Services.AddTransient<IApplicantServices, ApplicantServices>();
builder.Services.AddTransient<IVaccCentreServices, VaccCentreServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyVaccinePolicy",
        builder =>
        {
            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
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

app.UseAuthorization();

app.UseCors("MyVaccinePolicy");

app.MapControllers();

app.Run();
