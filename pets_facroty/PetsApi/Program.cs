using PetsApi.Services;
using PetsApi.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PetStoreDatabaseSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<PetService>();

builder.Services.AddControllers();
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
