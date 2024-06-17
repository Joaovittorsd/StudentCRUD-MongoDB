using CRUD_With_MongoDb.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddTransient<IStudentRerpository, StudentRepository>();

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
