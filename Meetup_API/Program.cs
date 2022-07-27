using Meetup_API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Uncomment to use mock repository
//builder.Services.AddScoped<IMeetupRepository, MockMeetupRepository>();
//Uncomment to use DB repository
builder.Services.AddScoped<IMeetupRepository, SqlMeetupRepository>();

builder.Services.AddDbContext<MeetupDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("MeetupConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
