using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("MyBlobConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
