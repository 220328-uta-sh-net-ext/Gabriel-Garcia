using BL;
using DL;

//sql connectin
string connectinStrringFilePath = "../SQLConnection.txt";
string connectinStrring = File.ReadAllText(connectinStrringFilePath);



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryR>(repoR => new RepoRestaurants(connectinStrring));
builder.Services.AddScoped<IRepositoryRev>(repoRev => new RepoReview(connectinStrring));
builder.Services.AddScoped<IRestaurantLogic, RestaurantLogic>();


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
