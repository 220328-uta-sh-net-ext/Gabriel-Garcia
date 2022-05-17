global using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API.Repository;
using System.Text;
using BL;
using DL;

Log.Logger = new LoggerConfiguration().WriteTo.File("./Logs/user.text").CreateLogger();

//sql connectin
string connectinStrringFilePath = "../SQLConnection.txt";
string connectinStrring = File.ReadAllText(connectinStrringFilePath);



var builder = WebApplication.CreateBuilder(args);
var Config = builder.Configuration;
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    var key = Encoding.UTF8.GetBytes(Config["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = Config["JWT: Issuer"],
        ValidAudience = Config["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
    });
builder.Services.AddMemoryCache();
builder.Services.AddControllers(options => options.RespectBrowserAcceptHeader = true).AddXmlSerializerFormatters();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();

builder.Services.AddScoped<IRepositoryR>(repoR => new RepoRestaurants(connectinStrring));
builder.Services.AddScoped<IRepositoryU>(repoU => new RepoUsers(connectinStrring));
builder.Services.AddScoped<IRepositoryRev>(repoRev => new RepoReview(connectinStrring));
builder.Services.AddScoped<IRepositoryLoc>(repoLoc => new RepoLocation(connectinStrring));

builder.Services.AddScoped<IRestaurantLogic, RestaurantLogic>();
//builder.Services.AddScoped<IReviewLogic, RestaurantLogic>();
//builder.Services.AddScoped<ILocationLogic, RestaurantLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
//builder.Services.AddScoped<IReviewLogic, UserLogic>();

builder.Services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();

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

app.MapControllers();

app.Run();
