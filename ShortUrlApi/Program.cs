using Microsoft.EntityFrameworkCore;
using ShortUrlApi.DataModel;
using ShortUrlApi.DataModel.Repository;
using ShortUrlApi.DataModel.Services;

var builder = WebApplication.CreateBuilder(args);


//Data Base Service
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShortUrlConnextionString"),
        datamodel => datamodel.MigrationsAssembly("ShortUrlApi.DataModel"));
});


// Add services to the container.
builder.Services.AddScoped<IShortUrlRepository, ShortUrlRepository>();

builder.Services.AddControllers();
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
