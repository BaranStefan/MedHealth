using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YourProjectName.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCorsPolicy", builder =>
    {
        builder
            .WithOrigins("https://localhost:5173/") // replace with your Vue.js application address
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

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

// Use CORS
app.UseCors("VueCorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
